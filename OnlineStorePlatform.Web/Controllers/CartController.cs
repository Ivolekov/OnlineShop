using Microsoft.AspNet.Identity;
using OnlineStorePlatform.Data;
using OnlineStorePlatform.Data.Interfaces;
using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.EntityModels.Cart;
using OnlineStorePlatform.Models.ViewModels.Cart;
using OnlineStorePlatform.Service;
using OnlineStorePlatform.Service.Interfaces;
using OnlineStorePlatform.Web.Controllers.Base;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    [HandleError]
    public class CartController : BaseController
    {
        private ICartService service;
        public CartController(ICartService service) 
            : base(new OnlineStoreData(new OnlineStorePlatformContext()))
        {
            this.service = service;
        }
        public CartController(IOnlineStoreData data, ICartService service) : base(data)
        {
            this.service = new CartService(data);
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            CartVm vm = new CartVm { Cart = cart, ReturnUrl = returnUrl };
            return this.View(vm);
        }

        [Authorize]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                var user = User.Identity.GetUserId();
                Customer customerEntity = this.service.AddProductsToCustomer(cart.Lines, user);
                this.service.AddOrderToDatabase(customerEntity);
                this.service.AddDataToShippingDetails(shippingDetails, user);
                this.service.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");

            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult Summary(Cart cart)
        {
            return this.PartialView(cart);
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = this.service.GetProductById(productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = this.service.GetProductById(productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return this.RedirectToAction("Index", new { returnUrl });
        }

        #region Helpers
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];

            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
        #endregion
    }
}