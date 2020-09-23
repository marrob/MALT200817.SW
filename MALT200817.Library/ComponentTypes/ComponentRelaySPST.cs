using System.ComponentModel;

namespace MALT200817.Library
{
    public class ComponentRelaySPST: IComponentItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Label { get; set; }
        public int Port { get; set; }
        public string PinLabel_NO { get; set; }
        public string PinLabel_COM { get; set; }

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
