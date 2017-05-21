namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using OnlineStorePlatform.Models.BindingModels.Blog;
    using OnlineStorePlatform.Models.ViewModels.Blog;
    public interface IBlogService
    {
        void AddNewArticle(AddNewArticleBm bind, string userName);
        void ChangeArticleBindIdForImageFileName(AddNewArticleBm bind);
        IEnumerable<ArticleViewModel> GetAllArticles();
    }
}