﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.Entities;
using Northwind.Bll.Concrete;
using Northwind.Dal.Concrete.EntityFramework;
using Northwind.Interfaces;

namespace Northwind.WcfLibrary.Concrete
{
    public class ProductService : IProductService
    {
        //Istance Provider ile ezilecek
        private ProductManager _productManager = new ProductManager(new EfProductDal());

        public Product Get(int productId)
        {
           return _productManager.Get(productId);
        }
        public List<Product> GetAll()
        {
            return _productManager.GetAll();
        }
        public void Add(Product product)
        {
            _productManager.Add(product);
        }

        public void Delete(int productId)
        {
            _productManager.Delete(productId);
        }
        public void Update(Product product)
        {
            _productManager.Update(product);
        }
    }
}
