

namespace MALT200817.Explorer
{
    using System;
    using System.Windows.Forms;
    using Common;
    using View;
    using System.Reflection;
    using System.Threading;
    using Events;
    using Properties;
    using Client;
    using Configuration;
    using Library;
    using ErrorHandling;
    using System.Net.Configuration;
    using System.Diagnostics;

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
        void Connect();
        void Disconnect();
        void UpdateDeviceList();
    }

    class App : IApp
    {
        readonly IMainForm _mainForm;
        readonly DevicePresenter _devicePresenter;
        public static SynchronizationContext SyncContext = null;

        public App()
        {

            /*** Application Configuration ***/
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + @"MALT200817.Explorer_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.LogExplorerEnabled;
            AppLog.Instance.WriteLine("MALT200817.Explorer.App() Constructor started.");

            /*** Main Form ***/
            _mainForm = new MainForm();
            _mainForm.Text = "MALT Explorer"+ " - " + Application.ProductVersion;
            _mainForm.Shown += MainForm_Shown;
            _mainForm.FormClosing += MainForm_FormClosing;
            _mainForm.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            /*** MALT TCP Client ***/
            _devicePresenter = new DevicePresenter(_mainForm.DevicesDgv);

            /*** Device Library ***/
            Devices.Library.LoadLibrary(AppConstants.LibraryDirectory);


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

            /*** Run ***/
            Application.Run((MainForm)_mainForm);
        }


        void MainForm_Shown(object sender, EventArgs e)
        {
#if TRACE
            AppLog.Instance.WriteLine(GetType().Namespace + "." + GetType().Name + "." + MethodBase.GetCurrentMethod().Name + "()");
#endif

            SyncContext = SynchronizationContext.Current;
            // _mainForm.LayoutRestore();

            //_mainForm.LayoutRestore();
            /*Ö tölti be a projectet*/
            Start(Environment.GetCommandLineArgs());
            /*Kezdő Node Legyen az Adapter node*/
            //EventAggregator.Instance.Publish<TreeViewSelectionChangedAppEvent>(new TreeViewSelectionChangedAppEvent(_startTreeNode));

            EventAggregator.Instance.Publish(new ShowAppEvent());

            // if (Settings.Default.PlayAfterStartUp)
            //_ioService.Play();
        }

        public void Start(string[] args)
        {
            Connect();
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
        }

        public void Connect()
        {
            MaltClient.Instance.Start("", AppConfiguration.Instance.ServicePort);
        }

        public void Disconnect()
        {
            MaltClient.Instance.Dispose();
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
