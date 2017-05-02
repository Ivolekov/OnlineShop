namespace OnlineStorePlatform.Web.Controllers
{
    using Service.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class NavController : Controller
    {
        private INavService service;

        public NavController(INavService service)
        {
            this.service = service;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = this.service.GetAllCategories();
            return this.PartialView(categories);
        }
    }
}
