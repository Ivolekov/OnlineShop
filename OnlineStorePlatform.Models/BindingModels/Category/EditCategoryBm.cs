namespace OnlineStorePlatform.Models.BindingModels.Category
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class EditCategoryBm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please write category name")]
        public string Name { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please add category image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
