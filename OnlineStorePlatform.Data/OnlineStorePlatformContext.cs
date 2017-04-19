namespace OnlineStorePlatform.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System.Data.Entity;

    public class OnlineStorePlatformContext : IdentityDbContext<ApplicationUser>
    {
        public OnlineStorePlatformContext()
            : base("name=OnlineStorePlatformContext", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Article> Articles { get; set; }

        public static OnlineStorePlatformContext Create()
        {
            return new OnlineStorePlatformContext();
        }
    }
}