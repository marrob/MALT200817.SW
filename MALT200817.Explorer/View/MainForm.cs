

namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Common;

    public interface IMainForm //: IWindowLayoutRestoring
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;


        string Text { get; set; }

        ToolStripItem[] MenuBar { set; }
        bool AlwaysOnTop { get; set; }

        string Version { get; set; }
        string DevicesCount { get; set; }
        string ConnectionTime { get; set; }

        ToolStripItem[] StatusBar { set; }

        //event KeyEventHandler KeyUp;
        //event HelpEventHandler HelpRequested; /*????*/

        //void CursorWait();
        //void CursorDefault();

        DataGridView DevicesDgv { get; }
    }


    public partial class MainForm : Form, IMainForm
    {
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

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CountersForm();
            form.FamilyCode = "03";
            form.Address = "03";
            form.OptionCode = "00";

            form.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
