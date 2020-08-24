namespace MALT200817.Service.Xnet
{
    using System;
    using NiXnetDotNet;
    using System.Runtime.InteropServices;
    using Common;

    public class XnetInterface : ICanInterface
    {
        private NiXnetSession _sessionIn = null;
        nxFrame[] _bufferIn;
        IntPtr _ptrBuffRIn;
        bool _disposed;


        private NiXnetSession _sessionOut = null;
        nxFrame[] _bufferOut;
        IntPtr _ptrBufferOut;

        public void Init(UInt64 baudrate, string intfName)
        {
            _sessionIn = new NiXnetSession(":memory:", "", Array.Empty<string>(), intfName, NiXnetMode.FrameInStream);
            _sessionIn.BaudRate64 = baudrate;
            _bufferIn = new nxFrame[100];
            GCHandle gchIn = GCHandle.Alloc(_bufferIn, GCHandleType.Pinned);
            _ptrBuffRIn = gchIn.AddrOfPinnedObject();


            _bufferOut = new nxFrame[2];
            _sessionOut = new NiXnetSession(":memory:", "", Array.Empty<string>(), intfName, NiXnetMode.FrameOutStream);
            _sessionOut.BaudRate64 = baudrate;
            GCHandle gchOut = GCHandle.Alloc(_bufferIn, GCHandleType.Pinned);
            _ptrBufferOut = gchOut.AddrOfPinnedObject();

        }

        public CanMsg[] ReadFrame()
        {
            UInt32 readBytes = 0;
            var frames = new CanMsg[0];

            unsafe
            {
                _sessionIn.ReadFrame((void*)_ptrBuffRIn, (uint)_bufferIn.Length * (uint)sizeof(nxFrame), 0, &readBytes);
                var framesCnt = readBytes / sizeof(nxFrame);
                frames = new CanMsg[framesCnt];

                for (int i = 0; i < framesCnt; i++)
                {
                    frames[i].Id = _bufferIn[i].Id;
                    frames[i].Length = _bufferIn[i].Length;
                    frames[i].Payload = _bufferIn[i].Payload;
                }

            }
            return frames;
        }

        public void WriteFrame(CanMsg[] frames)
        {
            if (frames.Length > _bufferOut.Length)
                throw new ApplicationException("XNET Buffer Out too small.");

            for (int i = 0; i < frames.Length; i++)
            {
                _bufferOut[i].Id = frames[i].Id;
                _bufferOut[i].Length = (byte)frames[i].Length;
                _bufferOut[i].Payload = frames[i].Payload;
            }

            unsafe
            {
                _sessionOut.WriteFrame((void*)_ptrBufferOut, (uint)frames.Length * (uint)sizeof(nxFrame), 10000);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _sessionIn.Dispose();
                _sessionOut.Dispose();

            }
            _disposed = true;
        }
    }
}
