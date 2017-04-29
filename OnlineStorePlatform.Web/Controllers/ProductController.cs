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
            vms = this.service.GatProductsByCategory(category, page);
            return this.View(vms);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("{category}/page{page}")]
        public ActionResult HomeProducts(string category, int page, string search)
        {
            ProductListVm vms = new ProductListVm();
            if (string.IsNullOrEmpty(search))
            {
                if (category == "all")
                {
                    vms = this.service.GetAllProducts(page);
                    return this.View("All", vms);
                }

                //TODO if products didn't found redirect to appropriate page!!!!
                //IEnumerable<GetAllProductsVm> vms = this.service.GatAllProducts(page);
                vms = this.service.GatProductsByCategory(category, page);
            }
            else
            {
                vms = this.service.GetProducts(page, search);
            }
            return this.View(vms);
        }


        public JsonResult GetProductsJson(string term)
        {
            List<string> products = new List<string>();
            products = this.service.GetProductsAsString(term);
            return this.Json(products, JsonRequestBehavior.AllowGet);
        }
        //[Route("all/page{page}")]
        //public ActionResult AllProducts(int page)
        //{
        //    ProductListVm vms = this.service.GetAllProducts(page);
        //    return this.View(vms);
        //}

        //[Route("{category}||all/page{page}/{searchText}")]
        //public ActionResult GetSearchProduct(string searchText)
        //{
        //    ProductListVm vm = this.service.GetData(searchText);
        //    return this.PartialView("SearchPartial", vm);
        //}

        //TODO: DELETE THIS METHOD
        [ChildActionOnly]
        public ActionResult CreationVisualize()
        {
            var vm = this.serviceForCategories.GetAllCategories();
            return this.PartialView("_GetAllCategories", vm);
        }
    }
}
