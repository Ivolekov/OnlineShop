namespace OnlineStorePlatform.Models.BindingModels
{
    using EntityModels;
    using System.Collections.Generic;

    public class AddNewProductBm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        public int CategoryId { get; set; }
    }
}
