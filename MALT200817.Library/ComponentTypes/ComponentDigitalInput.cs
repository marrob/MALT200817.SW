namespace MALT200817.Library
{
    using System.ComponentModel;

    public class ComponentDigitalInput : IComponentItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Label { get; set; }
        public int Port { get; set; }
        public string PinLabel_DI { get; set; }

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
