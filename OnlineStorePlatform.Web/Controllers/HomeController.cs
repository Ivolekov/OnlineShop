namespace OnlineStorePlatform.Web.Controllers
{
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using Service;
    using System.Collections.Generic;
    using System.Web.Mvc;
    
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
        public ActionResult Contact(ContactFormDetails contactFormDetails)
        {
            ViewBag.Message = "Your contact page.";
            if (this.ModelState.IsValid)
            {
                this.service.SendEmailFromContactForm(contactFormDetails);
            }
            return View();
        }

        
    }
}