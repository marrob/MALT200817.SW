using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
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
            
            if(item is INotifyPropertyChanged)
                (item as INotifyPropertyChanged).PropertyChanged += CheckItemControl_PropertyChanged;

            label1.Text = item.Description;



        }

        private void CheckItemControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var item = sender as ICheckItem;

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
    }
}
