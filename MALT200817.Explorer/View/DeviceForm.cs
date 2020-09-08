using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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


        public DeviceForm()
        {
            InitializeComponent();
        }

        private void relayPanelControl1_Load(object sender, EventArgs e)
        {
            this.Text = "@" + FamilyCode + ":" + Address + ":" + OptionCode;
        }
    }
}
