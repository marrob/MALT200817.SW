

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

    public partial class KnvCoilControl : UserControl, IKnvOutputComponentControl
    {
        public event EventHandler ComponentClick;

        bool _state;
        public bool State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    if (value)
                        On();
                    else
                        Off();
                    _state = value;
                }
            }
        }

        void On()
        {
            pictureBox1.Image = Properties.Resources.coil_on;
        }

        void Off()
        {
            pictureBox1.Image = Properties.Resources.coil_off;
        }

        public int Port { get; set; }

        public string Label
        {
            get { return labelCoilNum.Text; }
            set { labelCoilNum.Text = value; }
        }

        public string LabelPin
        {
            get { return labelPin.Text; }
            set { labelPin.Text = value; }
        }

        public KnvCoilControl()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ComponentClick?.Invoke(this, EventArgs.Empty);
        }

        private void labelRelayNum_Click(object sender, EventArgs e)
        {
            ComponentClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
