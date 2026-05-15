using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camu_EdgarJr_ShoppingCartActivity
{
    class Ukayproduct
    {

        private int ID;
        private string BrandName;
        private double Price;
        private int Stock;

        public void SetID(int id)
        {
            ID = id;
        }

        public int GetID()
        {
            return ID;
        }

        public void SetBrandName(string brandName)
        {
            BrandName = brandName;
        }

        public string GetBrandName()
        {
            return BrandName;
        }

        public void SetPrice(double price)
        {
            Price = price;
        }

        public double GetPrice()
        {
            return Price;
        }

        public void SetStock(int stock)
        {
            Stock = stock;
        }

        public int GetStock()
        {
            return Stock;
        }

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


