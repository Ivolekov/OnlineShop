namespace OnlineStorePlatform.Models.EntityModels.Cart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Cart
    {
        
        private List<CartLine> LineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = LineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                LineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(p => p.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return LineCollection.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartLine> Lines { get { return LineCollection; } }

        public void Clear()
        {
            LineCollection.Clear();
        }
    }
}
