namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using OnlineStorePlatform.Models.BindingModels.Category;
    using OnlineStorePlatform.Models.BindingModels.Product;
    using OnlineStorePlatform.Models.ViewModels.Admin;
    using OnlineStorePlatform.Models.ViewModels.Category;
    using OnlineStorePlatform.Models.ViewModels.Products;
    public interface IAdminService
    {
        void AddNewCategory(AddNewCategoryBm bind, string userId);
        void AddNewProduct(AddNewProductBm bind, string userId, string search);
        void ChangeCategoryBindIdForImageFileName(AddNewCategoryBm bind);
        void ChangeProductBindIdForImageFileName(AddNewProductBm bind);
        void DeleteCategory(DeleteCategoryBm bind, string userId);
        void DeleteProduct(DeleteProductBm bind, string userId);
        void EditCategory(EditCategoryBm bind, int id, string userId);
        void EditProduct(EditProductBm bind, int id, string userId);
        AdminPageVm GetAdminPage(int? page, string search);
        DeleteCategoryVm GetDeleteCategory(int id);
        DeleteProductVm GetDeleteProduct(int id);
        EditCategoryVm GetEditCategory(int id);
        EditProductVm GetEditProduct(int id);
        List<string> GetGategoriesAsString(string term);
    }
}