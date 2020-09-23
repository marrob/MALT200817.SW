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
    using Library;

    public partial class DevicePanelControl : UserControl
    {
        public event EventHandler ComponentClick;
        public string FamilyCode { get;  set; }
        public string Address { get;  set; }
        public string OptionCode { get;  set; }

        private readonly Timer _timer;
        private Library.ComponentCollection _components;

        public object Datasource
        {
            get { return _components; }
            set 
            {    _components = (Library.ComponentCollection)value; 
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
            foreach (IComponentItem i in _components)
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
                    flowLayoutPanel1.Controls.Add(ctrl);
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
                    flowLayoutPanel1.Controls.Add(ctrl);
                }
            }
        }
    }
}
