namespace MALT200817.Service
{
    using System.ServiceProcess;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Security.Policy;
    using System.Text;
    using System.Threading.Tasks;
    using MALT200817.Service.Xnet;
    using System.IO;
    using System.Diagnostics;

    using Devices;
    using System.Net;
    using System.Dynamic;
    using System.Runtime.InteropServices.WindowsRuntime;
    using MALT200817.Service.Common;

    public class App
    {

        TcpService _tcpServer;
        TcpParser _tcpParser;
        CanService _canService;
        DeviceExplorer _devExp;

        public App()
        {
            _devExp = new DeviceExplorer();
            _tcpParser = new TcpParser(_devExp);
        }

        public void Start()
        {
            _tcpServer = new TcpService();
            _tcpServer.Completed += Server_Completed;
            _tcpServer.ParserCallback = _tcpParser.CommandLine;
            _tcpServer.Begin(null);


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
            


            if (AppConfiguration.Instance.CanInterfaceType.Trim().ToUpper() == "XNET")
            {
                var baudrate = AppConfiguration.Instance.Baudrate;
                var itfName = AppConfiguration.Instance.CanInterfaceName.Trim().ToUpper();
                var itf = new XnetInterface();
                itf.Init((UInt64)baudrate, itfName);
                _canService = new CanService(itf, _devExp);
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
            System.Threading.Thread.Sleep(500);
            _devExp.RequestAllInitInfo();
        }

        public void Stop()
        {
           // _tcpServer.Dispose();
            _canService.Dispose();
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
