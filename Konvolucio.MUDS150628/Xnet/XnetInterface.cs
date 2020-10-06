namespace Konvolucio.MUDS150628.Xnet
{
    using System;
    using NiXnetDotNet;
    using System.Runtime.InteropServices;
    using Common;
  

    public class XnetInterface : ICanInterface
    {
        private NiXnetSession SessionIn = null;
        nxFrame[] BufferIn;
        IntPtr PtrBuffRIn;
        bool Disposed;


        private NiXnetSession SessionOut = null;
        nxFrame[] BufferOut;
        IntPtr PtrBufferOut;

        public void Init(UInt64 baudrate, string intfName)
        {
            SessionIn = new NiXnetSession(":memory:", "", Array.Empty<string>(), intfName, NiXnetMode.FrameInStream);
            SessionIn.BaudRate64 = baudrate;
            BufferIn = new nxFrame[100];
            GCHandle gchIn = GCHandle.Alloc(BufferIn, GCHandleType.Pinned);
            PtrBuffRIn = gchIn.AddrOfPinnedObject();


            BufferOut = new nxFrame[2];
            SessionOut = new NiXnetSession(":memory:", "", Array.Empty<string>(), intfName, NiXnetMode.FrameOutStream);
            SessionOut.BaudRate64 = baudrate;
            GCHandle gchOut = GCHandle.Alloc(BufferOut, GCHandleType.Pinned);
            PtrBufferOut = gchOut.AddrOfPinnedObject();

            SessionIn.Start(NiXnetScope.Normal);
            SessionOut.Start(NiXnetScope.Normal);

        }

        public CanMsg[] ReadFrame()
        {
            UInt32 readBytes = 0;
            var frames = new CanMsg[0];

            unsafe
            {
                SessionIn.ReadFrame((void*)PtrBuffRIn, (uint)BufferIn.Length * (uint)sizeof(nxFrame), 0, &readBytes);
                var framesCnt = readBytes / sizeof(nxFrame);
                frames = new CanMsg[framesCnt];

                for (int i = 0; i < framesCnt; i++)
                {
                    frames[i].Id = BufferIn[i].Id;
                    frames[i].Length = BufferIn[i].Length;
                    frames[i].Payload = BufferIn[i].Payload;
                }

            }
            return frames;
        }

        public void WriteFrame(CanMsg[] frames)
        {
            if (frames.Length > BufferOut.Length)
                throw new ApplicationException("XNET Buffer Out too small.");

            for (int i = 0; i < frames.Length; i++)
            {
                BufferOut[i].Id = frames[i].Id;
                BufferOut[i].Length = (byte)frames[i].Length;
                BufferOut[i].Payload = frames[i].Payload;
            }

            unsafe
            {
                SessionOut.WriteFrame((void*)PtrBufferOut, (uint)frames.Length * (uint)sizeof(nxFrame), 10000);
            }
        }

        public void Dispose()
        {
            SessionIn.Stop(NiXnetScope.Normal);
            SessionOut.Stop(NiXnetScope.Normal);
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (Disposed)
                return;

            if (disposing)
            {
                SessionIn.Dispose();
                SessionOut.Dispose();

            }
            Disposed = true;
        }
    }
}
