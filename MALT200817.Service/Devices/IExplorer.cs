namespace MALT200817.Service.Devices
{
    using Common;

    public interface IExplorer
    {
        LiveDeviceCollection LiveDevices { get; }
        SafeQueue<CanMsg> TxQueue { get; }
        void FramesIn(CanMsg frame);
        void RequestClrOne(byte cardType, byte addr, byte port);
        void RequestSetOne(byte cardType, byte addr, byte port);
        void RequestClrSeveral(byte cardType, byte addr, byte[] several, byte block);
        void RequestSetSeveral(byte cardType, byte addr, byte[] several, byte block);
        byte[] GetSeveral(byte cardType, byte addr, byte block);
        bool GetOne(byte cardType, byte addr, byte port);
        void DoUpdateCardsInfo();


    }
}
