namespace MALT200817.Service.Devices
{
    using Common;

    public interface IDeviceExplorer
    {
        SafeQueue<CanMsg> TxQueue { get; }
        void FrameParser(CanMsg[] frames);
        void Set(byte cardType, byte addr, byte channel);
        void Clr(byte cardType, byte addr, byte channel);
    }
}
