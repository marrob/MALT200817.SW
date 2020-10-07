using System;

namespace Konvolucio.MUDS150628
{
    public interface IPhysicalLink
    {
        void Write(byte[] data);
        byte[] Read(int tiemoutMs);
    }
}
