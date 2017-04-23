using OnlineStorePlatform.Models.EntityModels;
using OnlineStorePlatform.Models.EntityModels.Cart;
using OnlineStorePlatform.Models.ViewModels.Cart;
using OnlineStorePlatform.Service;
using OnlineStorePlatform.Web.Abstracts;
using OnlineStorePlatform.Web.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStorePlatform.Web.Controllers
{
   // [Authorize]
    public class CartController : Controller
    {
        private CartService service;
        //TODO: USE NINJET orderProcessor do not work
        //TODO: Abstract and Concrate folders must be services
        private IOrderProcessor orderProcessor;

        public CartController(IOrderProcessor processor)
        {
            this.orderProcessor = processor;
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
                orderProcessor.ProcessOrder(cart, shippingDetails);
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

            return this.RedirectToAction("Index", new { returnUrl});
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

            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
        #endregion
    }
}