﻿namespace MALT200817.Service.Devices
{
    using Common;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;

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
        public DeviceCollection Devices { get; } = new DeviceCollection();

        public void FramesIn(CanMsg frame)
        {
            try
            {
                var data = frame.GetPayload();
                if ((frame.Id & DIR_MASK) != HOST_RX_ID)
                    return;

                /* Response Init Info */
                if (data[0] == 0xF0)
                {
                    var newDev = new DeviceItem(data[2], data[3], data[4], data[5], data[6]);
                    bool found = false;
                    foreach (DeviceItem dev in Devices)
                    {
                        if (dev.PrimaryKey == newDev.PrimaryKey)
                            found = true;
                    }

                    if (!found)
                        Devices.Add(newDev);
                }

                /* Response Ports Status */
                if (data[1] == 0x04)
                {
                    var dev = Devices.Search(cardType : data[0], address: (byte)(frame.Id & DEV_ADDR));
                    dev.SetPortsStatus((int)data[6], new byte[] { data[2], data[3], data[4], data[5] });
                }
            }
            catch (Exception ex)
            {
                AppLog.Instance.WriteLine(ex.Message);
            }

        }

        /// <param name="port">0-es indexelésű</param>
        public void RequestClrOne(byte cardType, byte addr, byte port)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x01, port, 0x00 });
            TxQueue.Enqueue(msg);
        }
        /// <param name="port">0-jelenti a K1-egyet indexelésű</param>
        public void RequestSetOne(byte cardType, byte addr, byte port)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x01, port, 0x01 });
            TxQueue.Enqueue(msg);
        }

        /// <param name="port">0-ás indexelésű</param>
        public bool GetOne(byte cardType, byte address, byte port)
        {
            var dev = Devices.Search(cardType, address);
            var byteIndex = port / 8;
            var bitIndex = port % 8;
            return (dev.Ports[FIRST_BLOCK][byteIndex] & (1 << bitIndex)) != 0;
        }

        public void RequestClrSeveral(byte cardType, byte addr, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x03, several[0], several[1], several[2], several[3], 0x00 , block });
            TxQueue.Enqueue(msg);
        }

        public void RequestSetSeveral(byte cardType, byte addr, byte[] several, byte block)
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x03, several[0], several[1], several[2], several[3], 0x01, block });
            TxQueue.Enqueue(msg);
        }

        public byte[] GetSeveral(byte cardType, byte addr, byte block)
        {
            var dev = Devices.FirstOrDefault(n => n.FamilyCode == cardType && n.Address == addr);
            if (dev == null)
                throw new ApplicationException("MALT Device Not found: CardType:" + cardType.ToString("X2") + ", Address:" + addr.ToString("X2"));
            var retval = new byte[dev.Descriptor.BytePerBlock];
            Array.Copy(dev.Ports[FIRST_BLOCK], retval, retval.Length);
            return retval;
        }

        public void RequestSaveCounters()
        {
            foreach (DeviceItem dev in Devices)
            {
                var msg = new CanMsg();
                msg.Id = EXT_ID | DEV_ID | HOST_TX_ID | (UInt32)dev.FamilyCode << 8 | (byte)dev.Address;
                msg.SetPayload(new byte[] { (byte)dev.FamilyCode, 0xEE, 0x11 });
                TxQueue.Enqueue(msg);
            }
        }

        public void RequestAllInitInfo()
        {
            var msg = new CanMsg();
            msg.Id = EXT_ID | GLOBAL_ID;
            msg.SetPayload(new byte[] { 0xAB, 0xFF });
            TxQueue.Enqueue(msg);
        }


    }
}