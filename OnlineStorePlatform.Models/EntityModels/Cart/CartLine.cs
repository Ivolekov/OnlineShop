namespace OnlineStorePlatform.Models.EntityModels.Cart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CartLine
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
