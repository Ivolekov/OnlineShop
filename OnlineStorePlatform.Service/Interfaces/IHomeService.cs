namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using OnlineStorePlatform.Models.ViewModels.Category;
    using OnlineStorePlatform.Models.ViewModels.Products;
    using Models.EntityModels;
    using Models.ViewModels.Home;

    public interface IHomeService
    {
        HomeIndexVm GetAllCategories();
        IEnumerable<GetAllProductsVm> GetProductList();

        void SendEmailFromContactForm(ContactFormDetails contactDetails);
        IEnumerable<GetAllProductsVm> TakeFourProducts();
    }
}