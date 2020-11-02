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

        public string Index 
        {
            get { return labelIndex.Text; }
            set { labelIndex.Text = value; }
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
            if (e.PropertyName == "Result")
            {
                textBox1.Text = item.Result;
            }
            else if (e.PropertyName == "Status")
            {

                switch (item.Status)
                {

                    case ResultStatusType.Failed: textBox1.BackColor = Color.Red; break;
                    case ResultStatusType.Ok:  textBox1.BackColor = Color.Lime; break;
                    case ResultStatusType.Unknown: textBox1.BackColor = SystemColors.Control; break;
                    case ResultStatusType.Warning: textBox1.BackColor = Color.Yellow; break;
                }
          
            }
        }
    }
}
