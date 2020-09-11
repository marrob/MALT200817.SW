namespace MALT200817.Service
{
    using System;
    using System.ComponentModel;
    using MALT200817.Service.Xnet;
    using System.IO;
    using Devices;
    using MALT200817.Service.Common;
    using System.Threading;
    using Configuration;
    public class App
    {
        TcpService _tcpServer;
        TcpParser _tcpParser;
        CanService _canService;
        Explorer _exp;

        public App()
        {
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + "MALT200817.Service_" + DateTime.Now.ToString("yyMMdd_HHmmss")+".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogExplorerEnabled;
            AppLog.Instance.WriteLine("App()");
            
            _exp = new Explorer();
            _tcpParser = new TcpParser(_exp);
        }

        public void Start()
        {
            _tcpServer = new TcpService();
            _tcpServer.Completed += Server_Completed;
            _tcpServer.ParserCallback = _tcpParser.CommandLine;
            _tcpServer.Begin(null);
            if (AppConfiguration.Instance.CanBusInterfaceType.Trim().ToUpper() == "XNET")
            {
                var baudrate = AppConfiguration.Instance.CanBusBaudrate;
                var itfName = AppConfiguration.Instance.CanBusInterfaceName.Trim().ToUpper();
                var itf = new XnetInterface();
                itf.Init((UInt64)baudrate, itfName);
                _canService = new CanService(itf, _exp);
            }
            else if (AppConfiguration.Instance.CanBusInterfaceType.Trim().ToUpper() == "NICAN")
            {
                throw new ApplicationException("NICAN is not supported yet.");

            }
            else
            {
                throw new ApplicationException("CAN interface type is not supported.");
            }

            _canService.Begin(null);  
            AppLog.Instance.WriteLine("Service Started");
        }

        public void Stop()
        {
           // _tcpServer.Dispose();
            _canService.Dispose();

            AppLog.Instance.WriteLine("Service Stopped");
        }

        public string TcpCommandLine(string line)
        {
            return _tcpParser.CommandLine(line);
        }

        private static void Server_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Completed...");
            Console.WriteLine(e.Error);
        }
    }
}
