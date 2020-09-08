

namespace MALT200817.Explorer.Controls
{
    using System;
    using System.Windows.Forms;

    public partial class KnvRealySpdtControl : UserControl, IKnvOutputComponentControl
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
                if (_state != value )
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
            pictureBox1.Image = Properties.Resources.relay_spdt_on;
        }
        
        void Off()
        {
            pictureBox1.Image = Properties.Resources.relay_spdt_off;
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
        
        public string NcPinLabel
        {
            get { return labelNcPin.Text; }
            set { labelNcPin.Text = value; }
        }

        public string NoPinLabel
        {
            get { return labelNoPin.Text; }
            set { labelNoPin.Text = value; }
        }

        public KnvRealySpdtControl()
        {
            InitializeComponent();

            pictureBox1.Click += (o, s) =>
            {
                ComponentClick?.Invoke(this, EventArgs.Empty);
            };
        }
    }
}
