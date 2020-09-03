

namespace MALT200817.Explorer.Controls
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

    public partial class KnvRealyControl : UserControl
    {
        public event EventHandler RelayClick
        {
            add { pictureBox1.Click += value; }
            remove { pictureBox1.Click -= value; }
        }

        private bool _state;
        public bool State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string RealayNumber
        {
            get { return labelRelayNum.Text; }
            set { labelRelayNum.Text = value; }
        }

        public string ComPinNumber
        {
            get { return labelComPin.Text; }
            set { labelComPin.Text = value; }
        }
        
        public string NcPinNumber
        {
            get { return labelNcPin.Text; }
            set { labelNcPin.Text = value; }
        }

        public string NoPinNumber
        {
            get { return labelNoPin.Text; }
            set { labelNoPin.Text = value; }
        }

        public KnvRealyControl()
        {
            InitializeComponent();
        }
    }
}
