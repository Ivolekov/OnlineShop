namespace OnlineStorePlatform.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a category name")]
        public string Name { get; set; }
    }
}
