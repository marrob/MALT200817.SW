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

namespace MALT200817.Explorer.View
{
    public partial class DevicePanelControl : UserControl
    {
        public event EventHandler ComponentClick;

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
        }


        void ContentUpdate()
        {
            foreach (ComponentItem i in _components)
            {
                if (i.Type == ComponetType.RELAY_SPDT)
                {
                    var ctrl = new KnvRealySpdtControl()
                    {
                        RelayLabel = i.RelayLabel,
                        NcPinLabel = i.PinLabel_NC,
                        NoPinLabel = i.PinLabel_NO,
                        ComPinLabel = i.PinLabel_COM
                    };
                    ctrl.RelayClick += ComponentClick;
                    flowLayoutPanel1.Controls.Add(ctrl);
                }
                else if (i.Type == ComponetType.RELAY_SPST)
                {
                    var ctrl = new KnvRealySpstControl()
                    {
                        RelayLabel = i.RelayLabel,
                        NoPinLabel = i.PinLabel_NO,
                        ComPinLabel = i.PinLabel_COM
                    };
                    ctrl.RelayClick += ComponentClick;
                    flowLayoutPanel1.Controls.Add(ctrl);
                }


            }
        }
    }
}
