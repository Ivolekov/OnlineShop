namespace OnlineStorePlatform.Models.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProductModalVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image
        {
            get
            {
                return this.Name + this.Id + ".png";
            }
        }

        public string CategoryName { get; set; }
    }
}
