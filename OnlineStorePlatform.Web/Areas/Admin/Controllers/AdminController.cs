namespace OnlineStorePlatform.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models.EntityModels;
    using Models.ViewModels.Products;
    using OnlineStorePlatform.Models.BindingModels;
    using OnlineStorePlatform.Models.ViewModels.Admin;
    using OnlineStorePlatform.Models.ViewModels.Category;
    using OnlineStorePlatform.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using PagedList;
    using PagedList.Mvc;
    using System.Web.Security;

    [Authorize(Roles = "admin, manager")]
    [RouteArea("Admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        private HomeService serviceForCategories;
        public AdminController()
        {
            this.service = new AdminService();

            //this HomeSevice is use for AddProduct. Need to display all categories in add view
            this.serviceForCategories = new HomeService();
        }


        [HttpGet]
        [Route]
        public ActionResult Index(int? page)
        {
            var vm = this.service.GetAdminPage(page);

            return View(vm);
            //var products = this.service.GetAdminPage();
            //return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllProducts()
        {
            var products = this.service.GetAllProducts();
            return Json(new { data = products }, JsonRequestBehavior.AllowGet);
        }

        #region Products
        //TODO: add product with existiong category
        #region Add
        [HttpGet]
        [Route("add/product")]
        public ActionResult AddNewProduct()
        {
            var vm = this.serviceForCategories.GetAllCategories();
            return this.View(vm);
        }

        [HttpPost]
        [Route("add/product")]
        public ActionResult AddNewProduct(AddNewProductBm bind)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNewProduct(bind);
                this.service.ChangeProductBindIdForImageFileName(bind);
                bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Products/") + bind.Name + bind.Id + ".png");
                return this.RedirectToAction("Index");
            }
            return this.View();
        }
        #endregion
        //TODO: edit product categories
        #region Edit
        [HttpGet]
        [Route("edit/product/{id}")]
        public ActionResult EditProduct(int id)
        {
            EditProductVm vm = this.service.GetEditProduct(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/product/{id}")]
        public ActionResult EditProduct(EditProductBm bind, int id)
        {
            this.service.EditProduct(bind, id);
            bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Products/") + bind.Name + bind.Id + ".png");
            return this.RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpGet]
        [Route("delete/product/{id}")]
        public ActionResult DeleteProduct(int id)
        {
            DeleteProductVm vm = this.service.GetDeleteProduct(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/product/{id}")]
        public ActionResult DeleteProduct(DeleteProductBm bind)
        {
            this.service.DeleteProduct(bind);
            return this.RedirectToAction("Index");
        }
        #endregion

        #endregion

        #region Categories

        #region Add
        [HttpGet]
        [Route("add/category")]
        public ActionResult AddNewCategory()
        {
            //return this.PartialView("_AddNewCategory.cshtml");
            return this.View();
        }

        [HttpPost]
        [Route("add/category")]
        public ActionResult AddNewCategory(AddNewCategoryBm bind)
        {
            if (this.ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();

                this.service.AddNewCategory(bind, userId);
                this.service.ChangeCategoryBindIdForImageFileName(bind);
                bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Categories/") + bind.Name + bind.Id + ".png");
                return this.RedirectToAction("Index");
            }
            return this.View();
        }

        #endregion

        #region Edit
        [HttpGet]
        [Route("edit/category/{id}")]
        public ActionResult EditCategory(int id)
        {
            EditCategoryVm vm = this.service.GetEditCategory(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("edit/category/{id}")]
        public ActionResult EditCategory(EditCategoryBm bind, int id)
        {
            var userId = User.Identity.GetUserId();
            this.service.EditCategory(bind, id, userId);
            bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Categories/") + bind.Name + bind.Id + ".png");
            return this.RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpGet]
        [Route("delete/category/{id}")]
        public ActionResult DeleteCategory(int id)
        {
            DeleteCategoryVm vm = this.service.GetDeleteCategory(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("delete/category/{id}")]
        public ActionResult DeleteCategory(DeleteCategoryBm bind)
        {
            var userId = User.Identity.GetUserId();
            this.service.DeleteCategory(bind, userId);
            return this.RedirectToAction("Index");
        }
        #endregion

        #endregion

    }
}