namespace OnlineStorePlatform.Data
{
    public class Data
    {
        private static OnlineStorePlatformContext context;

        public static OnlineStorePlatformContext Context
            => context ?? (context = new OnlineStorePlatformContext());
    }
}
