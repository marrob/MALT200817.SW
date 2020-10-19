using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MALT200817.Checklist
{
    public partial class CheckItemControl : UserControl
    {

        public CheckItemControl()
        {
            InitializeComponent();
        }


        public void Update(ICheckItem item)
        { 
            
            label1.Text = item.Description;

            try
            {
                item.Process();
                textBox1.Text = item.Result;
                if (item.Status == ResultStatusType.Ok)
                {
                    textBox1.BackColor = Color.Lime;
                }
                else
                {
                    textBox1.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "Az értékelés során hibatörtént..." + ex.Message;
                textBox1.BackColor = Color.Red;
            }

        }
    }
}
