namespace MALT200817.Library
{
    using System.ComponentModel;

    public class ComponentDigitalOutput : IComponentItem
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Label { get; set; }
        public int Port { get; set; }
        public bool IsCountable { get { return false; } }
        public string PinLabel_DO { get; set; }

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
