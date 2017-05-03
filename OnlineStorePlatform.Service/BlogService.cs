namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels.Blog;
    using Models.EntityModels;
    using AutoMapper;
    using Models.BindingModels.Blog;
    using Interfaces;
    using Data.Interfaces;

    public class BlogService : Service, IBlogService
    {
        public BlogService(IOnlineStoreData context) 
            : base(context)
        {
        }

        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            IEnumerable<Article> model = this.Context.Articles.GetAll();
            IEnumerable<ArticleViewModel> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(model);
            return vms;
        }

        public void AddNewArticle(AddNewArticleBm bind, string userName)
        {
            User currentUser = this.Context.Users.SingleOrDefault(u => u.UserName == userName);
            Article model = Mapper.Map<AddNewArticleBm, Article>(bind);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today.ToString("dd-MM-yyyy");
            this.Context.Articles.InsertOrUpdate(model);
            this.Context.SaveChanges();
        }

        public void ChangeArticleBindIdForImageFileName(AddNewArticleBm bind)
        {
            Article article = this.Context.Articles.GetAll().OrderByDescending(c => c.Id).FirstOrDefault(c => c.Id == c.Id);
            bind.Id = article.Id;
        }

        //TODO: Edit and Delete moethods
    }
}
