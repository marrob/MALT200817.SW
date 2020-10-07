namespace Konvolucio.MUDS150628.Xnet
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct XnetFrame
    {
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Timestamp;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 ArbitrationId;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Type;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Flags;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Info;
        [MarshalAs(UnmanagedType.U1)]
        public Byte Length;
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Payload;


        public void SetPayload(byte[] data)
        {
            Payload = 0;
            for (int i = 0; i < data.Length; i++)
                Payload |= (ulong)data[i] << (i * 8);
            Length = (byte)data.Length;
        }

        public byte[] GetPayload()
        {
            var data = new byte[Length];
            for (int i = 0; i < Length; i++)
                data[i] = (byte)(Payload >> (i * 8));
            return data;
        }
    };
}
