namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using OnlineStorePlatform.Models.ViewModels.Products;
    public interface IProductService
    {
        ProductListVm GatProductsByCategory(string category, int page);
        ProductListVm GetAllProducts(int page);
        ProductModalVm GetProductForModalView(int id);
        ProductListVm GetProducts(int page, string search);
        List<string> GetProductsAsString(string term);
    }
}