namespace MALT200817.Service.Devices
{
    using Common;
    using System;

    public class DeviceExplorer : IDeviceExplorer
    {
        const UInt32 ID_EXT = 0x20000000;
        const UInt32 DEV_ID = 0x15500000;
        const UInt32 GLOBAL_ID = 0x1558FFFF;
        const UInt32 DEV_RX_ID = 1 << 16;
        

        public SafeQueue<CanMsg> TxQueue { get; } = new SafeQueue<CanMsg>();
        public DeviceCollection Devices { get; } = new DeviceCollection();



        public void FramesIn(CanMsg frame)
        {

            var data = frame.GetPayload();

            if (data[0] == 0xF0 && data[1] == 0x01)
            { //Response Init Info

                var newDev =  new Device(data[2], data[3], data[4], data[5], data[6]);

                bool found = false;
                foreach (Device dev in Devices)
                {
                    if (dev.ToString() == newDev.ToString())
                    {
                        found = true;
                    }
                }

                if (!found)
                    Devices.Add(newDev);
            }
  
        }


        public void DevDiscover()
        { 
        
        }

        public void RequestOnOne(byte cardType, byte addr, byte channel)
        {
            var msg = new CanMsg();
            msg.Id = ID_EXT | DEV_ID | DEV_RX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x01, channel, 0x01 });
            TxQueue.Enqueue(msg);
        }

        public void RequestOffOne(byte cardType, byte addr, byte channel)
        {
            var msg = new CanMsg();
            msg.Id = ID_EXT | DEV_ID | DEV_RX_ID | (UInt32)cardType << 8 | addr;
            msg.SetPayload(new byte[] { cardType, 0x01, channel, 0x00 });
            TxQueue.Enqueue(msg);
        }


        public void RequestAllInitInfo()
        {
            var msg = new CanMsg();
            msg.Id = ID_EXT | GLOBAL_ID;
            msg.SetPayload(new byte[] { 0xAB, 0xFF });
            TxQueue.Enqueue(msg);
        }
    }
}
