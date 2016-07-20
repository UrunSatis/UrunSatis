using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        public IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId)
        {
            Product product = _productService.Get(productId);

            cart.AddTocart(product, 1);

            return RedirectToAction("Index", cart);
        }
        public ViewResult Index(Cart cart)
        {            
            return View(cart);
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart,int productId)
        {
            Product product = _productService.Get(productId);

            if (cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sepette zaten ürün yok");
            }
            else
            {
                cart.RemoveFromCart(product);
            }

            return RedirectToAction("Index", cart);
        }
        public ActionResult Checkout()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {
                //managerdan bilgiler veri tabanına eklenecek
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public PartialViewResult CartSummary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}