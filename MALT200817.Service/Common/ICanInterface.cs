namespace MALT200817.Service.Common
{
    using System;

    public interface  ICanInterface: IDisposable
    {

        void Init(UInt64 baudrate, string intfName);
        void WriteFrame(CanMsg[] frames);
        CanMsg[] ReadFrame();
    }



    public struct CanMsg
    {
        public UInt32 Id;
        public int Length;
        public UInt64 Payload;
    }
}
