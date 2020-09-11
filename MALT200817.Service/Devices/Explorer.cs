namespace MALT200817.Service.Devices
{
    using Common;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;

    public class Explorer : IExplorer
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

        object _lockObj = new object();

        public void FramesIn(CanMsg frame)
        {
            lock (_lockObj)
            {
                try
                {
                    var data = frame.GetPayload();
                    if ((frame.Id & DIR_MASK) != HOST_RX_ID)
                        return;

                    /* Response Init Info */
                    if (data[0] == 0xF0)
                    {
                        var newDev = new LiveDeviceItem(data[2], data[3], data[4], data[5], data[6]);
                        bool found = false;
                        foreach (LiveDeviceItem dev in LiveDevices)
                        {
                            if (dev.PrimaryKey == newDev.PrimaryKey)
                                found = true;
                        }
                        if (!found)
                            LiveDevices.Add(newDev);
                    }
                    /* Response Ports Status */
                    else if (data[1] == 0x04)
                    {
                        var familyCode = data[0];
                        var adddress = (byte)(frame.Id & DEV_ADDR);
                        var dev = LiveDevices.Search(familyCode, adddress);
                        dev.SetPortsStatus((int)data[6], new byte[] { data[2], data[3], data[4], data[5] });
                    }
                    /* Response Serial Number*/
                    else if (data[1] == 0xDE)
                    {
                        var dev = LiveDevices.Search(familyCode: data[0], address: (byte)(frame.Id & DEV_ADDR));
                        dev.SetSerialNumber(new byte[] { data[3], data[4], data[5], data[6] });
                    }

                }
                catch (Exception ex)
                {
                    AppLog.Instance.WriteLine(ex.Message);
                }
            }
        }

        /// <param name="port">0-es indexelésű</param>
        public void RequestClrOne(byte familyCode, byte address, byte port)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x01, port, 0x00 });
            TxQueue.Enqueue(msg);
        }
        /// <param name="port">0-jelenti a K1-egyet indexelésű</param>
        public void RequestSetOne(byte familyCode, byte address, byte port)
        {
            lock (_lockObj)
            {
                var msg = new CanMsg();
                msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
                msg.SetPayload(new byte[] { familyCode, 0x01, port, 0x01 });
                TxQueue.Enqueue(msg);
            }
        }

        /// <param name="port">0-ás indexelésű</param>
        public bool GetOne(byte familyCode, byte address, byte port)
        {
            lock (_lockObj)
            {
                var dev = LiveDevices.Search(familyCode, address);
                var byteIndex = port / 8;
                var bitIndex = port % 8;
                return (dev.Ports[FIRST_BLOCK][byteIndex] & (1 << bitIndex)) != 0;
            }
        }

        public void RequestClrSeveral(byte familyCode, byte address, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x03, several[0], several[1], several[2], several[3], 0x00 , block });
            TxQueue.Enqueue(msg);
        }

        public void RequestSetSeveral(byte familyCode, byte addr, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | addr;
            msg.SetPayload(new byte[] { familyCode, 0x03, several[0], several[1], several[2], several[3], 0x01, block });
            TxQueue.Enqueue(msg);
        }

        public byte[] GetSeveral(byte familyCode, byte address, byte block)
        {
            var dev = LiveDevices.FirstOrDefault(n => n.FamilyCode == familyCode && n.Address == address);
            if (dev == null)
                throw new ApplicationException("MALT Device Not found: CardType:" + familyCode.ToString("X2") + ", Address:" + address.ToString("X2"));
            var retval = new byte[dev.Descriptor.BytePerBlock];
            Array.Copy(dev.Ports[FIRST_BLOCK], retval, retval.Length);
            return retval;
        }

        public void RequestPortsStatus(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | address;
            msg.SetPayload(new byte[] { familyCode, 0x04, 1 });
            TxQueue.Enqueue(msg);
        }

        public void RequestSaveCounters(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | (byte)address;
            msg.SetPayload(new byte[] { familyCode, 0xEE, 0x11 });
            TxQueue.Enqueue(msg);
        }

        public void RequestAllInitInfo()
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | GLOBAL_ID;
            msg.SetPayload(new byte[] { 0xAB, 0xFF });
            TxQueue.Enqueue(msg);
        }

        public void RequestSerialNumber(byte familyCode, byte address)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)familyCode << 8 | (byte)address;
            msg.SetPayload(new byte[] { familyCode, 0xDE, 0xF5 });
            TxQueue.Enqueue(msg);
        }

        static bool i = false;
        public void DoUpdateDeviceInfo()
        {
            lock (_lockObj)
            {

                if (!i)
                {
                    LiveDevices.Clear();
                    RequestAllInitInfo();
                    //Meg kell várni hogy a lista felépüljön és utána lekrédezni a státuszokat
                    Thread.Sleep(250);

                    foreach (LiveDeviceItem dev in LiveDevices)
                    {
                        RequestPortsStatus((byte)dev.FamilyCode, (byte)dev.Address);
                        RequestSaveCounters((byte)dev.FamilyCode, (byte)dev.Address);
                        RequestSerialNumber((byte)dev.FamilyCode, (byte)dev.Address);
                    }
                    i = true;
                }

            }

            //Meg kell várni hogy a lekérdezett státuszok is megérkezzenek
            Thread.Sleep(250);
        }
    }
}
