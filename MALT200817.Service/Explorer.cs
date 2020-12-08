namespace MALT200817.Service
{
    using Common;
    using System;
    using System.Linq;
    using System.Threading;

    public class Explorer
    {
        const UInt32 DIR_MASK = 0x000F0000;
        const UInt32 EXT_ID = 0x20000000;
        const UInt32 DEV_ID = 0x15500000;
        const UInt32 DEV_ADDR = 0x000000FF;
        const UInt32 GLOBAL_ID = 0x1558FFFF;
        const UInt32 HOST_RX_ID = 0x00020000;
        const UInt32 HOST_TX_ID = 0x00010000;
        public const int FIRST_BLOCK = 0;

        public SafeQueue<CanMsg> TxQueue { get; } = new SafeQueue<CanMsg>();
        public LiveDeviceCollection LiveDevices { get; } = new LiveDeviceCollection();

        public void FramesIn(CanMsg frame)
        {
            var data = frame.GetPayload();
            try
            {             
                if ((frame.Id & DIR_MASK) != HOST_RX_ID)
                    return;

                /*** RespInfo ***/
                if (data[0] == 0xF0)
                {
                    var device = new LiveDeviceItem(familyCode: data[2],
                                                     address: data[3],
                                                     optionCode: data[4],
                                                     ver0: data[5],
                                                     ver1: data[6]);
                    bool found = false;
                    foreach (LiveDeviceItem dev in LiveDevices){
                        if (dev.Address == device.Address &&
                             dev.FamilyCode == device.FamilyCode)
                            found = true;
                    }
                    if (!found)
                    {
                        LiveDevices.Add(device);
                    }
                    /*** Minden egyes bejelenkezéskor ezeket elkéri ***/
                    GetSerialnumber(familyCode: data[2], address: data[3]);
                    if (device.OutputPorts.Count != 0)
                        GetOutputsStatus(familyCode: data[2], address: data[3], autosend: true);
                    if (device.InputPorts.Count != 0)
                        GetInputsStatus(familyCode: data[2], address: data[3], autosend: true);

                }
                else if (data[1] == 0x02) 
                { 
                }
                /*** RespOutputsStatus ***/
                else if (data[1] == 0x04) 
                {
                    var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.UpdateOutputPortsStatus((int)data[6], new byte[] { data[2], data[3], data[4], data[5] });
                }

                /*** RespOneInputStatus ***/
                else if (data[1] == 0x06)
                {
                    /*
                    var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.SetPortsStatus((int)data[6], new byte[] { data[2], data[3], data[4], data[5] });
                    */
                }
                /*** RespInputsStatus ***/
                else if (data[1] == 0x07)
                {
                    var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.UpdateInputPortsStatus((int)data[6], new byte[] { data[2], data[3], data[4], data[5] });
                }

                /*** RespSerialnumber ***/
                else if (data[1] == 0xDE)
                {
                    var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.SetSerialNumber(new byte[] { data[3], data[4], data[5], data[6] });
                }
                /*** RespCounter ***/
                else if (data[1] == 0xEE && data[2] == 1)
                {
                    var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.Counters[data[3]] = BitConverter.ToInt32(new byte[] { data[4], data[5], data[6], data[7] }, 0x00);
                }
            }
            catch (Exception ex){
                AppLog.Instance.WriteLine("Explorer:Frames in:" + ex.Message + "The frame was:" + Tools.ConvertByteArrayToCStyleString(data));
            }

        }

        public void GetInfoByAddress()
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | GLOBAL_ID;
            msg.SetPayload(new byte[] { 0xAB, 0xFF });
            TxQueue.Enqueue(msg);
        }


        /// <param name="port">1-es indexelésű</param>
        public void ClrOneOutput(byte familyCode, byte address, int port)
        {
            if (port == 0)
                throw new Exception("Error: parameter port cannot be 0.");
            port = port - 1;

            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x01, (byte)port, 0x00 });
            TxQueue.Enqueue(msg);
        }
        /// <param name="port">1-jelenti a K1-egyet indexelésű</param>
        public void SetOneOutput(byte familyCode, byte address, int port)
        {
            if (port == 0)
                throw new Exception("Error: parameter port cannot be 0.");
            port -= 1;

            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x01, (byte)port, 0x01 });
            TxQueue.Enqueue(msg);
        }

        public void ResetIo(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x03, 0x00, 0x00, 0x00, 0x00, 0x06 });
            TxQueue.Enqueue(msg);

            /*Todo:Ez kell valamiért MALT160T-nek, majd megnézni mért nemgy megy*/
            for (byte i = 0; i < 4; i++)
            {
                SetOutputs(familyCode, address, new byte[] { 0, 0, 0, 0 }, i);
                TxQueue.Enqueue(msg);
            }
        }

        public void ClrOutputs(byte familyCode, byte address, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x03, several[0], several[1], several[2], several[3], 0x00, block });
            TxQueue.Enqueue(msg);
        }

        public void SetOutputs(byte familyCode, byte address, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x03, several[0], several[1], several[2], several[3], 0x01, block });
            TxQueue.Enqueue(msg);
        }

        public void GetOutputsStatus(byte familyCode, byte address, bool autosend)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x04, autosend ? (byte)0x01 : (byte)0x00 });
            TxQueue.Enqueue(msg);
        }

        /// <param name="port">1-es indexelésű</param>
        public bool GetOneOutput(byte familyCode, byte address, int port)
        {
            if (port == 0)
                throw new Exception("Error: parameter port cannot be 0.");
            port -= 1;
            var dev = LiveDevices.Search(familyCode, address);
            var block = port / 32; 
            var byteIndex = (port / 8) - (4 * block); //ha egy port szám nagyobb mint egy block akkor azzal korrigálni kell.
            var bitIndex = port % 8;
            return (dev.OutputPorts[block][byteIndex] & (1 << bitIndex)) != 0;
        }
        /// <param name="port">1-es indexelésű</param>
        public bool GetOneInputStatus(byte familyCode, byte address, int port)
        {
            /*Todo Erre van külön CAN utasitás*/
            if (port == 0)
                throw new Exception("Error: parameter port cannot be 0.");
            port -= 1;

            var dev = LiveDevices.Search(familyCode, address);
            var block = port / 32;
            var byteIndex = (port / 8) - (4 * block); //ha egy port szám nagyobb mint egy block akkor azzal korrigálni kell.
            var bitIndex = port % 8;
            return (dev.InputPorts[block][byteIndex] & (1 << bitIndex)) != 0;
        }

        public void GetInputsStatus(byte familyCode, byte address, bool autosend)
        {
            /*Todo ez itt nincs kész!*/
            var dev = LiveDevices.FirstOrDefault(n => n.FamilyCode == familyCode && n.Address == address);
          
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x07, autosend ? (byte)0x01 : (byte)0x00 });
            TxQueue.Enqueue(msg);
        }

        public byte[] GetOutputs(byte familyCode, byte address, byte block)
        {
            var dev = LiveDevices.FirstOrDefault(n => n.FamilyCode == familyCode && n.Address == address);
            if (dev == null)
                throw new ApplicationException("MALT Device Not found: CardType:" + familyCode.ToString("X2") + ", Address:" + address.ToString("X2"));
            var retval = new byte[dev.BlockSize];
            Array.Copy(dev.OutputPorts[FIRST_BLOCK], retval, retval.Length);
            return retval;
        }

        public void GetSerialnumber(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0xDE, 0xF5 });
            TxQueue.Enqueue(msg);
        }

        /*Todo:HostStart*/
        /*Todo:CountersReset */

        public void RequestSaveCounters(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0xEE, 0x11 });
            TxQueue.Enqueue(msg);
        }

        /// <param name="port">1-es indexelésű</param>
        public void GetCounter(byte familyCode, byte address, byte port)
        {
            port -= 1;
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0xEE, 0x01, port });
            TxQueue.Enqueue(msg);
        }

        public void SetPortCounter(byte familyCode, byte address, byte port, int value)
        {
            port -= 1;
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            var data = BitConverter.GetBytes(value);
            msg.SetPayload(new byte[] { familyCode, 0xEE, 0x02, port, data[0], data[1], data[2], data[3] });
            TxQueue.Enqueue(msg);
        }

        public void SaveCounters(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0xEE, 0x03 });
            TxQueue.Enqueue(msg);
        }

        public void InitCardsForFirstStart()
        {
            GetInfoByAddress();
        }

        public void SaveCounters()
        {
            foreach (LiveDeviceItem dev in LiveDevices)
            {
                RequestSaveCounters((byte)dev.FamilyCode, (byte)dev.Address);
            }
        }


        ///// <summary>
        ///// A Service indulásakor ezt lekéri és ezuztán többet kilens ehhez nem nyúl.
        ///// A kilensek értesülnek róla ha új kártya jön, mivel az új kártyának kötelessége jelezni hogy
        ///// megérkezett.
        ///// </summary>
        //public void DoUpdateDeviceInfo()
        //{
        //    /*LiveDevices.Clear(); */
        //    /*Nem törölhetek, mert ha jön egy kliens vagy és ráfrissít, és a többi kliens pedig épp keres benne, akkor az baj.*/
        //    RequestAllInitInfo();
        //    //Meg kell várni hogy a lista felépüljön és utána lekrédezni a státuszokat
        //    Thread.Sleep(250);

        //    foreach (LiveDeviceItem dev in LiveDevices)
        //    {
        //        RequestPortsStatus((byte)dev.FamilyCode, (byte)dev.Address, true);
        //        RequestSaveCounters((byte)dev.FamilyCode, (byte)dev.Address);
        //        //RequestSerialNumber((byte)dev.FamilyCode, (byte)dev.Address);
        //    }

        //    //Meg kell várni hogy a lekérdezett státuszok is megérkezzenek
        //    Thread.Sleep(250);
        //}
    }
}
