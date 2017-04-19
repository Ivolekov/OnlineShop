namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Category;
    using Models.EntityModels;
    using Models.ViewModels.Products;
    using Models;

    public class NavService : Service
    {
        public const int PageSize = 6;
        public IEnumerable<string> GetAllCategories()
        {
            return this.Context.Products.Select(x => x.Category.Name).Distinct().OrderBy(x => x);
        }


        //public ProductListVm GetAllProducts(int page)
        //{
        //    ProductListVm model = new ProductListVm
        //    {
        //        Products = this.Context.Products
        //       .OrderBy(p => p.Id)
        //       .Skip((page - 1) * PageSize)
        //       .Take(PageSize),

        //        PagingInfo = new PagingInfo
        //        {
        //            CurrentPage = page,
        //            ItemsPerPage = PageSize,
        //            TotalItems = this.Context.Products.Count()
        //        }
        //    };
        //    return model;
        //}
    }
}
