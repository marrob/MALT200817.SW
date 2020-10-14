namespace MALT200817.Explorer.View
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public interface IMainForm
    {
        event EventHandler Shown;
        event EventHandler Login;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        bool AlwaysOnTop { get; set; }
        string Version { get; set; }
        string DevicesCount { get; set; }
        string ConnectionTime { get; set; }
        string ServiceStatus { get; set; }
        string ConnectionStatus { get; set; }
        ToolStripItem[] StatusBar { set; }
        DataGridView DevicesDgv { get; }
    }


    public partial class MainForm : Form, IMainForm
    {
        public event EventHandler Login;

        public string Version
        {
            get { return (toolStripStatusLabelVersion.Text); }
            set { toolStripStatusLabelVersion.Text = value; }
        }

        public string DevicesCount
        {
            get { return toolStripStatusDevicesCount.Text; }
            set { toolStripStatusDevicesCount.Text = value; }
        }

        public string ConnectionTime
        {
            get { return toolStripStatusLabelConnetcionTime.Text; }
            set { toolStripStatusLabelConnetcionTime.Text = value; }
        }

        public string ServiceStatus
        {
            get 
            {
                return toolStripStatusLabelServiceStatus.Text;
            }
            set 
            {
                if (value == "Stopped")
                    toolStripStatusLabelServiceStatus.BackColor = Color.Red;
                else if(value == "Running")
                    toolStripStatusLabelServiceStatus.BackColor = Color.YellowGreen;
                else
                    toolStripStatusLabelServiceStatus.BackColor = Color.Yellow;

                toolStripStatusLabelServiceStatus.Text = value;
            }
        }

        public string ConnectionStatus
        { 
            get { return toolStripStatusLabelConnectionStatus.Text; }
            set { toolStripStatusLabelConnectionStatus.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();
        }
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip2.Items.AddRange(value); }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public DataGridView DevicesDgv
        {
            get { return devicesViewControl1.DataGrid; }
        }

        private void toolStripStatusLabelLogo_Click(object sender, EventArgs e)
        {
            Login?.Invoke(this, EventArgs.Empty);
        }
    }
}
