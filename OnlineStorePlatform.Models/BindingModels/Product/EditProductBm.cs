namespace OnlineStorePlatform.Models.BindingModels.Product
{
    using EntityModels;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class EditProductBm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
