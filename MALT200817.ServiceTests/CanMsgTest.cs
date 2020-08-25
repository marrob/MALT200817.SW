
namespace MALT200817.Service.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MALT200817.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MALT200817.Service.Common;


    [TestClass()]
    public class CanMsgTest
    {
        [TestMethod()]
        public void TcpCommandLineTest()
        {
            var msg = new CanMsg();
            msg.SetPayload(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
        }

    }
}