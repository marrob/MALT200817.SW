using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

namespace MALT200817.Explorer.View
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            var uri = System.IO.Path.GetFullPath(@"Manual\index.html");
            webBrowser1.Navigate(uri);
        }
    }
}
