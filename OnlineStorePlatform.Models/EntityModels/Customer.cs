namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Customer
    {
        public Customer()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        [NotMapped]
        public virtual ICollection<Product> Products { get; set; }
    }
}
