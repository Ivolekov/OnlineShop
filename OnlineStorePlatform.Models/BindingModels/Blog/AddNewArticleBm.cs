namespace OnlineStorePlatform.Models.BindingModels.Blog
{
    using OnlineStorePlatform.Models.EntityModels;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class AddNewArticleBm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an article title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an article content")]
        public string Content { get; set; }

        public string PublishDate { get; set; }

        public virtual User Author { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Please add an article image")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}
