namespace OnlineStorePlatform.Models.ViewModels.Products
{
    using OnlineStorePlatform.Models.EntityModels;
    using System.Collections.Generic;
    public class ProductListVm
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
