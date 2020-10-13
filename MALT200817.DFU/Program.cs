
namespace MALT200817.DFU
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Threading;
    using Properties;
    using System.Diagnostics;
    using Konvolucio.MUDS150628;
    using Konvolucio.MUDS150628.NiCanApi;
    using Configuration;
    using Common;
    using Konvolucio.MUDS150628.Xnet;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run((MainForm)new App().MainForm);
        }
    }

    public enum ConnectionStatusTypes
    { 
        Connected,
        PressToConnect
    }

    class App
    {
        public static SynchronizationContext SyncContext = null;

        public IMainForm MainForm { get; set; }
        string _firmwareFilePath { get; set; }

        NiCanInterface _niCanLink;
        XnetInterface _xnetLink;
        
        public App()
        {

            /*** Application Configuration ***/
            AppConfiguration.Init();
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + @"MALT200817.DFU_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.DfuApp.LogEnable;
            AppLog.Instance.WriteLine("MALT200817.DFU.App() Constructor started.");


            MainForm = new MainForm();
            MainForm.Text = "MALT200817 - DFU";
            MainForm.Version = Application.ProductVersion;
            MainForm.ConnectionStatus = ConnectionStatusTypes.PressToConnect;
            MainForm.FileBrowseEventHandler += ButtonBrowse_Click;
            MainForm.FormClosed += MainForm_FormClosed;
            MainForm.WriteEventHandler += ButtonWrite_Click;
            MainForm.Shown += MainForm_Shown;
            MainForm.DeviceRestart += MainForm_DeviceRestart;
            MainForm.BtnConnectClick += MainForm_BtnConnectClick;
            MainForm.ShowConfiguration += MainForm_ShowConfiguration;
        }

        private void MainForm_BtnConnectClick(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.ConnectionStatus == ConnectionStatusTypes.PressToConnect)
                {
                    AppConfiguration.Update();
                    int address = MainForm.Address;
                    int txId = AppConfiguration.Instance.DfuApp.TxBaseAddress | address;
                    int rxId = AppConfiguration.Instance.DfuApp.RxBaseAddress | address;
                    int baudRate = AppConfiguration.Instance.DfuApp.CanBusBaudrate;
                    string itf = AppConfiguration.Instance.DfuApp.CanBusInterfaceName;

                    if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "NICAN")
                    {
                        _niCanLink = new NiCanInterface(itf, false, txId, rxId, baudRate);
                        _niCanLink.Open();

                    }
                    else if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "XNET")
                    {
                        _xnetLink = new XnetInterface(itf, false, txId, rxId, baudRate);
                        _xnetLink.Open();
                    }

                    MainForm.ConnectionStatus = ConnectionStatusTypes.Connected;
                }
                else
                {
                    if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "NICAN")
                        _niCanLink?.Close();
                    else if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "XNET")
                        _xnetLink?.Close();

                    MainForm.ConnectionStatus = ConnectionStatusTypes.PressToConnect;
                }
            }
            catch (Exception ex)
            {
                MainForm.ConnectionStatus = ConnectionStatusTypes.PressToConnect;
                throw ex;
            }
        }

        private void MainForm_ShowConfiguration(object sender, EventArgs e)
        {
            Tools.RunNotepadOrNpp(AppConstants.AppConfigurationFilePath);
        }   

        private void MainForm_DeviceRestart(object sender, int e)
        {
            try
            {
                if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "NICAN")
                    _niCanLink?.DeviceRestart(e);
                else if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "XNET")
                    _xnetLink?.DeviceRestart(e);
            }
            catch (Exception ex)
            {
                
                MainForm.ConnectionStatus = ConnectionStatusTypes.PressToConnect;
                throw ex; 
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SyncContext = SynchronizationContext.Current;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "NICAN")
                _niCanLink?.Close();
            else if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "XNET")
                _xnetLink?.Close();
        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            MainForm.WriteEnabled = false;
            Iso15765NetwrorkLayer network = null;
            if (AppConfiguration.Instance.DfuApp.CanBusInterfaceType == "NICAN")
                network = new Iso15765NetwrorkLayer(_niCanLink);
            else
                network = new Iso15765NetwrorkLayer(_xnetLink);
            network.ReadTimeoutMs = 1000;
            network.LogPath = AppLog.Instance.FilePath;
            network.LogEnabled = AppLog.Instance.Enabled;


            var dfu = new AppDfu(network);
            dfu.ProgressChange += (o, ev) =>
            {
                MainForm.PoregressValue = ev.ProgressPercentage;
                MainForm.LabelStatus = ev.UserState.ToString();
            };

            byte[] firmware = Tools.OpenFile(_firmwareFilePath);
            dfu.Begin(firmware);

            Action syncCompleted = () =>
            {

            };

            dfu.Completed += (o, ev) =>
            {
                MainForm.WriteEnabled = true;

                if (App.SyncContext != null)
                    App.SyncContext.Post((e1) => { syncCompleted(); }, null);

                if (ev.Result is Exception)
                    MessageBox.Show((ev.Result as Exception).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            var ofd =  new OpenFileDialog();
            if (string.IsNullOrEmpty(_firmwareFilePath))
                ofd.InitialDirectory = AppConfiguration.Instance.DfuApp.FirmwareDirecotry;
            else
                ofd.InitialDirectory = _firmwareFilePath;
            ofd.Filter = AppConstants.FileFilter;
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _firmwareFilePath = ofd.FileName;
                MainForm.FileName = System.IO.Path.GetFileName(_firmwareFilePath);
            }
        }

    }
        
}
