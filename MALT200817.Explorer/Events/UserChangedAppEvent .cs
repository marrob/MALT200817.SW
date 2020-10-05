namespace MALT200817.Explorer.Events
{
    using Configuration;

    class UserChangedAppEvent : IApplicationEvent
    {
        public UserItem User { get; set; }
        public UserChangedAppEvent(UserItem user)
        {
            User = user;
        }
    }
}
