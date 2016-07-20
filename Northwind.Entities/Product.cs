using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace Northwind.Entities
{
   public class Product
    {
        [HiddenInput(DisplayValue =false)]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryID { get; set; }
    }
}
