

namespace MALT200817.Service.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Devices;
    using Common;
    using Service;

    [TestClass()]
    public class TcpParserTest
    {

        [TestMethod()]
        public void FirstCommand()
        {
            var parse = new TcpParser(null);
            parse.CommandLine("@05:01:SET#ONE:01");
        }

        [TestMethod()]
        public void Command_SetOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03:05:SET#ONE:04");

            Assert.AreEqual(
            Tools.ConvertByteArrayToCStyleString(new byte[] { 0x03, 0x01, 0x03, 0x01 }),
            Tools.ConvertByteArrayToCStyleString(devExp.TxQueue.Dequeue().GetPayload()));
        }

        [TestMethod()]
        public void Command_SetOnePortZero()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03:05:SET#ONE:00");

            Assert.AreEqual(
            Tools.ConvertByteArrayToCStyleString(new byte[] { 0x03, 0x01, 0x00, 0x01 }),
            Tools.ConvertByteArrayToCStyleString(devExp.TxQueue.Dequeue().GetPayload()));
        }


        [TestMethod()]
        public void Command_SetSeveral()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03:05:SET#SEVERAL:01000000:00");
            Assert.AreEqual(
                Tools.ConvertByteArrayToCStyleString(new byte[] { 0x03, 0x03, 0x01, 0x00, 0x00, 0x00, 0x01 }),
                Tools.ConvertByteArrayToCStyleString(devExp.TxQueue.Dequeue().GetPayload()));
        }

        [TestMethod()]
        public void Command_GetSeveral()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0x03, 0x04, 0x01, 0x00, 0x00, 0x00, 0x00 }));
            Assert.AreEqual(parse.CommandLine("@03:0A:GET#SEVERAL:00"), "@03:0A:STA:0100000:00");

        }

        [TestMethod()]
        public void Command_DeviceUnknownCommand()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            Assert.AreEqual(parse.CommandLine("@03:05:SET#ONEXYZ:04"), "!UNKNOWN DEVICE COMMAND: 'SET#ONEXYZ'");

        }

        [TestMethod()]
        public void Command_ClrOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            Assert.AreEqual(parse.CommandLine("@03:05:CLR#ONE:04"), "OK");
            var msg = devExp.TxQueue.Dequeue();
        }

        [TestMethod()]
        public void Command_GetOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0x03, 0x04, 0x01, 0x00, 0x00, 0x00, 0x00 }));
            Assert.AreEqual(parse.CommandLine("@03:0A:GET#ONE:01"), "@03:0A:STA:01:SET");
        }

        [TestMethod()]
        public void Command_GetDevices()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030B, new byte[] { 0xF0, 0x01, 0x03, 0x0B, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030C, new byte[] { 0xF0, 0x01, 0x03, 0x0C, 0x00, 0x9A, 0x00 }));

            var devices = parse.CommandLine("GET#DEVICES");
        }

    }
}