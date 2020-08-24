namespace MALT200817.Service.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;


    [TestFixture]
    public class UnitTest_AppConfig
    {
        [Test]
        public void FirstTest()
        {
            Console.WriteLine("Hello World");
        }

        [Test]
        public void WriteAppConfiguration()
        {    
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TEST_config.xml";
            File.Delete(path);
            AppConfiguration.SaveToFile(path);
            FileAssert.Exists(path);
        }

        [Test]
        public void AppSet()
        {
            var app = new App();
            app.Start();
            app.TcpCommandLine("@03,#05,SET:04");

        }
    }
}
