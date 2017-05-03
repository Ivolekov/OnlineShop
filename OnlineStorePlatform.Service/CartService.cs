namespace OnlineStorePlatform.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models.EntityModels;
    using Models.EntityModels.Cart;
    using Interfaces;
    using System.Net.Mail;
    using System.Net;
    using System.Text;
    using Data.Interfaces;

    public class CartService : Service, ICartService
    {
        private EmailSettings emailSettings;

        public CartService(IOnlineStoreData context) 
            : base(context)
        {
            this.emailSettings = new EmailSettings();
        }

        public Product GetProductById(int productId)
        {
           return this.Context.Products.SingleOrDefault(p => p.Id == productId);
        }

        public void AddOrderToDatabase(Customer customerEntity)
        {
            Order order = new Order
            {
                Customer = customerEntity,
                IsDelivered = false,
                DateTime = DateTime.Now.ToString("dd-MM-yyyy(HH:MM)")
            };
            this.Context.Orders.InsertOrUpdate(order);
            this.Context.SaveChanges();
        }

        public Customer AddProductsToCustomer(IEnumerable<CartLine> cartLine, string userId)
        {
            User currentUser = this.Context.Users.GetByStringId(userId);
            ICollection<Product> productsCollection = new HashSet<Product>();

            var products = cartLine.Select(c => c.Product);
            foreach (var product in products)
            {
                productsCollection.Add(product);
            }
            Customer customer = this.Context.Customers.SingleOrDefault(c=>c.User.Id == currentUser.Id);
            customer.Products = productsCollection;
            return customer;
        }

        public void AddDataToShippingDetails(ShippingDetails shippingDetails, string userId)
        {
            User currentUser = this.Context.Users.GetByStringId(userId);
            var order = this.Context.Orders.GetAll().OrderByDescending(ord => ord.Id).FirstOrDefault();
            shippingDetails.OrderId = order.Id;
            shippingDetails.Email = currentUser.Email;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingInfo)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                    = new NetworkCredential(emailSettings.Username,
                        emailSettings.Password);


                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted with ID:" + shippingInfo.OrderId.ToString())
                    .AppendLine("---")
                    .AppendLine("Items:");
                foreach (var line in cart.Lines)
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})\n",
                        line.Quantity,
                        line.Product.Name,
                        subtotal);
                }
                body.AppendFormat("Total order value: {0:c}",
                    cart.ComputeTotalValue())
                    .AppendLine()
                    .Append("Order Id ")
                    .AppendLine(shippingInfo.OrderId.ToString())
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(shippingInfo.Name)
                    .AppendLine(shippingInfo.Email)
                    .AppendLine(shippingInfo.Line1)
                    .AppendLine(shippingInfo.Line2 ?? "")
                    .AppendLine(shippingInfo.Line3 ?? "")
                    .AppendLine(shippingInfo.City)
                    .AppendLine(shippingInfo.State ?? "")
                    .AppendLine(shippingInfo.Country)
                    .AppendLine(shippingInfo.Zip)
                    .AppendLine("---")
                    .AppendFormat("Gift wrap: {0}",
                        shippingInfo.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(new MailAddress(emailSettings.MailFromAddress).Address,
                    new MailAddress(emailSettings.MailToAddress).Address,
                    "New order with ID: " + shippingInfo.OrderId.ToString() + " submitted!",
                    body.ToString());

                smtpClient.Send(mailMessage);
            }
        }
    }
}
