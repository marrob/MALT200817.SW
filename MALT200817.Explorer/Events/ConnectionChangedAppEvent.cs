namespace MALT200817.Explorer.Events
{
    class ConnectionChangedAppEvent : IApplicationEvent
    {
       public bool IsConnected { get; private set; }

        public ConnectionChangedAppEvent(bool isConnected)
        {
            IsConnected = isConnected;
        }

    }
}
