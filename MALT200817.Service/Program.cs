
namespace MALT200817.Service
{
    using System.ServiceProcess;

    class Program
    {
     
        static void Main()
        {


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
            ServiceBase.Run(ServicesToRun);
        }
    }
    

  
}
