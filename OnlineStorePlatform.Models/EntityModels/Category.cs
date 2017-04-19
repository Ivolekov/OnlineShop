namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    public class Category
    {
        public Category()
        {
           //this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

       // public virtual ICollection<Product> Products { get; set; }
    }
}
