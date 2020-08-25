using Microsoft.VisualStudio.TestTools.UnitTesting;
using MALT200817.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MALT200817.Service.Tests
{
    [TestClass()]
    public class AppTests
    {
       static App _app = new App();


        [TestInitialize()]          
        public void SetUp()
        {
            _app.Start();

        }
        [TestMethod()]
        public void RequestOnOne()
        {
            _app.TcpCommandLine("@03#03SET04");
            System.Threading.Thread.Sleep(400);
        }


        [ClassCleanup()]
        public static void CelanUp()
        { 
            _app.Stop();
        }
    }
}