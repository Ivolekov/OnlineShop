namespace OnlineStorePlatform.Service
{
    using Data;
    using Data.Interfaces;

    public abstract class Service
    {
        public Service(IOnlineStoreData context)
        {
            this.Context = context;
        }

        protected IOnlineStoreData Context { get; }
    }
}
