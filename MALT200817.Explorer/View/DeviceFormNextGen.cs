namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Common;
    using MALT200817.Explorer.Client;
    using MALT200817.Explorer.Controls;
    using MALT200817.Library;

    public partial class DeviceFormNextGen : Form
    {
        public string Address
        {
            get { return toolStripStatusLabelAddress.Text; }
            set { toolStripStatusLabelAddress.Text = value; }
        }

        public string FamilyCode
        {
            get { return toolStripStatusLabelFamilyCode.Text; }
            set { toolStripStatusLabelFamilyCode.Text = value; }
        }


        public string OptionCode 
        {
            get { return toolStripStatusLabelOptionCode.Text; }
            set { toolStripStatusLabelOptionCode.Text = value; } 
        }

        public string FwVersion
        {
            get { return toolStripStatusLabelFwVersion.Text; }
            set { toolStripStatusLabelFwVersion.Text = value; }
        }
        public string SerialNumber
        {
            get { return toolStripStatusLabelSerialNumber.Text; }
            set { toolStripStatusLabelSerialNumber.Text = value; }
        }

        event EventHandler ComponentClick;
        DeviceItem _library;
        Timer _timer;


        public DeviceFormNextGen()
        {
            InitializeComponent();
            menuStripMessage.Visible = false;
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Tick;

        }

        private void DeviceFormNextGen_ComponentClick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;
            if (!(client.IsConnected && client.LastException == null))
            {
                ErrorHandling("Connection lost...");
            }
            else if (sender is IKnvOutputComponentControl)
            {
                var component = sender as IKnvOutputComponentControl;
                client.SetOne(FamilyCode, Address, component.Port, !component.State);
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;
            if (!(client.IsConnected && client.LastException == null))
            {
                ErrorHandling("Connection lost...");
            }
            else
            {
                foreach (Control con in flowLayoutPanel1.Controls)
                {
                    if (con is IKnvOutputComponentControl)
                    {
                        var component = (con as IKnvOutputComponentControl);
                        component.State = client.GetOne(FamilyCode, Address, component.Port);
                    }
                }
            }
        }

        void Start()
        {
            _timer.Start();
            flowLayoutPanel1.Controls.Clear();
            toolStripStatusLabelLibVersion.Text = _library.LibVersion;
            toolStripStatusLabelFirstName.Text = _library.FirstName;
            this.ClientSize = _library.DefaultWinodwSize;
            foreach (Control c in DrawCoponentControls(_library.Components))
            {
                flowLayoutPanel1.Controls.Add(c);
            }
        }

        public List<Control> DrawCoponentControls(ComponentCollection components)
        {
            var controls = new List<Control>();
            foreach (IComponentItem i in components)
            {
                if (i is ComponentRelaySPDT)
                {
                    var comp = (i as ComponentRelaySPDT);
                    var ctrl = new KnvRealySpdtControl()
                    {
                        Port = i.Port,
                        RelayLabel = comp.Label,
                        NcPinLabel = comp.PinLabel_NC,
                        NoPinLabel = comp.PinLabel_NO,
                        ComPinLabel = comp.PinLabel_COM
                    };
                    ctrl.ComponentClick += ComponentClick;
                    controls.Add(ctrl);
                }
                else if (i is ComponentRelaySPST)
                {
                    var comp = (i as ComponentRelaySPST);
                    var ctrl = new KnvRealySpstControl()
                    {
                        Port = i.Port,
                        RelayLabel = comp.Label,
                        NoPinLabel = comp.PinLabel_NO,
                        ComPinLabel = comp.PinLabel_COM
                    };
                    ctrl.ComponentClick += ComponentClick;
                    controls.Add(ctrl);
                }
            }
            return controls;
        }

        private void DeviceFormNextGen_Load(object sender, EventArgs e)
        {
#if DEBUG
            toolStripStatusWindowSize.Visible = true;
#else
            toolStripStatusWindowSize.Visible = false;
#endif
            ComponentClick += DeviceFormNextGen_ComponentClick;
            _library = Devices.Instance.Search(FamilyCode, OptionCode);
            Start();
        }

        private void ErrorHandling(string msg)
        {
            menuStripMessage.Visible = true;
            toolStripMenuItemMessage.Text = msg;
            _timer.Stop();
            foreach (Control con in flowLayoutPanel1.Controls)
            {
                if (con is IKnvOutputComponentControl)
                {
                    var component = (con as IKnvOutputComponentControl);
                    component.State = false;
                }
            }
            flowLayoutPanel1.Enabled = false;
        }

        private void toolStripMenuContinue_Click(object sender, EventArgs e)
        {
            menuStripMessage.Visible = false;
            flowLayoutPanel1.Enabled = true;
            _timer.Start();
        }

        private void DeviceForm_ResizeEnd(object sender, EventArgs e)
        {
            toolStripStatusWindowSize.Text = this.Size.ToString();
        }

        private void toolStripStatusLabelLibVersion_Click(object sender, EventArgs e)
        {
            Tools.RunNotepadOrNpp(_library.Path);
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaltClient.Instance.Reset(FamilyCode, Address);
        }
    }
}
