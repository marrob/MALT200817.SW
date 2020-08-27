namespace MALT200817.Service.Common
{
    using System;

    public interface  ICanInterface: IDisposable
    {
        void Init(UInt64 baudrate, string intfName);
        void WriteFrame(CanMsg[] frames);
        CanMsg[] ReadFrame();
    }

}
