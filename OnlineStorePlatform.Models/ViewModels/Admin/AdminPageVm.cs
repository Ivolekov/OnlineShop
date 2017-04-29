namespace OnlineStorePlatform.Models.ViewModels.Admin
{
    using Category;
    using EntityModels;
    using PagedList;
    using Products;
    using System.Collections.Generic;
    public class AdminPageVm
    {
        public IPagedList<GetAllProductsVm> Products { get; set; }

        public IPagedList<CategoriesVm> Categories { get; set; }
    }
}
