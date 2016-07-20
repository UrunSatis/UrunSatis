using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Entities;
using Northwind.Interfaces;
using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public int pageSize = 5;
        public ViewResult Index(int page=1,int category=0)
        {
            //
            List<Product> products = _productService.GetAll().Where(p=>p.CategoryID==category||category==0).ToList();
            
            return View(new ProductViewModel
                        {
                            Products=products.Skip((page-1)*pageSize).Take(5).ToList(),
                            PageingInfo=new PageingInfo
                                              {
                                                ItemsPerPage = pageSize,
                                                TotalItems=products.Count,
                                                CurrentPage=page,
                                                CurrentCagetory=category
                                               }
                        });
        }

    }
}