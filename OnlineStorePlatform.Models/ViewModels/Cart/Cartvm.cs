namespace OnlineStorePlatform.Models.ViewModels.Cart
{
    using EntityModels.Cart;
    public class CartVm
    {
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
    }
}
