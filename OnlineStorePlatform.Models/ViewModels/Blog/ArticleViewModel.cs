namespace OnlineStorePlatform.Models.ViewModels.Blog
{
    using System;
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PublishDate { get; set; }

        public ArticleAuthorViewModel Author { get; set; }

        public string Image
        {
            get
            {
                return this.Title + this.Id + ".png";
            }
        }
    }
}
