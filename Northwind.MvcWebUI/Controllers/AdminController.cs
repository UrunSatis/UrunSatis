using Northwind.Entities;
using Northwind.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class AdminController : Controller
    {
        public IProductService _productServices;
        public AdminController(IProductService productServices)
        {
            _productServices = productServices;
        }
        public ActionResult Index()
        {
            return View(_productServices.GetAll());
        }
        public ActionResult CreateNew()
        {
            return View(new Product());
        }
        [HttpPost]
        public ActionResult CreateNew(Product product)
        {
            if (ModelState.IsValid)
            {
                _productServices.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public ActionResult Edit(int productId)
        {
            Product product = _productServices.Get(productId);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productServices.Update(product);
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

    }
}