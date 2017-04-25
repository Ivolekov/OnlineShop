namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models.EntityModels;
    using Models.EntityModels.Cart;
    using Models.BindingModels.Cart;
    using Data;

    public class CartService : Service
    {
        public Product GetProductById(int productId)
        {
           return this.Context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void AddOrderToDatabase(Customer customerEntity)
        {
            Order order = new Order
            {
                Customer = customerEntity,
                IsDelivered = false,
                DateTime = DateTime.Now.ToString("dd-MM-yyyy(HH:MM)")
            };
            this.Context.Orders.Add(order);
            this.Context.SaveChanges();
        }

        public Customer AddProductsToCustomer(IEnumerable<CartLine> cartLine, string user)
        {
            ApplicationUser currentUser = this.Context.Users.Find(user);
            ICollection<Product> productsCollection = new HashSet<Product>();

            var products = cartLine.Select(c => c.Product);
            foreach (var product in products)
            {
                productsCollection.Add(product);
            }
            Customer customer = this.Context.Customers.FirstOrDefault(c=>c.User.Id == currentUser.Id);
            customer.Products = productsCollection;
            return customer;
        }

        public void AddDataToShippingDetails(ShippingDetails shippingDetails, string user)
        {
            ApplicationUser currentUser = this.Context.Users.Find(user);
            var order = this.Context.Orders.OrderByDescending(ord => ord.Id).FirstOrDefault();
            shippingDetails.OrderId = order.Id;
            shippingDetails.Email = currentUser.Email;
        }
    }
}
