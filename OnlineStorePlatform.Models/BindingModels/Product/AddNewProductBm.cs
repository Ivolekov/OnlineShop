namespace OnlineStorePlatform.Models.BindingModels.Product
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class AddNewProductBm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter product description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter product price")]
        public decimal Price { get; set; }

        //[Required(ErrorMessage = "Please enter product image")]
      //  public string Image { get; set; }

        [Required(ErrorMessage = "Please enter product category")]
        public int CategoryId { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please enter product image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
