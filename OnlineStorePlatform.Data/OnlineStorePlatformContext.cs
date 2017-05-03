namespace OnlineStorePlatform.Data
{
    using Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System.Data.Entity;
    using System;

    public class OnlineStorePlatformContext : IdentityDbContext<User>, IOnlineStoreDbContext
    {
        public OnlineStorePlatformContext()
            : base("name=OnlineStorePlatformContext", throwIfV1Schema: false)
        {
        }

        public DbContext DbContext => this;
        public virtual IDbSet<Product> Products { get; set; }
        public virtual IDbSet<Customer> Customers { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Order> Orders { get; set; }
        public virtual IDbSet<Log> Logs { get; set; }
        public virtual IDbSet<Article> Articles { get; set; }
        public static OnlineStorePlatformContext Create()
        {
            return new OnlineStorePlatformContext();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}