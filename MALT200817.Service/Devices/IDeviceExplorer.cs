namespace MALT200817.Service.Devices
{
    using Common;

    public interface IDeviceExplorer
    {
        SafeQueue<CanMsg> TxQueue { get; }
        DeviceCollection Devices { get; }
        void FramesIn(CanMsg frame);
        void RequestOnOne(byte cardType, byte addr, byte channel);
        void RequestOffOne(byte cardType, byte addr, byte channel);
    }
}
