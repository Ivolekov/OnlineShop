namespace OnlineStorePlatform.Web.Controllers
{
    using Models.ViewModels.Category;
    using Models.ViewModels.Products;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    //[RoutePrefix("home")]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private HomeService service;
        public HomeController()
        {
            this.service = new HomeService();
        }
        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            IEnumerable<CategoriesVm> vms = this.service.GetAllCategories();
            return View(vms);
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return this.View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}