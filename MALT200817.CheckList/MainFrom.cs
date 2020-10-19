using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Checklist
{

    public interface IMainForm
    {
        event EventHandler Shown;
    }

    public partial class MainFrom : Form
    {
        public List<ICheckItem> CheckItems { get; set; }
        public MainFrom()
        {
            InitializeComponent();
            toolStripStatusLabelVersion.Text = Application.ProductVersion;
        }

        public void AddCheckItem(Control control)
        {
            flowLayoutPanel1.Controls.Add(control);
        }
    }
}
