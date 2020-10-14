namespace Konvolucio.MUDS150628.Xnet
{
    using System;
    using NiXnetDotNet;
    using System.Runtime.InteropServices;
 
    public class XnetInterface : IPhysicalLink, IDisposable
    {
        public bool ExtendedId { get; private set; }
        public string Interface { get; private set; }
        public bool IsConnected { get; private set; }
        public int TransmittId { get; private set; }
        public int ReceiveId { get; private set; }
        public int BaudRate { get; private set; }

        private NiXnetSession _sessionIn = null;
        XnetFrame[] _bufferIn;
        IntPtr _ptrBuffRIn;
        bool _disposed = false;


        private NiXnetSession _sessionOut = null;
        XnetFrame[] _bufferOut;
        IntPtr _ptrBufferOut;

        public XnetInterface(string canItfName, bool extid, int transmittId, int receiveId, int baudRate)
        {
            ExtendedId = extid;
            Interface = canItfName;
            TransmittId = transmittId;
            ReceiveId = receiveId;
            BaudRate = baudRate;
        }

        public void Open()
        {
            _sessionIn = new NiXnetSession(":memory:", "", Array.Empty<string>(), Interface, NiXnetMode.FrameInStream);
            _sessionIn.BaudRate64 = (ulong)BaudRate;
            _bufferIn = new XnetFrame[100];
            GCHandle gchIn = GCHandle.Alloc(_bufferIn, GCHandleType.Pinned);
            _ptrBuffRIn = gchIn.AddrOfPinnedObject();


            _bufferOut = new XnetFrame[2];
            _sessionOut = new NiXnetSession(":memory:", "", Array.Empty<string>(), Interface, NiXnetMode.FrameOutStream);
            _sessionOut.BaudRate64 = (ulong)BaudRate;
            GCHandle gchOut = GCHandle.Alloc(_bufferOut, GCHandleType.Pinned);
            _ptrBufferOut = gchOut.AddrOfPinnedObject();

            _sessionIn.Start(NiXnetScope.Normal);
            _sessionOut.Start(NiXnetScope.Normal);
        }

        public void Close()
        {
            Dispose();
        }

        public XnetFrame[] ReadFrame()
        {
            UInt32 readBytes = 0;
            var frames = new XnetFrame[0];

            unsafe
            {
                _sessionIn.ReadFrame((void*)_ptrBuffRIn, (uint)_bufferIn.Length * (uint)sizeof(XnetFrame), 0, &readBytes);
                var framesCnt = readBytes / sizeof(XnetFrame);
                frames = new XnetFrame[framesCnt];

                for (int i = 0; i < framesCnt; i++)
                {
                    frames[i].ArbitrationId = _bufferIn[i].ArbitrationId;
                    frames[i].Length = _bufferIn[i].Length;
                    frames[i].Payload = _bufferIn[i].Payload;
                }
            }
            return frames;
        }

        public void WriteFrame(XnetFrame[] frames)
        {
            if (frames.Length > _bufferOut.Length)
                throw new ApplicationException("XNET Buffer Out too small.");

            for (int i = 0; i < frames.Length; i++)
            {
                _bufferOut[i].ArbitrationId = frames[i].ArbitrationId;
                _bufferOut[i].Length = (byte)frames[i].Length;
                _bufferOut[i].Payload = frames[i].Payload;
            }

            unsafe
            {
                _sessionOut.WriteFrame((void*)_ptrBufferOut, (uint)frames.Length * (uint)sizeof(XnetFrame), 10000);
            }
        }

        public void Dispose()
        {
            _sessionIn.Stop(NiXnetScope.Normal);
            _sessionOut.Stop(NiXnetScope.Normal);
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

        public void Write(byte[] data)
        {
            XnetFrame niTx = new XnetFrame();
   
            if (ExtendedId)
                niTx.ArbitrationId = (uint)TransmittId | 0x20000000;
            else
                niTx.ArbitrationId = (uint)TransmittId;
            niTx.SetPayload(data);
            Log.WriteLine("Tx: 0x" + niTx.ArbitrationId.ToString("X4") + " " + Tools.ByteArrayToCStyleString(data));

            WriteFrame(new XnetFrame[] { niTx });
        }

        public byte[] Read(int tiemoutMs)
        {
            long startTick = DateTime.Now.Ticks;
            do
            {
                if (DateTime.Now.Ticks - startTick > tiemoutMs * 10000)
                    throw new Iso15765TimeoutException("P2 Max Expired,Read Timeout.");

                foreach (XnetFrame frame in ReadFrame())
                {
                    var data = frame.GetPayload();
                    Log.WriteLine("Rx: 0x" + frame.ArbitrationId.ToString("X4") + " " + "Data:" + Tools.ByteArrayToCStyleString(data));

                    if ((frame.ArbitrationId & 0x1FFFFFFF) == ReceiveId)
                        return data;
                }
            } while (true);
        }


        public void DeviceRestart(int address)
        {
            Log.WriteLine("Device restart, address:" + address); 

             var frame = new XnetFrame(); 
            frame.ArbitrationId = 0x1558FFFF | 0x20000000;
            frame.Length = 2;
            frame.SetPayload(new byte[] { 0xAA, (byte)address });
            WriteFrame(new XnetFrame[] { frame });
            Log.WriteLine("Tx: 0x" + frame.ArbitrationId.ToString("X4") + " "
                + Tools.ByteArrayToCStyleString(frame.GetPayload()));
        }
    }
}
