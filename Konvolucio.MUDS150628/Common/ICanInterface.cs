namespace Konvolucio.MUDS150628.Common
{
    using System;

    public interface  ICanInterface: IDisposable
    {
        void Init(UInt64 baudrate, string intfName);
        void WriteFrame(CanMsg[] frames);
        CanMsg[] ReadFrame();
    }

}
