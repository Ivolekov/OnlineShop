namespace OnlineStorePlatform.Models.EntityModels
{
    using System;
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PublishDate { get; set; }

        public virtual User Author { get; set; }
    }
}
