namespace OnlineStorePlatform.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class Category
    {
        public Category()
        {
           //this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
