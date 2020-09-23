namespace MALT200817.Library
{
    using System.ComponentModel;

    public interface IComponentItem: INotifyPropertyChanged
    {
        string Label { get; set; }
        int Port { get; set; }
    }
}
