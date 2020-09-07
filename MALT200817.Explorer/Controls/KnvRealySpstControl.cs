

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

    public partial class KnvRealySpstControl : UserControl
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

        public string RelayLabel
        {
            get { return labelRelayNum.Text; }
            set { labelRelayNum.Text = value; }
        }

        public string ComPinLabel
        {
            get { return labelComPin.Text; }
            set { labelComPin.Text = value; }
        }
        
        public string NoPinLabel
        {
            get { return labelNoPin.Text; }
            set { labelNoPin.Text = value; }
        }

        public KnvRealySpstControl()
        {
            InitializeComponent();
        }
    }
}
