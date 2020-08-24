namespace MALT200817.Service.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MALT200817.Service.Devices;
    using NUnit.Framework;


    [TestFixture]
    public class UnitTest_TcpParser
    {
        [Test]
        public void FirstTest()
        {
            var parse = new TcpParser();
            parse.Parse("@05,#01,SET:01");
        }

        [Test]
        public void WriteAppConfiguration()
        {
            var devExp = new DeviceExplorer();
            var parse = new TcpParser(devExp);
            parse.Parse("@03,#05,SET:04");
        }
    }
}
