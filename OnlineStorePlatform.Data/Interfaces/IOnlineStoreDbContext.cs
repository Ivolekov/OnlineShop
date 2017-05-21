namespace OnlineStorePlatform.Data.Interfaces
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IOnlineStoreDbContext
    {
        DbContext DbContext { get; }
        IDbSet<Product> Products { get; }
        IDbSet<Customer> Customers { get; }
        IDbSet<Category> Categories { get; }
        IDbSet<Order> Orders { get; }
        IDbSet<Log> Logs { get; }
        IDbSet<Article> Articles { get; }
        IDbSet<User> Users { get; }
        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
