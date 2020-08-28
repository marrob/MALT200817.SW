

namespace MALT200817.Service.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MALT200817.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MALT200817.Service.Devices;
    using MALT200817.Service.Common;

    [TestClass()]
    public class TcpParserTest
    {

        [TestMethod()]
        public void FirstCommand()
        {
            var parse = new TcpParser();
            parse.CommandLine("@05:01:SET:01");
        }

        [TestMethod()]
        public void Command_RequestSetOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03:05:SET:04");
            CollectionAssert.AreEqual(new byte[] { 0x03, 0x01, 0x04, 0x01 }, devExp.TxQueue.Dequeue().GetPayload());
        }


        [TestMethod()]
        public void Command_RequestSetSeveral()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03:05:SET:01000000");
            var txpayoload = devExp.TxQueue.Dequeue().GetPayload();
            CollectionAssert.AreEqual(new byte[] { 0x03, 0x03, 0x01, 0x00, 0x00, 0x00, 0x01 }, txpayoload);
        }

        [TestMethod()]
        public void Command_RequestClrOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            Assert.AreEqual(parse.CommandLine("@03:05:CLR:04"), "OK");
            var msg = devExp.TxQueue.Dequeue();
        }

        [TestMethod()]
        public void Command_RequestGetOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0x03, 0x04, 0x01, 0x00, 0x00, 0x00, 0x00 }));
            Assert.AreEqual(parse.CommandLine("@03:0A:GET:01"), "@03:0A:STA:01:SET");
        }

        [TestMethod()]
        public void Command_GetDevices()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030B, new byte[] { 0xF0, 0x01, 0x03, 0x0B, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030C, new byte[] { 0xF0, 0x01, 0x03, 0x0C, 0x00, 0x9A, 0x00 }));

            var devices = parse.CommandLine("GET:DEVICES");



        }

    }
}