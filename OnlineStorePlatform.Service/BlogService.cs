namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Blog;
    using Models.EntityModels;
    using AutoMapper;
    using Models.BindingModels.Blog;

    public class BlogService : Service
    {
        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            IEnumerable<Article> model = this.Context.Articles;
            IEnumerable<ArticleViewModel> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(model);
            return vms;
        }

        public void AddNewArticle(AddNewArticleBm bind, string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            Article model = Mapper.Map<AddNewArticleBm, Article>(bind);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today.ToString("dd-MM-yyyy");
            this.Context.Articles.Add(model);
            this.Context.SaveChanges();
        }

        public void ChangeArticleBindIdForImageFileName(AddNewArticleBm bind)
        {
            var article = this.Context.Articles.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Id == c.Id);
            bind.Id = article.Id;
        }
    }
}
