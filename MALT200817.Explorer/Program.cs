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
        readonly IMainForm MainForm;
        readonly DevicePresenter DevicePresenter;
        public static SynchronizationContext SyncContext = null;
        readonly System.Windows.Forms.Timer Timer;
        public static string Name = "MALT Explorer";
        public static UserItem CurrentUser;

        public App()
        {

            /*** Application Configuration ***/
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + @"//MALT200817.Explorer_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogExplorerEnabled;
            AppLog.Instance.WriteLine("MALT200817.Explorer.App() Constructor started.");

            /*** Main Form ***/
            MainForm = new MainForm();
            MainForm.Text = Name + " - " + Application.ProductVersion;
            MainForm.Shown += MainForm_Shown;
            MainForm.FormClosing += MainForm_FormClosing;
            MainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            MainForm.Login += MainForm_Login;
            

            /*** MALT TCP Client ***/
            DevicePresenter = new DevicePresenter(MainForm.DevicesDgv);

            /*** Device Library ***/
            Devices.Library.LoadLibrary(AppConstants.LibraryDirectory);

            Timer = new System.Windows.Forms.Timer();
            Timer.Interval = 1000;
            Timer.Tick += Check_Tick;

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
                     new Commands.DevicesForceUpdateCommand(this),
                     new Commands.AlwaysOnTopCommand(MainForm as Form),
                 });

            MainForm.MenuBar = new ToolStripItem[]
                {
                    new Commands.HelpCommand(),
                    new Commands.DevicesConnectCommand(this),
                    toolsMenu,
                    diagMenu,
                };

            MainForm.Version = typeof(Program).Assembly.GetName().Version.ToString();


            /*** Default User ***/
            EventAggregator.Instance.Subscribe((Action<UserChangedAppEvent>) (e1 =>
            {
                MainForm.Text = Name + " - " + e1.User.Name;
                App.CurrentUser = new UserItem();
                App.CurrentUser.Name = e1.User.Name;
                App.CurrentUser.Role = e1.User.Role;
                App.CurrentUser.Password = e1.User.Password;
            }));

            /*** Run ***/
            Application.Run((MainForm)MainForm);

        }

        private void MainForm_Login(object sender, EventArgs e)
        {
            new UserLoginForm().ShowDialog();
        }

        private void Check_Tick(object sender, EventArgs e)
        { 
            var sc = new ServiceController(AppConstants.WindowsServiceName);
            MainForm.ServiceStatus = sc.Status.ToString();

            if(AppConfiguration.Instance.ExplorerDeviceListAutoUpdate)
                if(MaltClient.Instance.IsConnected)
                    UpdateDeviceList();
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
            SyncContext = SynchronizationContext.Current;
 

            /*** Check Service Running Or Not ***/
            if (!Tools.DoesServiceExist(AppConstants.WindowsServiceName))
            {
                throw new ApplicationException("AltonTech MALT200817.Service('MaltService') is not installed. Please install it.");
            }
            else
            {
                Timer.Start();
                var sc = new ServiceController(AppConstants.WindowsServiceName);
                if (sc.Status != ServiceControllerStatus.Running)
                {
                    var yesno = MessageBox.Show("AltonTech MALT200817.Service('MaltService') is not running, it is required for normal operation. Would you like start it?",
                        "AltonTech MALT200817.Service not running! ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (yesno == DialogResult.Yes)
                    {
                        var msg = "service starting";
                        AppLog.Instance.WriteLine(msg);
                        sc.Start();
                        AppLog.Instance.WriteLine("service is running");
                        Thread.Sleep(2000);
                    }
                }
            }

            /*Ö tölti be a projectet*/
            EventAggregator.Instance.Publish(new ShowAppEvent());

            /*** Default User ***/
            var defUsr = AppConfiguration.Instance.Users.FirstOrDefault(n => n.Name == AppConfiguration.Instance.DefaultUserName);
            if (defUsr != null)
            {
                EventAggregator.Instance.Publish(new UserChangedAppEvent(defUsr));
            }
            else
            {
                var jonDoe = new UserItem() { Name = "Jhon Doe", Role = UserRole.OPERATOR, Password = "" };
                EventAggregator.Instance.Publish(new UserChangedAppEvent(jonDoe));
            }


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
            var devices = MaltClient.Instance.GetDevices();
            MainForm.DevicesCount = devices.Count.ToString();
            DevicePresenter.Update(devices);
            sp.Stop();
            MainForm.ConnectionTime = sp.ElapsedMilliseconds.ToString() + "ms";
        }


        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Timer.Stop();
            MaltClient.Instance.Dispose();
            Settings.Default.Save();
            EventAggregator.Instance.Dispose();
            Settings.Default.Save();
            AppLog.Instance.WriteLine("MALT200817.Explorer.App() MainForm_FormClosed.");
        }
    }
}
