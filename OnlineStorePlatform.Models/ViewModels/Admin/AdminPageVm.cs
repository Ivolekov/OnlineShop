namespace OnlineStorePlatform.Models.ViewModels.Admin
{
    using Category;
    using EntityModels;
    using Products;
    using System.Collections.Generic;
    public class AdminPageVm
    {
        public IEnumerable<GetAllProductsVm> Products { get; set; }

        public IEnumerable<CategoriesVm> Categories { get; set; }
    }
}
