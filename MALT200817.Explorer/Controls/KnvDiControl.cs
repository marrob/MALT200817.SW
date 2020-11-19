

namespace MALT200817.Explorer.Controls
{
    using System;
    using System.Windows.Forms;

    public partial class KnvDiControl : UserControl, IKnvInputComponentControl
    {

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
            pictureBox1.Image = Properties.Resources.buttongreen32;
        }
        
        void Off()
        {
            pictureBox1.Image = Properties.Resources.buttongary32;
        }
        public int Port { get; set; }

        public string Label
        {
            get { return labelNum.Text; }
            set { labelNum.Text = value; }
        }
    
        public string DiPinLabel
        {
            get { return labelNcPin.Text; }
            set { labelNcPin.Text = value; }
        }


        public KnvDiControl()
        {
            InitializeComponent();
        }


    }
}
