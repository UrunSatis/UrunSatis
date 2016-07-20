using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities
{
    public class Cart
    {
        List<CartLine> _lines = new List<CartLine>();

        public void AddTocart(Product product, int quantity)
        {
            CartLine cartLine = _lines.FirstOrDefault(c => c.Product.ProductID == product.ProductID);
            if (cartLine == null)
            {
                _lines.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(p => p.Product.ProductID == product.ProductID);
        }

        public decimal Total
        {
            get
            {
                return _lines.Sum(c => c.Product.UnitPrice * c.Quantity);
            }
        }

        public void Clear()
        {
            _lines.Clear();
        }

        public List<CartLine> Lines
        {
            get { return _lines; }
        }
    }
}
