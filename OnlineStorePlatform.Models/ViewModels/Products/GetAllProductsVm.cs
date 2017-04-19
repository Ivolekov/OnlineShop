namespace OnlineStorePlatform.Models.ViewModels.Products
{
    using System.Collections.Generic;
    public class GetAllProductsVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public string CategoryName { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
