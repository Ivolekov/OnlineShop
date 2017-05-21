namespace OnlineStorePlatform.Data
{
    using OnlineStorePlatform.Data.Interfaces;
    using OnlineStorePlatform.Data.Repositories;
    using OnlineStorePlatform.Models.EntityModels;
    public class OnlineStoreData : IOnlineStoreData
    {
        private readonly IOnlineStoreDbContext context;
        public OnlineStoreData(IOnlineStoreDbContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users => new Repository<User>(this.context);
        public IRepository<Product> Products => new Repository<Product>(this.context);
        public IRepository<Category> Categories => new Repository<Category>(this.context);
        public IRepository<Article> Articles => new Repository<Article>(this.context);
        public IRepository<Customer> Customers => new Repository<Customer>(this.context);
        public IRepository<Log> Logs => new Repository<Log>(this.context);
        public IRepository<Order> Orders => new Repository<Order>(this.context);
        public IOnlineStoreDbContext Context => this.context;
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
