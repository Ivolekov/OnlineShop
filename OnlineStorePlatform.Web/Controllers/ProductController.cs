namespace OnlineStorePlatform.Web.Controllers
{
    using Base;
    using Data;
    using Data.Interfaces;
    using Models.ViewModels.Products;
    using Service;
    using Service.Interfaces;
    using System.Collections.Generic;
    using System.Web.Mvc;

    [RoutePrefix("products")]
    [AllowAnonymous]
    public class ProductController : BaseController
    {
        private IProductService service;
        public ProductController(IProductService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public ProductController(IOnlineStoreData data, IProductService service) : base(data)
        {
            this.service = new ProductService(data);
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

        [Route("quickview")]
        public ActionResult QuickView(int id)
        {
            ProductModalVm vm = this.service.GetProductForModalView(id);
            return this.PartialView("_ModalContent", vm);
        }
    }
}
