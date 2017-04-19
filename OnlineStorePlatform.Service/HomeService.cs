namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.ViewModels.Category;
    using Models.EntityModels;
    using AutoMapper;
    using Models.ViewModels.Products;

    public class HomeService : Service
    {
        public IEnumerable<CategoriesVm> GetAllCategories()
        {
            IEnumerable<Category> model = this.Context.Categories;
            IEnumerable<CategoriesVm> vms = Mapper.Instance.Map<IEnumerable<Category>, IEnumerable<CategoriesVm>>(model);
            return vms;
        }

        public IEnumerable<GetAllProductsVm> GetProductList()
        {
            IEnumerable<Product> model = this.Context.Products;
            IEnumerable<GetAllProductsVm> vms = Mapper.Map<IEnumerable<Product>, IEnumerable<GetAllProductsVm>>(model);
            return vms;
        }
    }
}
