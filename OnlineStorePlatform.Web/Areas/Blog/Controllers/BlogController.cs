namespace OnlineStorePlatform.Web.Areas.Blog.Controllers
{
    using Data;
    using Data.Interfaces;
    using Models.BindingModels.Blog;
    using OnlineStorePlatform.Models.ViewModels.Blog;
    using OnlineStorePlatform.Service;
    using Service.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Web.Controllers.Base;

    [RouteArea("blog")]
    //[Authorize(Roles ="customer")]
    public class BlogController : BaseController
    {
        private IBlogService service;

        public BlogController(IBlogService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public BlogController(IOnlineStoreData data, IBlogService service) : base(data)
        {
            this.service = new BlogService(data);
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