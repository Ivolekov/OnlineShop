namespace OnlineStorePlatform.Models.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DeleteProductVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual ICollection<string> CategoriesName { get; set; }
    }
}
