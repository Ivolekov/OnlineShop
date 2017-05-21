namespace OnlineStorePlatform.Models.ViewModels.Home
{
    using Category;
    using Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class HomeIndexVm
    {
        public IEnumerable<GetAllProductsVm> BestSellersProducts { get; set; }

        public IEnumerable<CategoriesVm> Categories { get; set; }
    }
}
