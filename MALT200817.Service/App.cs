namespace MALT200817.Service
{
    using System;
    using System.ComponentModel;
    using Xnet;
    using Common;
    using Configuration;
    using Library;
    using System.IO;

    public class App
    {
        TcpService _tcpServer;
        readonly TcpParser _tcpParser;
        CanService _canService;
        readonly Explorer _exp;

        public App()
        {
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + "MALT200817.Service_" + DateTime.Now.ToString("yyMMdd_HHmmss")+".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogServiceEnabled;
            AppLog.Instance.WriteLine("App");
            
            _exp = new Explorer();
            _tcpParser = new TcpParser(_exp);
        }

        public void Start()
        {
            _tcpServer = new TcpService();
            _tcpServer.Completed += Server_Completed;
            _tcpServer.ParserCallback = _tcpParser.CommandLine;
            _tcpServer.Begin(null);
              
            /*** Device Lib ***/
            Devices.Library.LoadLibrary(AppConstants.LibraryDirectory);
            AppLog.Instance.WriteLine("App:Start:LibraryDirectory:Exists:" + Directory.Exists(AppConstants.LibraryDirectory).ToString());
            AppLog.Instance.WriteLine("App:Start:LibraryDirectory:Exists:" + Devices.Library.Count.ToString());

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
                AppLog.Instance.WriteLine("App:Start: NICAN is not supported yet.");
                throw new ApplicationException("App:Start: NICAN is not supported yet.");

            }
            else
            {
                AppLog.Instance.WriteLine("Start CAN interface type is not supported.");
                throw new ApplicationException("Start CAN interface type is not supported.");
            }

            AppLog.Instance.WriteLine("App:Start:canService.Begin()");
            _canService.Begin(null);
            AppLog.Instance.WriteLine("App:Start:DoUpdateDeviceInfo()");
            _exp.DoUpdateDeviceInfo();
            AppLog.Instance.WriteLine("App:Start:Sequence complete...");
        }

        public void Stop()
        {
            AppLog.Instance.WriteLine("App:Stop: Start");
            AppLog.Instance.WriteLine("App:Stop: TCP Server Start Dispose.");

            _tcpServer.Dispose();
            AppLog.Instance.WriteLine("App:Stop: TCP Server End Dispose.");
            
            AppLog.Instance.WriteLine("App:Stop: CAN Server Start Dispose.");
            _canService.Dispose();
            AppLog.Instance.WriteLine("App:Stop: CAN Server End Dispose.");

            AppLog.Instance.WriteLine("App:Stop: Stop sequence complete... Bye");
        }

        public string TcpCommandLine(string line)
        {
            return _tcpParser.CommandLine(line);
        }

        private static void Server_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("App:Completed...");
            Console.WriteLine(e.Error);
        }
    }
}
