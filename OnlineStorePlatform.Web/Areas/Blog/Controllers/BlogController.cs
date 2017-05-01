namespace OnlineStorePlatform.Web.Areas.Blog.Controllers
{
    using Models.BindingModels.Blog;
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

        [ChildActionOnly]
        public ActionResult CreationVisualize()
        {
            return this.PartialView("_AddBtnForArticle");
        }

        [Route("add")]
        [HttpGet]
        [Authorize(Roles ="admin, manager")]
        public ActionResult Add()
        {
            return this.View();
        }

        [Route("add")]
        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public ActionResult Add(AddNewArticleBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string userName = this.User.Identity.Name;
                this.service.AddNewArticle(bind, userName);
                this.service.ChangeArticleBindIdForImageFileName(bind);
                bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Articles/") + bind.Title + bind.Id + ".png");
                return this.RedirectToAction("Articles");
            }
            return this.View();
        }

        //TODO: Edit and Delete article
    }
}