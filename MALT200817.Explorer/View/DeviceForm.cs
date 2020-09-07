using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Explorer.View
{
    public partial class DeviceForm : Form
    {
        public object Components
        {
            get { return relayPanelControl1.Datasource; }
            set { relayPanelControl1.Datasource = value; }
        }

        public DeviceForm()
        {
            InitializeComponent();
        }
    }
}
