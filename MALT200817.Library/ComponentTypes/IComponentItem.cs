namespace MALT200817.Library
{
    using System.ComponentModel;

    public interface IComponentItem: INotifyPropertyChanged
    {
        int Port { get; set; }
        string Label { get; set; }
    }
}
