using Microsoft.AspNet.Identity;
using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.EntityModels.Cart;
using OnlineStorePlatform.Models.ViewModels.Cart;
using OnlineStorePlatform.Service;
using System.Linq;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
    public class CartController : Controller
    {
        private CartService service;

        public CartController()
        {
            this.service = new CartService();
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