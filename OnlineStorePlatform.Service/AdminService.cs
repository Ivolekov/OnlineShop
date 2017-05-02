namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.ViewModels.Admin;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using AutoMapper;
    using Models.ViewModels.Products;
    using Models.Enums;
    using PagedList;
    using Models.BindingModels.Product;
    using Models.BindingModels.Category;
    using Interfaces;

    public class AdminService : Service, IAdminService
    {
        public AdminPageVm GetAdminPage(int? page, string search)
        {

            AdminPageVm vm = new AdminPageVm();
            IEnumerable<Category> categories = this.Context.Categories;
            IEnumerable<Product> products;

            if (string.IsNullOrEmpty(search))
            {
                products = this.Context.Products;
            }
            else
            {
                products = this.Context.Products.Where(product => product.Name.StartsWith(search));
            }

            IEnumerable<CategoriesVm> categoriesVms = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoriesVm>>(categories);
            IEnumerable<GetAllProductsVm> productsVms = Mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(products);

            vm.Categories = categoriesVms.ToPagedList(page ?? 1, 3);
            vm.Products = productsVms.ToPagedList(page ?? 1, 3);
            return vm;


        }

        #region ProductService
        public void AddNewProduct(AddNewProductBm bind, string userId)
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
            this.AddLog(userId, OperationLog.Add, "Product");
        }

        public EditProductVm GetEditProduct(int id)
        {
            Product model = this.Context.Products.Find(id);
            EditProductVm vm = Mapper.Map<Product, EditProductVm>(model);
            return vm;
        }

        public void EditProduct(EditProductBm bind, int id, string userId)
        {
            Product model = this.Context.Products.Find(bind.Id);
            // model.Image = bind.Image;
            model.Name = bind.Name;
            model.Price = bind.Price;
            model.Description = bind.Description;
            model.Category = bind.Category;
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Edit, "Product");
        }

        public DeleteProductVm GetDeleteProduct(int id)
        {
            Product model = this.Context.Products.Find(id);
            DeleteProductVm vm = Mapper.Map<Product, DeleteProductVm>(model);
            return vm;
        }

        public void DeleteProduct(DeleteProductBm bind, string userId)
        {
            Product product = this.Context.Products.Find(bind.Id);
            this.Context.Products.Remove(product);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Delete, "Product");
        }

        #endregion

        #region CategoryService
        public void AddNewCategory(AddNewCategoryBm bind, string userId)
        {
            Category model = Mapper.Instance.Map<AddNewCategoryBm, Category>(bind);
            this.Context.Categories.Add(model);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Add, "Category");
        }

        public EditCategoryVm GetEditCategory(int id)
        {
            Category model = this.Context.Categories.Find(id);
            EditCategoryVm vm = Mapper.Map<Category, EditCategoryVm>(model);
            return vm;
        }

        public void EditCategory(EditCategoryBm bind, int id, string userId)
        {
            Category model = this.Context.Categories.Find(bind.Id);
            model.Name = bind.Name;
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Edit, "Category");
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
                if (category.Id == product.Category.Id)
                {
                    product.Category = null;
                }
            }

            this.Context.Categories.Remove(category);
            this.Context.SaveChanges();
            this.AddLog(userId, OperationLog.Delete, "Category");
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

        public List<string> GetGategoriesAsString(string term)
        {
            return this.Context.Categories.Where(category => category.Name.StartsWith(term)).Select(p => p.Name).ToList();
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
