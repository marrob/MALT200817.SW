namespace MALT200817.Service.Devices
{
    using Common;
    using System;

    public class DeviceExplorer : IDeviceExplorer
    {

        const UInt32 ID_FIXED_PART = 0x155 << 20;
        const UInt32 ID_DEV_RX = 1 << 16;


        public SafeQueue<CanMsg> TxQueue { get; } = new SafeQueue<CanMsg>();



        public void FrameParser(CanMsg[] frames)
        {

        }


        public void Set(byte cardType, byte addr, byte channel)
        {
            var msg = new CanMsg();
            msg.Id = ID_FIXED_PART | ID_DEV_RX | (UInt32)cardType << 8 | addr;
            var data = new byte[] { cardType, 0x01, channel, 0x01 };
            msg.Length = data.Length;
            msg.Payload = BitConverter.ToUInt32(data, 0);
            TxQueue.Enqueue(msg);
        }

        public void Clr(byte cardType, byte addr, byte channel)
        {

        }
    }
}
