using System;

namespace Camu_EdgarJr_ShoppingCartActivity
{

    class Ukayproduct
    {
        public int ID;
        public string BrandName;
        public double Price;
        public int Stock;

        public void DisplayProduct()
        {

            Console.WriteLine(ID + " . " + BrandName.PadRight(30) + " | PHP " + Price + " | " + Stock + " PCS");
        }

        public double GetSubtotal(int quantity)
        {
            return Price * quantity;
        }
    }


}
