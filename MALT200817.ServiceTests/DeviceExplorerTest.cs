
namespace MALT200817.Service.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MALT200817.Service.Devices;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MALT200817.Service.Common;


    [TestClass()]
    public class DeviceExplorerTest
    {
        [TestMethod()]
        public void TcpCommandLineTest()
        {
            var exp = new DeviceExplorer();
            var msg = new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 });
            exp.FramesIn(msg);
        }

    }
}