

namespace MALT200817.Service.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MALT200817.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    [TestClass()]
    public class AppTesAppConfigTestts
    {

        [TestMethod()]
        public void RequestOnOne()
        {

        }
        [TestMethod()]
        public void FirstTest()
        {
            Console.WriteLine("Hello World");
        }

        [TestMethod()]
        public void WriteAppConfiguration()
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TEST_config.xml";
            File.Delete(path);
            AppConfiguration.SaveToFile(path);
            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod()]
        public void AppSet()
        {
            var app = new App();
            app.Start();
            app.TcpCommandLine("@03:05:SET:04");

        }

    }
}