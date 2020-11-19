namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;
    using Common;
    using Client;
    using Controls;
    using Library;

    public partial class DeviceForm : Form
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

        public string FamilyName 
        {
            get { return toolStripStatusLabelFamilyName.Text; }
            set { toolStripStatusLabelFamilyName.Text = value; }
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
        DeviceItem _device;
        readonly Timer _timer;


        public DeviceForm()
        {
            InitializeComponent();
            menuStripMessage.Visible = false;
            _timer = new Timer();
            _timer.Interval = 100;
            _timer.Tick += Tick;

        }

        private void DeviceForm_ComponentClick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;
            if (!client.IsConnected)
            {
                ErrorHandling("Connection lost...");
            }
            else if (sender is IKnvOutputComponentControl)
            {
                var component = sender as IKnvOutputComponentControl;
                client.SetOneOutput(FamilyCode, Address, component.Port, !component.State);
            }
        }

        private void Tick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;
            if (!client.IsConnected)
            {
                ErrorHandling("Connection lost...");
            }
            else
            {
                try
                {
                    foreach (Control con in flowLayoutPanel1.Controls)
                    {
                        if (con is IKnvOutputComponentControl)
                        {
                            var component = (con as IKnvOutputComponentControl);
                            component.State = client.GetOneOutput(FamilyCode, Address, component.Port);
                        }
                        else if (con is IKnvInputComponentControl) {
                            var component = (con as IKnvInputComponentControl);
                            component.State = client.GetOneInput(FamilyCode, Address, component.Port);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandling("Status cannot be updated");
                    throw ex;
                }
            }
        }

        void Start()
        {
            _timer.Start();
            flowLayoutPanel1.Controls.Clear();

            this.ClientSize = _device.DefaultWinodwSize;
            foreach (Control c in DrawCoponentControls(_device.Components))
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
                        Label = comp.Label,
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
                        Label = comp.Label,
                        NoPinLabel = comp.PinLabel_NO,
                        ComPinLabel = comp.PinLabel_COM
                    };
                    ctrl.ComponentClick += ComponentClick;
                    controls.Add(ctrl);
                }
                else if (i is ComponentDigitalOutput)
                {
                    var comp = (i as ComponentDigitalOutput);
                    var ctrl = new KnvDoControl()
                    {
                        Port = comp.Port,
                        Label = comp.Label,
                        DoPinLabel = comp.PinLabel_DO,
                    };
                    ctrl.ComponentClick += ComponentClick;
                    controls.Add(ctrl);
                }
                else if(  i is ComponentDigitalInput)
                {
                    var comp = (i as ComponentDigitalInput);
                    var ctrl = new KnvDiControl()
                    {
                        Port = comp.Port,
                        Label = comp.Label,
                        DiPinLabel = comp.PinLabel_DI,
                    };
                    controls.Add(ctrl);
                }
            }
            return controls;
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            toolStripStatusWindowSize.Visible = true;
#else
            toolStripStatusWindowSize.Visible = false;
#endif
            ComponentClick += DeviceForm_ComponentClick;

            _device = Devices.Library.Search(FamilyCode, OptionCode);
            toolStripStatusLabelLibVersion.Text = _device.LibVersion;
            toolStripStatusLabelFirstName.Text = _device.FirstName;
            toolStripStatusLabelVersion.Text = Application.ProductVersion;
            this.Text = _device.FirstName + "-" + Address;
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
            Tools.RunNotepadOrNpp(_device.Path);
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaltClient.Instance.Reset(FamilyCode, Address);
        }

        private void AlwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
            alwaysOnTopToolStripMenuItem.Checked = this.TopMost;
            if (this.TopMost)
            {
                alwaysOnTopToolStripMenuItem.BackColor = Theme.ToolStripMenuCheckedBackColor;
                alwaysOnTopToolStripMenuItem.ForeColor = Theme.ToolStripMenuCheckedForeColor;
            }
            else
            {
                alwaysOnTopToolStripMenuItem.BackColor = SystemColors.Control;
                alwaysOnTopToolStripMenuItem.ForeColor = SystemColors.WindowText;
            }
        }

        private void CountersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new CountersForm();
            form.FamilyCode = FamilyCode;
            form.Address = Address;
            form.OptionCode = OptionCode;
            form.Show();
        }

        private void toolStripStatusLabelLogo_Click(object sender, EventArgs e)
        {
            new UserLoginForm().ShowDialog();
        }
    }
}
