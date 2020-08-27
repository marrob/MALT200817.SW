

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
            parse.CommandLine("@05#01SET01");
        }

        [TestMethod()]
        public void Command_RequestSetOne()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            parse.CommandLine("@03#05SET04");
        }

        [TestMethod()]
        public void Command_GetDevices()
        {
            var devExp = new Explorer();
            var parse = new TcpParser(devExp);
            devExp.FramesIn(new CanMsg(0x1552030A, new byte[] { 0xF0, 0x01, 0x03, 0x0A, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030B, new byte[] { 0xF0, 0x01, 0x03, 0x0B, 0x00, 0x9A, 0x00 }));
            devExp.FramesIn(new CanMsg(0x1552030C, new byte[] { 0xF0, 0x01, 0x03, 0x0C, 0x00, 0x9A, 0x00 }));

                var devices = parse.CommandLine("GET-DEVICES");



        }

    }
}