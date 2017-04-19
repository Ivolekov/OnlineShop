namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;
    using Models.EntityModels.Cart;

    public class CartService : Service
    {
        public Product GetProductById(int productId)
        {
           return this.Context.Products.FirstOrDefault(p => p.Id == productId);
        }

      
    }
}
