namespace OnlineStorePlatform.Web.Controllers
{
    using Abstracts;
    using Models.EntityModels;
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
        private IEmailContactProcessor emailContactProcessor;
        public HomeController(IEmailContactProcessor contactProcessor)
        {
            this.service = new HomeService();
            this.emailContactProcessor = contactProcessor;
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
        public ActionResult Contact(ContactFormDetails contactForm)
        {
            ViewBag.Message = "Your contact page.";
            if (this.ModelState.IsValid)
            {
                emailContactProcessor.ProcessContactForm(contactForm);
            }
            return View();
        }

        
    }
}