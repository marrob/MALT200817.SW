namespace MALT200817.Library
{
    using System.ComponentModel;

    public interface IComponentItem: INotifyPropertyChanged
    {
        /// <summary>
        /// Visszadja hogy a komponens rendelkezik-e saját ciklusszámlálóval vagy sem.
        /// </summary>
        bool IsCountable { get; }
        /// <summary>
        /// A fizikai port címe amely 1-től n-ig tart.
        /// </summary>
        int Port { get; set; }
        /// <summary>
        /// A komponens cimkéje
        /// </summary>
        string Label { get; set; }
    }
}
