namespace OnlineStorePlatform.Service
{
    using Data;
    public abstract class Service
    {
        public Service()
        {
            this.Context = new OnlineStorePlatformContext();
        }

        protected OnlineStorePlatformContext Context { get; set; }
    }
}
