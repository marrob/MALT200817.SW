

namespace MALT200817.Service.NiCan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Common;

    public class NiCanInterface : ICanInterface
    {
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Init(ulong baudrate, string intfName)
        {
            throw new NotImplementedException();
        }

        public CanMsg[] ReadFrame()
        {
            throw new NotImplementedException();
        }

        public void WriteFrame(CanMsg[] frames)
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        void ICanInterface.Init(ulong baudrate, string intfName)
        {
            throw new NotImplementedException();
        }

        CanMsg[] ICanInterface.ReadFrame()
        {
            throw new NotImplementedException();
        }

        void ICanInterface.WriteFrame(CanMsg[] frames)
        {
            throw new NotImplementedException();
        }
    }

}
