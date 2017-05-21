using OnlineStorePlatform.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStorePlatform.Data.Interfaces
{
    public interface IOnlineStoreData
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<Article> Articles { get; }
        IRepository<Order> Orders { get; }
        IRepository<Customer> Customers { get; }
        IRepository<Log> Logs { get; }
        IOnlineStoreDbContext Context { get; }

        int SaveChanges();
    }
}
