namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    public class Order
    {
        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
