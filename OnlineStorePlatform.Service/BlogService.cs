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

    public class BlogService : Service
    {
        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            IEnumerable<Article> model = this.Context.Articles;
            IEnumerable<ArticleViewModel> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleViewModel>>(model);
            return vms;
        }
    }
}
