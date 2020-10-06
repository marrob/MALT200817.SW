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
        TcpService TcpServer;
        readonly TcpParser TcpParser;
        CanService CanService;
        readonly Explorer Explorer;
        DateTime StartTimestamp;

        public App()
        {
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + "MALT200817.Service_" + DateTime.Now.ToString("yyMMdd_HHmmss")+".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogServiceEnabled;
            AppLog.Instance.WriteLine("App");
            
            Explorer = new Explorer();
            TcpParser = new TcpParser(Explorer);
           
        }

        public void Start()
        {
            TcpServer = new TcpService();
            TcpServer.Completed += Server_Completed;
            TcpServer.ParserCallback = TcpParser.CommandLine;
            TcpServer.Begin(null);
            StartTimestamp = DateTime.Now;
              
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
                CanService = new CanService(itf, Explorer);
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
            CanService.Begin(null);
            AppLog.Instance.WriteLine("App:Start:DoUpdateDeviceInfo()");
            Explorer.DoUpdateDeviceInfo();
            AppLog.Instance.WriteLine("App:Start:Sequence complete...");
        }

        public void Stop()
        {
            AppLog.Instance.WriteLine("App:Stop: Start");
            AppLog.Instance.WriteLine("App:Stop: TCP Server Start Dispose.");

            TcpServer.Dispose();
            AppLog.Instance.WriteLine("App:Stop: TCP Server End Dispose.");
            
            AppLog.Instance.WriteLine("App:Stop: CAN Server Start Dispose.");
            CanService.Dispose();
            AppLog.Instance.WriteLine("App:Stop: CAN Server End Dispose.");

            var elapsed = DateTime.Now - StartTimestamp;

            AppLog.Instance.WriteLine("UpTime:" + elapsed.TotalHours + " hours");

            AppLog.Instance.WriteLine("App:Stop: Stop sequence complete... Bye");
        }

        public string TcpCommandLine(string line)
        {
            return TcpParser.CommandLine(line);
        }

        private static void Server_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("App:Completed...");
            Console.WriteLine(e.Error);
        }
    }
}
