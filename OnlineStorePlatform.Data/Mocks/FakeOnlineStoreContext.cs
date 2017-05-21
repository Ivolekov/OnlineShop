namespace OnlineStorePlatform.Data.Mocks
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;
    using System.Data.Entity;

    public class FakeOnlineStoreContext : IOnlineStoreDbContext
    {
        public FakeOnlineStoreContext()
        {
            this.Categories = new FakeCategoryDbSet();
            this.Products = new FakeProductsDbSet();
        }

        public DbContext DbContext { get; set; }
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Customer> Customers { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Log> Logs { get; set; }
        public IDbSet<Article> Articles { get; set; }

        public IDbSet<User> Users { get; set; }

        public static OnlineStorePlatformContext Create()
        {
            return null;
        }

#pragma warning disable CS0109 // Member does not hide an inherited member; new keyword is not required
        public new IDbSet<T> Set<T>() where T : class
#pragma warning restore CS0109 // Member does not hide an inherited member; new keyword is not required
        {
            return null;
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
