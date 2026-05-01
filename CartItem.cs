using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camu_EdgarJr_ShoppingCartActivity
{
    class CartItem
    {
        public Ukayproduct Product;
        public int Quantity;

        public double GetSubtotal()
        {
            return Product.Price * Quantity;
        }
    }

}






