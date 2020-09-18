namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MALT200817.Explorer.Controls;
    using MALT200817.Explorer.Client;

    public partial class DevicePanelControl : UserControl
    {
        public event EventHandler ComponentClick;
        public string FamilyCode { get;  set; }
        public string Address { get;  set; }
        public string OptionCode { get;  set; }

        private readonly Timer _timer;
        private ComponentCollection _components;

        public object Datasource
        {
            get { return _components; }
            set 
            {    _components = (ComponentCollection)value; 
                 ContentUpdate(); 
            }
        }

        public DevicePanelControl()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Interval = 1;
            _timer.Start();
            _timer.Tick += Timer_Tick;

            ComponentClick += DevicePanelControl_ComponentClick;
        }

        private void DevicePanelControl_ComponentClick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;
            if (!(client.IsConnected && client.LastException == null))
                return;


            if (sender is IKnvOutputComponentControl)
            {
                var component = sender as IKnvOutputComponentControl;

              client.SetOne(FamilyCode,Address,component.Port, !component.State); 
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var client = MaltClient.Instance;

            if (!(client.IsConnected && client.LastException == null))
                return;

            foreach (Control con in flowLayoutPanel1.Controls)
            {

                if (con is IKnvOutputComponentControl)
                {
                    var component = (con as IKnvOutputComponentControl);
                    component.State = client.GetOne(FamilyCode, Address, component.Port);
                }
            }
            
         }

        void ContentUpdate()
        {
            if (_components == null)
                return;
            foreach (ComponentItem i in _components)
            {
                if (i.Type == ComponetType.RELAY_SPDT)
                {
                    var ctrl = new KnvRealySpdtControl()
                    {
                        Port = i.Port,
                        RelayLabel = i.RelayLabel,
                        NcPinLabel = i.PinLabel_NC,
                        NoPinLabel = i.PinLabel_NO,
                        ComPinLabel = i.PinLabel_COM

                    };
                    ctrl.ComponentClick += ComponentClick;
                    flowLayoutPanel1.Controls.Add(ctrl);
                }
                else if (i.Type == ComponetType.RELAY_SPST)
                {
                    var ctrl = new KnvRealySpstControl()
                    {
                        Port = i.Port,
                        RelayLabel = i.RelayLabel,
                        NoPinLabel = i.PinLabel_NO,
                        ComPinLabel = i.PinLabel_COM
                    };
                    ctrl.ComponentClick += ComponentClick;
                    flowLayoutPanel1.Controls.Add(ctrl);
                }
            }
        }
    }
}
