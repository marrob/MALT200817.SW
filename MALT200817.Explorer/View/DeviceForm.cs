namespace MALT200817.Explorer.View
{
    using System;
    using System.Windows.Forms;
    using Common;
    using MALT200817.Explorer.Client;

    public partial class DeviceForm : Form
    {
        public object Components
        {
            get { return relayPanelControl1.Datasource; }
            set { relayPanelControl1.Datasource = value; }
        }

        public string FamilyCode
        {
            get { return relayPanelControl1.FamilyCode; }
            set { relayPanelControl1.FamilyCode = value; }
        }

        public string Address
        {
            get { return relayPanelControl1.Address; }
            set { relayPanelControl1.Address = value; }
        }
        public string OptionCode 
        {
            get { return relayPanelControl1.OptionCode; }
            set { relayPanelControl1.OptionCode = value; } 
        }

        public string  LibVersion
        {
            get { return toolStripStatusLabelLibVersion.Text; }
            set { toolStripStatusLabelLibVersion.Text = value; }
        }

        public string LibPath { get; set; }

        public string FwVersion
        {
            get { return toolStripStatusLabelFwVersion.Text; }
            set { toolStripStatusLabelFwVersion.Text = value; }
        }

        public string SN
        {
            get { return toolStripStatusLabelSerialNumber.Text; }
            set { toolStripStatusLabelSerialNumber.Text = value; }
        }

        public string FamilyName { get; set; }
        public string FirstName { get; set; }

        public DeviceForm()
        {
            InitializeComponent();
        }

        private void relayPanelControl1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabelSwVersion.Text = typeof(Program).Assembly.GetName().Version.ToString();

#if DEBUG
            toolStripStatusWindowSize.Visible = true;
#else
            toolStripStatusWindowSize.Visible = false;
#endif

            toolStripStatusLabelFirstName.Text = FirstName;
            toolStripStatusLabelAddress.Text = Address;
            toolStripStatusLabelFamilyCode.Text = FamilyCode;
            toolStripStatusLabelOptionCode.Text = OptionCode;
            toolStripStatusLabelFamilyName.Text = FamilyName;
        }

        private void DeviceForm_ResizeEnd(object sender, EventArgs e)
        {
            toolStripStatusWindowSize.Text = this.Size.ToString();

        }

        private void toolStripStatusLabelLibVersion_Click(object sender, EventArgs e)
        {
            Tools.RunNotepadOrNpp(LibPath);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaltClient.Instance.Reset(FamilyCode, Address);
        }
    }
}
