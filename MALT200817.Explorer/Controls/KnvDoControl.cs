

namespace MALT200817.Explorer.Controls
{
    using System;
    using System.Windows.Forms;

    public partial class KnvDoControl : UserControl, IKnvOutputComponentControl
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
            pictureBox1.Image = Properties.Resources.switchon32;
        }
        
        void Off()
        {
            pictureBox1.Image = Properties.Resources.switchblue32;
        }
        public int Port { get; set; }

        public string Label
        {
            get { return labelRelayNum.Text; }
            set { labelRelayNum.Text = value; }
        }


        public string DoPinLabel
        {
            get { return labelDoPin.Text; }
            set { labelDoPin.Text = value; }
        }

        public KnvDoControl()
        {
            InitializeComponent();
        }

        private void labelRelayNum_Click(object sender, EventArgs e)
        {
            ComponentClick?.Invoke(this, EventArgs.Empty);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ComponentClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
