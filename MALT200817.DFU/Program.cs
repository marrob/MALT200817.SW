
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

    class App
    {
        public static SynchronizationContext SyncContext = null;

        public IMainForm MainForm { get; set; }
        string _firmwareFilePath { get; set; }


        NiCanInterface NiCanInterface;

        public App()
        {

            /*** Application Configuration ***/
            AppConfiguration.Init();
            IoLog.Instance.FilePath = @"Konvoluico.MUDS150628_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            IoLog.Instance.Enabled = AppConfiguration.Instance.DfuApp.LogEnable;
            AppLog.Instance.FilePath = AppConfiguration.Instance.LogDirectory + @"MALT200817.DFU_" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".txt";
            AppLog.Instance.Enabled = AppConfiguration.Instance.DfuApp.LogEnable;
            AppLog.Instance.WriteLine("MALT200817.DFU.App() Constructor started.");


            MainForm = new MainForm();
            MainForm.Text = "DFU";
            MainForm.FileBrowseEventHandler += ButtonBrowse_Click;
            MainForm.FormClosed += MainForm_FormClosed;
            MainForm.WriteEventHandler += ButtonWrite_Click;
            MainForm.Shown += MainForm_Shown;
            MainForm.DeviceRestart += MainForm_DeviceRestart;
        }

        private void MainForm_DeviceRestart(object sender, EventArgs e)
        {
            int baudRate = 250000;
            NiCanInterface = new NiCanInterface("CAN0", baudRate);
            NiCanInterface.Connect();
            //NiCanInterface.BusTerminationEnable = true;
            NiCanInterface.Open();
            NiCanInterface.RestartCard(MainForm.Address);
            NiCanInterface.Close();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SyncContext = SynchronizationContext.Current;

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            int address = MainForm.Address;

            int txId = AppConfiguration.Instance.DfuApp.TxBaseAddress | address;
            int rxId = AppConfiguration.Instance.DfuApp.RxBaseAddress | address ;
            int baudRate = AppConfiguration.Instance.DfuApp.CanBusBaudrate ;
            string itf = AppConfiguration.Instance.DfuApp.CanBusInterfaceName;
            string itfType = AppConfiguration.Instance.DfuApp.CanBusInterfaceType;


            if (itfType == "NICAN")
            {
                NiCanInterface = new NiCanInterface(itf, false, txId, rxId, baudRate);
                NiCanInterface.Connect();
                NiCanInterface.Open();

            }
            else if (itfType == "XNET")
            {
                var jah = new XnetInterface(itf, false, txId, rxId, baudRate);
            }




            MainForm.WriteEnabled = false;

            var network = new Iso15765NetwrorkLayer(NiCanInterface);
            network.ReadTimeoutMs = 1000;

            var dfu = new AppDfu(network);
            

            dfu.ProgressChange += (o, ev) =>
            {
                MainForm.PoregressValue= ev.ProgressPercentage;
                MainForm.LabelStatus = ev.UserState.ToString();
            };
            

            byte[] firmware =  Tools.OpenFile(_firmwareFilePath);
            dfu.Begin(firmware);

            Action syncCompleted = () =>{

            };

            dfu.Completed += (o, ev) =>
            {
                NiCanInterface.Close();
                MainForm.WriteEnabled = true;

                if (App.SyncContext != null)
                    App.SyncContext.Post((e1) => { syncCompleted(); }, null);

                if (ev.Result is Exception)
                    MessageBox.Show( (ev.Result as Exception).Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
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
