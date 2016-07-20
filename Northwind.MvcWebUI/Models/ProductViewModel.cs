using System.Collections.Generic;
using Northwind.Entities;

namespace Northwind.MvcWebUI.Models
{
   public class ProductViewModel
    {
        public PageingInfo PageingInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}