namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Admin;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using AutoMapper;
    using Models.ViewModels.Products;
    using Models.BindingModels;
    using Models.Enums;

    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web;
    using PagedList;

    public class AdminService : Service
    {
        public AdminPageVm GetAdminPage(int? page)
        //public ICollection<Product> GetAdminPage()
        {
            AdminPageVm vm = new AdminPageVm();
            IEnumerable<Category> categories = this.Context.Categories;
            IEnumerable<Product> products = this.Context.Products;

            IEnumerable<CategoriesVm> categoriesVms = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesVm>>(categories);
            IEnumerable<GetAllProductsVm> productsVms = Mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(products);

            vm.Categories = categoriesVms.ToPagedList(page ?? 1, 3);
            vm.Products = productsVms.ToPagedList(page ?? 1, 3);
            //var products = this.Context.Products.OrderBy(p => p.Name).ToList();
            //return products;
            return vm;


        }

        #region ProductService
        public void AddNewProduct(AddNewProductBm bind)
        {
            //Product model = Mapper.Map<AddNewProductBm, Product>(bind);
            //this.Context.Products.Add(model);
            Product product = new Product()
            {
                CategoryId = bind.CategoryId,
                Description = bind.Description,
                //Image = bind.Image,
                Name = bind.Name,
                Price = bind.Price,

            };
            this.Context.Products.Add(product);
            this.Context.SaveChanges();
        }

        //Test datatable
        public IEnumerable<GetAllProductsVm> GetAllProducts()
        {
            IEnumerable<Product> products = this.Context.Products.OrderBy(p => p.Name).ToList();
            IEnumerable<GetAllProductsVm> vms = Mapper.Instance.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(products);

            return vms;
        }

        //End test 

        public EditProductVm GetEditProduct(int id)
        {
            Product model = this.Context.Products.Find(id);
            EditProductVm vm = Mapper.Map<Product, EditProductVm>(model);
            return vm;
        }

        public void EditProduct(EditProductBm bind, int id)
        {
            Product model = this.Context.Products.Find(bind.Id);
           // model.Image = bind.Image;
            model.Name = bind.Name;
            model.Price = bind.Price;
            model.Description = bind.Description;
            model.Category = bind.Category;
            this.Context.SaveChanges();
        }

        public DeleteProductVm GetDeleteProduct(int id)
        {
            Product model = this.Context.Products.Find(id);
            DeleteProductVm vm = Mapper.Map<Product, DeleteProductVm>(model);
            return vm;
        }

        public void DeleteProduct(DeleteProductBm bind)
        {
            Product product = this.Context.Products.Find(bind.Id);
            this.Context.Products.Remove(product);
            this.Context.SaveChanges();
        }

        #endregion


        #region CategoryService
        public void AddNewCategory(AddNewCategoryBm bind, string userId)
        {
            Category model = Mapper.Instance.Map<AddNewCategoryBm, Category>(bind);
            this.Context.Categories.Add(model);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Add, "category");
        }

        public EditCategoryVm GetEditCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            EditCategoryVm vm = Mapper.Map<Category, EditCategoryVm>(model);
            return vm;
        }

        // public void EditCategory(EditCategoryBm bind, int id, string userId, HttpPostedFileBase image)
        public void EditCategory(EditCategoryBm bind, int id, string userId)
        {
            Category model = this.Context.Categories.Find(bind.Id);
            //model.Image = new byte[image.ContentLength];
            // image.InputStream.Read(bind.Image, 0, image.ContentLength);
            model.Name = bind.Name;
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Edit, "category");
        }

        public DeleteCategoryVm GetDeleteCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            DeleteCategoryVm vm = Mapper.Map<Category, DeleteCategoryVm>(model);
            return vm;
        }

        public void DeleteCategory(DeleteCategoryBm bind, string userId)
        {
            Category category = this.Context.Categories.Find(bind.Id);

            foreach (var product in this.Context.Products)
            {
                if (product.CategoryId != null)
                {
                    if (category.Id == product.Category.Id)
                    {
                        product.Category = null;
                        // this.Context.SaveChanges();
                    }
                }

            }

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Delete, "category");
        }
        #endregion

        #region Helppers
        private void AddLog(string userId, OperationLog operation, string modifiedTable)
        {
            ApplicationUser loggedUser = this.Context.Users.Find(userId);
            Log log = new Log()
            {
                User = loggedUser,
                ModifiedAt = DateTime.Now,
                ModifiedTableName = modifiedTable,
                Operation = operation
            };

            this.Context.Logs.Add(log);
            this.Context.SaveChanges();
        }

        public void ChangeCategoryBindIdForImageFileName(AddNewCategoryBm bind)
        {
            var category = this.Context.Categories.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Id == c.Id);
            bind.Id = category.Id;
        }

        public void ChangeProductBindIdForImageFileName(AddNewProductBm bind)
        {
            var product = this.Context.Products.OrderByDescending(c => c.Id).FirstOrDefault(c => c.Id == c.Id);
            bind.Id = product.Id;
        }
        #endregion
    }
}
