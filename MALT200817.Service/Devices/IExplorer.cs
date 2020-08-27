namespace MALT200817.Service.Devices
{
    using Common;

    public interface IExplorer
    {
        DeviceCollection Devices { get; }
        SafeQueue<CanMsg> TxQueue { get; }
        void FramesIn(CanMsg frame);
        void RequestSetOne(byte cardType, byte addr, byte channel);
        void RequestClrOne(byte cardType, byte addr, byte channel);
    }
}
