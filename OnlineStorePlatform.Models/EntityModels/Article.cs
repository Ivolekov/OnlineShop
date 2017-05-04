namespace OnlineStorePlatform.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Article
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter an article name")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter an article content")]
        public string Content { get; set; }

        public string PublishDate { get; set; }

        public virtual User Author { get; set; }
    }
}
