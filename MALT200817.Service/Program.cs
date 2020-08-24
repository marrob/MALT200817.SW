
namespace MALT200817.Service
{
    using System.ServiceProcess;

    class Program
    {
        //static void Main(string[] args)
        //{
        //    new App();
        //}


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      
        static void Main()
        {

            App _app;
            _app = new App();
            _app.Start();
            _app.TcpCommandLine("@03,#03,SET:04");
            _app.TcpCommandLine("@03,#03,SET:01");
            _app.TcpCommandLine("@03,#03,SET:02");
            _app.TcpCommandLine("@03,#03,SET:03");
            _app.TcpCommandLine("@03,#03,SET:04");
            _app.TcpCommandLine("@03,#03,SET:05");
            System.Threading.Thread.Sleep(400);
            _app.Stop();
            System.Threading.Thread.Sleep(1000);

            /*

#if DEBUG
            WindowsService service = new WindowsService();
            service.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#else
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new WindowsService()
			};
            ServiceBase.Run(ServicesToRun);
#endif


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WindowsService()
            };
            ServiceBase.Run(ServicesToRun);*/
        }
    }
    

  
}
