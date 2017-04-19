namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Customer = new HashSet<Customer>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual ICollection<Customer> Customer { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
