namespace OnlineStorePlatform.Models.BindingModels
{
    using EntityModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class EditProductBm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public virtual Category Category { get; set; }
    }
}
