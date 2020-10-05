namespace MALT200817.Explorer
{
    using System.ComponentModel;
    public class CounterItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Label { get; set; }
        public int Port { get; set; }

        private string _value;

        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs(nameof(Value)));
                    }
                }
            }
        }
    }
}
