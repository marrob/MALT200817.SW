
namespace MALT200817.DFU
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Properties;
    using Konvolucio.MUDS150628;
    using Common;
    using Configuration;

    public interface IMainForm
    {

        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler BtnConnectClick;
        event EventHandler<int> DeviceRestart;
        event EventHandler Disposed;

        event EventHandler WriteEventHandler;
        event EventHandler FileBrowseEventHandler;
        event EventHandler ShowConfiguration;

        ConnectionStatusTypes ConnectionStatus { get; set; }

        string Text { get; set; }
        string FileName { get; set; }

        int PoregressValue { get; set; }

        byte Address { get; set; }

        string LabelStatus { get; set; }

        bool WriteEnabled { get; set; }

        string Version { get; set; }
    }

    public partial class MainForm : Form, IMainForm
    {
        public event EventHandler BtnConnectClick
        {
            add { buttonConnect.Click += value; }
            remove { buttonConnect.Click -= value; }
        }

        public event EventHandler<int> DeviceRestart;
        public event EventHandler ShowConfiguration;

        public string Version 
        {
            get { return toolStripStatusLabelVersion.Text; }
            set { toolStripStatusLabelVersion.Text = value; }
        }

        public ConnectionStatusTypes ConnectionStatus
        {
            get { return (ConnectionStatusTypes)Enum.Parse(typeof(ConnectionStatusTypes), buttonConnect.Text); }
            set 
            {
                buttonConnect.Text = value.ToString();
                if (value == ConnectionStatusTypes.Connected)
                {
                    buttonConfig.Enabled = false;
                    buttonBrowse.Enabled = false;
                    NumericUpDownAddress.Enabled = false;
                    buttonRestart.Enabled = true;
                    buttonWrite.Enabled = true;                   
                }
                else
                {
                    buttonConfig.Enabled = true;
                    buttonBrowse.Enabled = true;
                    NumericUpDownAddress.Enabled = true;
                    buttonRestart.Enabled = false;
                    buttonWrite.Enabled = false;

                }
            }
        }

        public event EventHandler WriteEventHandler
        {
            add { buttonWrite.Click += value; }
            remove { buttonWrite.Click -= value; }
        }
        public event EventHandler FileBrowseEventHandler
        {
            add { buttonBrowse.Click += value; }
            remove { buttonBrowse.Click -= value; }
        }

        public int PoregressValue
        {
            get { return ProgressBar.Value; }
            set { ProgressBar.Value = value; }                   
        }

        public byte Address {
            get { return (byte)NumericUpDownAddress.Value; }
            set { NumericUpDownAddress.Value = value; }
        }

        public string FileName
        {
            get { return textFileName.Text; }
            set { textFileName.Text = value; }
        }
        
        public string LabelStatus {
            get { return labelStatus.Text; }
            set { labelStatus.Text = value; }
        }

        bool wrtieEnabled;
        public bool WriteEnabled
        {
            get { return wrtieEnabled; }
            set 
            {
                buttonWrite.Enabled = value;
                wrtieEnabled = value; 
            }
        }


        public MainForm() 
        {
           InitializeComponent();   
        }

        private void TextFileName_TextChanged(object sender, EventArgs e)
        {
            if (textFileName.Text.Length != 0)
                buttonWrite.Enabled = true;
            else
                buttonWrite.Enabled = false;
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            ShowConfiguration?.Invoke(sender, EventArgs.Empty);
        }

        private void ButtonLogs_Click(object sender, EventArgs e)
        {
            Tools.OpenFolder(AppConfiguration.Instance.LogDirectory);
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            DeviceRestart?.Invoke(this, Address);
        }
    }
}
