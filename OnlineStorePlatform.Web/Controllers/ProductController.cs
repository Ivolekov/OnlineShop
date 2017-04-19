namespace OnlineStorePlatform.Web.Controllers
{
    using Models.ViewModels.Products;
    using Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [RoutePrefix("products")]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        private ProductService service;
        private HomeService serviceForCategories;
        public ProductController()
        {
            this.service = new ProductService();
            this.serviceForCategories = new HomeService();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("{category}/page{page}")]
        public ActionResult HomeProducts(string category, int page)
        {
            ProductListVm vms = new ProductListVm();
            if (category == "all")
            {
                vms = this.service.GetAllProducts(page);
                return this.View("All", vms);
            }
            
            //TODO if products didn't found redirect to appropriate page!!!!
            //IEnumerable<GetAllProductsVm> vms = this.service.GatAllProducts(page);
            vms = this.service.GatProducts(category, page);
            return this.View(vms);
        }

        [Route("all/page{page}")]
        public ActionResult AllProducts(int page)
        {
            ProductListVm vms = this.service.GetAllProducts(page);
            return this.View(vms);
        }

        //TODO: DELETE THIS METHOD
        [ChildActionOnly]
        public ActionResult CreationVisualize()
        {
            var vm = this.serviceForCategories.GetAllCategories();
            return this.PartialView("_GetAllCategories", vm);
        }
    }
}
