namespace MALT200817.Explorer
{
    using System;
    using System.Windows.Forms;
    using Common;
    using View;
    using System.Threading;
    using Events;
    using Properties;
    using Client;
    using Configuration;
    using Library;
    using ErrorHandling;
    using System.Diagnostics;
    using System.ServiceProcess;
    using System.Linq;
    using System.Reflection;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

#if !DEBUG
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ApplicationOnThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
#endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new App();
        }
        private static void CurrentDomainOnUnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            var x = new ErrorHandlerService();
            AppLog.Instance.WriteLine(x.Show(e));
        }
        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var x = new ErrorHandlerService();
            AppLog.Instance.WriteLine(x.Show(e));
        }
    }

    public interface IApp
    {
        void UpdateDeviceList();
    }

    class App : IApp
    {
        readonly IMainForm _mainForm;
        readonly DevicePresenter _devicePresenter;
        public static SynchronizationContext SyncContext = null;
        readonly System.Windows.Forms.Timer _timer;
        public static string Name = "MALT Explorer";

        public App()
        {

            /*** Application Configuration ***/
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + @"MALT200817.Explorer_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogExplorerEnabled;
            AppLog.Instance.WriteLine("MALT200817.Explorer.App() Constructor started.");


            /*** Main Form ***/
            _mainForm = new MainForm();
            _mainForm.Text = Name + " - " + Application.ProductVersion;
            _mainForm.ConnectionStatus = "Disconnected";
            _mainForm.Shown += MainForm_Shown;
            _mainForm.FormClosing += MainForm_FormClosing;
            _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            _mainForm.Login += MainForm_Login;

            /*** MALT TCP Client ***/
            _devicePresenter = new DevicePresenter(_mainForm.DevicesDgv);

            /*** Device Library ***/
            Devices.Library.LoadLibrary(AppConstants.LibraryDirectory);

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000;
            _timer.Tick += Check_Tick;

            var diagMenu = new ToolStripMenuItem("Diag");
            diagMenu.DropDown.Items.AddRange(
                 new ToolStripItem[]
                 {
                     new Commands.ShowConfigurationCommand(),
                     new Commands.ShowLogFolderCommand(),
                     new Commands.ShowLibraryFolderCommand(),
                     new Commands.ShowServicesCommand()
                 });

            var toolsMenu = new ToolStripMenuItem("Tools");
            toolsMenu.DropDown.Items.AddRange(
                 new ToolStripItem[]
                 {
                     new Commands.DevicesConnectCommand(this),
                     new Commands.DevicesForceUpdateCommand(this),
                     new Commands.AlwaysOnTopCommand(_mainForm as Form),
                 });

            _mainForm.MenuBar = new ToolStripItem[]
                {
                    toolsMenu,
                //    viewMenu,
                    diagMenu,
                };

            _mainForm.Version = typeof(Program).Assembly.GetName().Version.ToString();

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e1 =>
            {
                if (e1.IsConnected)
                    _mainForm.ConnectionStatus = "Connected";
                else
                    _mainForm.ConnectionStatus = "Disconnected";
            }));

            /*** Default User ***/
            EventAggregator.Instance.Subscribe((Action<UserChangedAppEvent>) (e1 =>
            {
                _mainForm.Text = Name + " - " + e1.User.Name;
            }));

            /*** Run ***/
            Application.Run((MainForm)_mainForm);

        }

        private void MainForm_Login(object sender, EventArgs e)
        {
            new UserLoginForm().ShowDialog();
        }

        private void Check_Tick(object sender, EventArgs e)
        { 
            var sc = new ServiceController(AppConstants.WindowsServiceName);
            _mainForm.ServiceStatus = sc.Status.ToString();
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif

            SyncContext = SynchronizationContext.Current;
            _mainForm.ProcessStatusUpdate(string.Empty, false);
           

            // _mainForm.LayoutRestore();

            /*** Check Service Running Or Not ***/
            if (!Tools.DoesServiceExist(AppConstants.WindowsServiceName))
            {
                throw new ApplicationException("AltonTech MALT200817.Service('MaltService') is not installed. Please install it.");
            }
            else
            {
                _timer.Start();
                var sc = new ServiceController(AppConstants.WindowsServiceName);
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    var yesno = MessageBox.Show("AltonTech MALT200817.Service('MaltService') is not running, it is required for normal operation. Would you like start it?",
                        "AltonTech MALT200817.Service not running! ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (yesno == DialogResult.Yes)
                    {
                        var msg = "service starting";
                        _mainForm.ProcessStatusUpdate(msg, true);
                        AppLog.Instance.WriteLine(msg);
                        sc.Start();
                        AppLog.Instance.WriteLine("service is running");
                        _mainForm.ProcessStatusUpdate("", false);
                        Thread.Sleep(2000);
                    }
                }
            }

            //_mainForm.LayoutRestore();
            /*Ö tölti be a projectet*/
    
            EventAggregator.Instance.Publish(new ShowAppEvent());
            var defUsr = AppConfiguration.Instance.Users.FirstOrDefault(n => n.Name == AppConfiguration.Instance.DefaultUserName);
            if (defUsr != null)
                EventAggregator.Instance.Publish(new UserChangedAppEvent(defUsr));           
            
            Start(Environment.GetCommandLineArgs());
        }

        public void Start(string[] args)
        {
            new Commands.DevicesConnectCommand(this).PerformClick();
            UpdateDeviceList();
        }

        public void UpdateDeviceList()
        {
            var sp = new Stopwatch();
            sp.Start();
            MaltClient.Instance.UpdateDevicesInfo();
            var devices = MaltClient.Instance.GetDevices();
            _mainForm.DevicesCount = devices.Count.ToString();
            _devicePresenter.Update(devices);
            sp.Stop();
            _mainForm.ConnectionTime = sp.ElapsedMilliseconds.ToString() + "ms";
            AppLog.Instance.WriteLine("UpdateDeviceList:" + _mainForm.ConnectionTime);
        }


        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }



        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            MaltClient.Instance.Dispose();

            //TimerService.Instance.Dispose();
            //  _ioService.Dispose();
            //   _mainForm.LayoutSave();
            Settings.Default.Save();
            EventAggregator.Instance.Dispose();
            Settings.Default.Save();

            AppLog.Instance.WriteLine("MALT200817.Explorer.App() MainForm_FormClosed.");
        }
    }
}
