namespace MALT200817.Service
{
    using System.ServiceProcess;
    using System.Diagnostics;
    using System;

    public partial class WindowsService : ServiceBase
    {

        App _myApp;

#if !DEBUG
        private EventLog eventLog1 = new EventLog();
#endif
        public WindowsService()
        {
            InitializeComponent();
#if !DEBUG
            LogInit();
#endif
            _myApp = new App();

         

        }

        protected override void OnStart(string[] args)
        {
            _myApp.Start();
#if !DEBUG
            eventLog1.WriteEntry("OnStart");
#endif
        }

        protected override void OnStop()
        {
            _myApp.Stop();
#if !DEBUG
            eventLog1.WriteEntry("OnStop");
#endif
        }
#if !DEBUG
        void LogInit()
        {
            if (!System.Diagnostics.EventLog.SourceExists("MySource"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
        }
#endif

        public void OnDebug()
        {
             _myApp.Start();
        }
    }
        
}
