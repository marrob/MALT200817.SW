namespace MALT200817.Service
{
    using Common;

    public interface IExplorer
    {
        LiveDeviceCollection LiveDevices { get; }
        SafeQueue<CanMsg> TxQueue { get; }
        void FramesIn(CanMsg frame);
        void RequestClrOne(byte familyCode, byte address, int port);
        void RequestSetOne(byte familyCode, byte address, int port);
        void RequestClrSeveral(byte familyCode, byte address, byte[] several, byte block);
        void RequestSetSeveral(byte familyCode, byte address, byte[] several, byte block);
        byte[] GetSeveral(byte familyCode, byte address, byte block);
        bool GetOne(byte familyCode, byte address, int port);
        void DoUpdateDeviceInfo();


    }
}
