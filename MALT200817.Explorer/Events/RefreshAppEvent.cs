namespace MALT200817.Explorer.Events
{
    class RefreshAppEvent : IApplicationEvent
    {
        public object Sender { get; private set; } 
        public RefreshAppEvent(object sender)
        {
            Sender = sender;
        }
    }
}
