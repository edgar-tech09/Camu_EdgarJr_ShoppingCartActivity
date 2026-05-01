using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camu_EdgarJr_ShoppingCartActivity
{
    class Ukayproduct
    {

        public int ID;
        public string BrandName;
        public double Price;
        public int Stock;

        public void DisplayUkayProd()
        {

            Console.WriteLine(ID + " . " + BrandName.PadRight(30) + " | PHP " + Price + " | " + Stock + " PCS");
        }

        public double Subtotal(int quantity)
        {
            return Price * quantity;
        }
    }

}

   

