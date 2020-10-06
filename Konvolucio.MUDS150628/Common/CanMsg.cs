namespace Konvolucio.MUDS150628.Common
{
    using System;

    public struct CanMsg
    {
        public UInt32 Id;
        public int Length;
        public UInt64 Payload;

        public CanMsg(UInt32 id, byte[] payload)
        {
            Id = id;
            Length = 0;
            Payload = 0;
            SetPayload(payload);
        }

        public void SetPayload(byte[] data)
        {
            Payload = 0;
            for (int i = 0; i < data.Length; i++)
                Payload |= (ulong)data[i] << (i * 8);
            Length = data.Length;
        }

        public byte[] GetPayload()
        {
            var data = new byte[Length];
            for (int i = 0; i < Length; i++)
                data[i] = (byte)(Payload >> (i * 8));
            return data;
        }
    }
}