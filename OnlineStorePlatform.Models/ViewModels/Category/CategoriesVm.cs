﻿namespace OnlineStorePlatform.Models.ViewModels.Category
{
    using Products;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CategoriesVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image
        {
            get
            {
                return this.Name + this.Id + ".png";
            }
        }

        public IEnumerable<GetAllProductsVm> BestSellersProducts { get; set; }
    }
}
