
namespace MALT200817.Explorer.View
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public enum ComponetType
    { 
        RELAY_SPDT,
        RELAY_SPST
    }

    public class ComponentItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string RelayLabel{ get; set; }
        public int Port { get; set; }
        public string PinLabel_NC { get; set; }
        public string PinLabel_NO { get; set; }
        public string PinLabel_COM { get; set; }

        public ComponetType Type { get; set; }
        private object _value;
        public object Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
    }
}
