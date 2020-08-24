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
    public class UnitTest_App
    {
        App _app;

        [SetUp]
        public void Start()
        {
            _app = new App();
            _app.Start();
        }

        [Test]
        public void SetOneRealy()
        {
            _app.TcpCommandLine("@03,#03,SET:04");
            System.Threading.Thread.Sleep(400);
        }


        [TearDown]
        public void Stop()
        {
            _app.Stop();
        }
        
    }
}
