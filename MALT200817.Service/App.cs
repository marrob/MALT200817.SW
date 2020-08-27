namespace MALT200817.Service
{
    using System;
    using System.ComponentModel;
    using MALT200817.Service.Xnet;
    using System.IO;
    using Devices;
    using MALT200817.Service.Common;
    using System.Threading;

    public class App
    {
        TcpService _tcpServer;
        TcpParser _tcpParser;
        CanService _canService;
        Explorer _exp;

        public App()
        {
            if (!File.Exists(AppConstants.AppConfigurationFilePath))
            {
                AppConfiguration.SaveToFile(AppConstants.AppConfigurationFilePath);
                new ApplicationException("Set the ConfigurationFile! " + AppConstants.AppConfigurationFilePath);
            }
            else
            {
                AppConfiguration.LoadFromFile(AppConstants.AppConfigurationFilePath);
            }
            AppLog.Instance.FilePath = AppConfiguration.Instance.AppLogPath;
            AppLog.Instance.Enabled = AppConfiguration.Instance.AppLogEnabled;
            AppLog.Instance.WirteLine("App()");
            
            _exp = new Explorer();
            _tcpParser = new TcpParser(_exp);
        }

        public void Start()
        {
            _tcpServer = new TcpService();
            _tcpServer.Completed += Server_Completed;
            _tcpServer.ParserCallback = _tcpParser.CommandLine;
            _tcpServer.Begin(null);
            if (AppConfiguration.Instance.CanInterfaceType.Trim().ToUpper() == "XNET")
            {
                var baudrate = AppConfiguration.Instance.Baudrate;
                var itfName = AppConfiguration.Instance.CanInterfaceName.Trim().ToUpper();
                var itf = new XnetInterface();
                itf.Init((UInt64)baudrate, itfName);
                _canService = new CanService(itf, _exp);
            }
            else if (AppConfiguration.Instance.CanInterfaceType.Trim().ToUpper() == "NICAN")
            {
                throw new ApplicationException("NICAN is not supported yet.");

            }
            else
            {
                throw new ApplicationException("CAN interface type is not supported.");
            }

            _canService.Begin(null);
            Thread.Sleep(500);
            _exp.RequestAllInitInfo();
            Thread.Sleep(500);
            _exp.RequestSaveCounters();
            
            AppLog.Instance.WirteLine("Service Started");
        }

        public void Stop()
        {
           // _tcpServer.Dispose();
            _canService.Dispose();

            AppLog.Instance.WirteLine("Service Stopped");
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
