namespace MALT200817.Service.Devices
{
    using Common;

    public interface IExplorer
    {
        DeviceCollection Devices { get; }
        SafeQueue<CanMsg> TxQueue { get; }
        void FramesIn(CanMsg frame);
        void RequestClrOne(byte cardType, byte addr, byte port);
        void RequestSetOne(byte cardType, byte addr, byte port);
        void RequestClrSeveral(byte cardType, byte addr, byte[] several);
        void RequestSetSeveral(byte cardType, byte addr, byte[] several);

        bool RequestGetOne(byte cardType, byte addr, byte port);
        
    }
}
