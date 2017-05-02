namespace OnlineStorePlatform.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNet.Identity;
    using Models.ViewModels.Products;
    using OnlineStorePlatform.Models.BindingModels;
    using Models.ViewModels.Admin;
    using OnlineStorePlatform.Models.ViewModels.Category;
    using OnlineStorePlatform.Service;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.BindingModels.Category;
    using Models.BindingModels.Product;

    [Authorize(Roles = "admin, manager")]
    [RouteArea("Admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        private HomeService serviceForCategories;
        public AdminController()
        {
            this.service = new AdminService();

            //HomeSevice is use for AddProduct. Need to display all categories in edit view
            this.serviceForCategories = new HomeService();
        }


        [HttpGet]
        [Route]
        public ActionResult Index(int? page)
        {
            AdminPageVm vm = this.service.GetAdminPage(page, null);
            return View(vm);
        }

        [HttpPost]
        [Route]
        public ActionResult Index(int? page, string searchAdmin)
        {
            AdminPageVm vm = new AdminPageVm();
            if (string.IsNullOrEmpty(searchAdmin))
            {
                vm = this.service.GetAdminPage(page, null);
                return View(vm);
            }
            else
            {
                vm = this.service.GetAdminPage(page, searchAdmin);
                return this.View(vm);
            }
        }

        #region Products
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
                var userId = User.Identity.GetUserId();
                this.service.AddNewProduct(bind , userId);
                this.service.ChangeProductBindIdForImageFileName(bind);
                bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Products/") + bind.Name + bind.Id + ".png");
                TempData["message"] = string.Format($"Product \"{bind.Name}\" has been saved");
                return this.RedirectToAction("Index");
            }
            return this.View();
        }
        #endregion

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
            var userId = User.Identity.GetUserId();
            this.service.EditProduct(bind, id, userId);
            bind.ImageFile.SaveAs(Server.MapPath("~/IMG/Products/") + bind.Name + bind.Id + ".png");
            TempData["edit-message"] = string.Format($"Product \"{bind.Name}\" has been edited");
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
            var userId = User.Identity.GetUserId();
            this.service.DeleteProduct(bind, userId);
            TempData["delete-message"] = string.Format($"Product has been removed");//$"Product with id: \"{bind}\" has been deleted");
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
                TempData["message"] = string.Format($" Category \"{bind.Name}\" has been saved");
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
            TempData["edit-message"] = string.Format($" Category \"{bind.Name}\" has been edited");
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
            TempData["delete-message"] = string.Format($" Category \"{bind.Name}\" has been deleted");
            return this.RedirectToAction("Index");
        }
        #endregion

        #endregion

        public JsonResult GetCategoriesJson(string term)
        {
            List<string> products = new List<string>();
            products = this.service.GetGategoriesAsString(term);
            return this.Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}