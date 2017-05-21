namespace OnlineStorePlatform.Models.BindingModels.Cart
{
    using OnlineStorePlatform.Models.EntityModels;
    using System.Collections.Generic;
    public class CustomerBm
    {
        public CustomerBm()
        {
            this.Products = new HashSet<Product>();
        }
        public virtual ApplicationUser User { get; set; }

        public  ICollection<Product> Products { get; set; }
    }
}
