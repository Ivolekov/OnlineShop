namespace OnlineStorePlatform.Web.Controllers
{
    using Models.ViewModels.Category;
    using Models.ViewModels.Products;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    public class NavController : Controller
    {
        private NavService service;

        public NavController()
        {
            this.service = new NavService();
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = this.service.GetAllCategories();
            return this.PartialView(categories);
        }

        ////TODO: NOT WORKING
        //[Route("products/page{page}")]
        //public ActionResult All(int page)
        //{
        //    ProductListVm vms = this.service.GetAllProducts(page);
        //    return this.View(vms);
        //}

    }
}
