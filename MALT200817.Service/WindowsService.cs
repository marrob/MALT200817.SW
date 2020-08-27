namespace MALT200817.Service
{
    using System.ServiceProcess;
    using System.Diagnostics;

    public partial class WindowsService : ServiceBase
    {

         App _myApp;
        private EventLog eventLog1 = new EventLog();

        public WindowsService()
        {
            InitializeComponent();
            LogInit();
            _myApp = new App();

        }

        protected override void OnStart(string[] args)
        {
            _myApp.Start();
            eventLog1.WriteEntry("OnStart");
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("OnStop");
        }

        void LogInit()
        {
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }

        public void OnDebug()
        {
             _myApp.Start();
        }
    }
}
