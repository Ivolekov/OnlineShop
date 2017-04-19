namespace OnlineStorePlatform.Web.Areas.Blog.Controllers
{
    using OnlineStorePlatform.Models.ViewModels.Blog;
    using OnlineStorePlatform.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [RouteArea("blog")]
    //[Authorize(Roles ="customer")]
    public class BlogController : Controller
    {
        private BlogService service;

        public BlogController()
        {
            this.service = new BlogService();
        }

        [Route("Articles")]
        public ActionResult Articles()
        {
            IEnumerable<ArticleViewModel> vms = this.service.GetAllArticles();
            return this.View(vms);
        }
    }
}