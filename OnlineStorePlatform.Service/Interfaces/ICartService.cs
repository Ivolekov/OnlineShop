namespace OnlineStorePlatform.Service.Interfaces
{
    using System.Collections.Generic;
    using OnlineStorePlatform.Models.EntityModels;
    using OnlineStorePlatform.Models.EntityModels.Cart;
    public interface ICartService
    {
        void AddDataToShippingDetails(ShippingDetails shippingDetails, string user);
        void AddOrderToDatabase(Customer customerEntity);
        Customer AddProductsToCustomer(IEnumerable<CartLine> cartLine, string user);
        Product GetProductById(int productId);
        void ProcessOrder(Cart cart, ShippingDetails shippingInfo);
    }
}