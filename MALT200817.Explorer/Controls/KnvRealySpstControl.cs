

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

    public partial class KnvRealySpstControl : UserControl, IKnvOutputComponentControl
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
            pictureBox1.Image = Properties.Resources.relay_spst_on;
        }

        void Off()
        {
            pictureBox1.Image = Properties.Resources.relay_spst_off;
        }

        public int Port { get; set; }

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

            pictureBox1.Click += (o, s) =>
            {
                ComponentClick?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
