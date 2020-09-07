using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Explorer.View
{
    public partial class DeviceSelectorControl : UserControl
    {
        public DeviceSelectorControl()
        {
            InitializeComponent();
            knvDataGridView1.AutoGenerateColumns = false;
        }

        public void CoulmnAutosize()
        {
            knvDataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        public DataGridView DataGrid
        { 
            get { return knvDataGridView1; }
        }
    }
}
