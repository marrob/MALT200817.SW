
namespace Konvolucio.MUDS150628.NiCanApi
{
    using System;

    public class NiCanInterface : IPhysicalLink, IDisposable
    {

        uint Handle = 0;

        public bool ExtendedId { get; private set; }
        public string Interface { get; private set; }
        public bool IsConnected { get; private set; }
        public int TransmittId { get; private set; }
        public int ReceiveId { get; private set; }
        public int BaudRate { get; private set; }
    
        bool _disposed = false;

        public NiCanInterface(string canItf, bool extid, int transmittId, int receiveId, int baudRate)
        {
            ExtendedId = extid;
            Interface = canItf;
            TransmittId = transmittId;
            ReceiveId = receiveId;
            BaudRate = baudRate;
        }

        public NiCanInterface(string canItf, int baudRate)
        {
            Interface = canItf;
            BaudRate = baudRate;
        }

        public void Disconnect()
        {

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                NiCanTools.Close(Handle);
            }
            _disposed = true;
        }

        public void Reset()
        {

        }

        public void Open()
        {
            Handle = NiCanTools.Open(Interface, BaudRate);
            IoLog.Instance.WriteLine("Open");
        }

        public void Close()
        {
            NiCanTools.Close(Handle);
            IoLog.Instance.WriteLine("Close");
        }
        public void Write(byte[] data)
        {
            var niTx = new NiCan.NCTYPE_CAN_FRAME();
            if (ExtendedId)
                niTx.ArbitrationId = (UInt32)TransmittId | 0x20000000;
            else
                niTx.ArbitrationId = (UInt32)TransmittId;
            niTx.DataLength = 8;
            niTx.IsRemote = NiCan.NC_FALSE;
            niTx.Data0 = data[0];
            niTx.Data1 = data[1];
            niTx.Data2 = data[2];
            niTx.Data3 = data[3];
            niTx.Data4 = data[4];
            niTx.Data5 = data[5];
            niTx.Data6 = data[6];
            niTx.Data7 = data[7];
            NiCan.ncWrite(Handle, NiCan.CanFrameSize, ref niTx);
            IoLog.Instance.WriteLine("Tx: 0x" + niTx.ArbitrationId.ToString("X4") + " " + Tools.ByteArrayToCStyleString(data));
        }

        public byte[] Read(int tiemoutMs)
        {
            int items = 0;
            long startTick = DateTime.Now.Ticks;
            byte[] data = null;
            var rx = new NiCan.NCTYPE_CAN_STRUCT();
            bool isFound = false;
            do
            {
                if (DateTime.Now.Ticks - startTick > tiemoutMs * 10000)
                    throw new Iso15765TimeoutException("P2 Max Expired,Read Timeout.");

                items = NiCanTools.ReadPending(Handle);
                if (items != 0)
                {
                    for (int i = 0; i < items; i++)
                    {
                        NiCanTools.NiCanStatusCheck(NiCan.ncRead(Handle, NiCan.CanStructSize, ref rx));
                        UInt32 arbId = rx.ArbitrationId & 0x1FFFFFFF;
                        byte[] datatemp = new byte[]
                        {   rx.Data0,
                            rx.Data1,
                            rx.Data2,
                            rx.Data3,
                            rx.Data4,
                            rx.Data5,
                            rx.Data6,
                            rx.Data7, };
                        data = new byte[rx.DataLength];
                        Buffer.BlockCopy(datatemp, 0, data, 0, rx.DataLength);
                        IoLog.Instance.WriteLine("Rx: 0x" + arbId.ToString("X4") + " " + "Data:" + Tools.ByteArrayToCStyleString(data));
                        if (arbId == ReceiveId)
                        {
                            isFound = true;
                        }
                    }
                }

            } while (!isFound);

            return data;
        }

        public void DeviceRestart(int address)
        {
            IoLog.Instance.WriteLine("Restart Module:" + address);
            var niTx = new NiCan.NCTYPE_CAN_FRAME();
            niTx.ArbitrationId = 0x1558FFFF | 0x20000000;
            niTx.DataLength = 2;
            niTx.IsRemote = NiCan.NC_FALSE;
            niTx.Data0 = 0xAA;
            niTx.Data1 = (byte)address;
            NiCan.ncWrite(Handle, NiCan.CanFrameSize, ref niTx);
            IoLog.Instance.WriteLine("Tx: 0x" + niTx.ArbitrationId.ToString("X4") + " "
                + Tools.ByteArrayToCStyleString(new byte[] { niTx.Data0, niTx.Data1 }));
        }

    }
}
