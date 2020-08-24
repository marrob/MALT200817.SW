namespace MALT200817.Service.Xnet
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct nxFrame
    {
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Timestamp;
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Id;
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
    };
}
