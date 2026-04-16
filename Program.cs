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

    class Program
    {
        static Ukayproduct[] inventory = new Ukayproduct[20];
        static double grandTotal = 0;

        static void Main(string[] args)
        {
            SetupInventory();

            bool shopping = true;
            while (shopping)
            {
                Console.Clear();
                ShowMenu();
                Console.Write("\nEnter Product ID to purchase [Type 'X' to Finish]: ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "X")
                {
                    shopping = false;
                    Console.WriteLine("\nThankyou Sir, Proceeding to checkout");
                }
              
                else if (int.TryParse(input, out int choice))
                {
                    ProcessOrder(choice);
                }
                else
                {
                    Console.WriteLine("The input is wrong, use X only");
                    Console.ReadKey(); 
                }
            }
             
            ShowCheckout();
        }

        static void SetupInventory()
        {
            inventory[0] = new Ukayproduct { ID = 1, BrandName = "Bape T-Shirt", Price = 1000, Stock = 20 };
            inventory[1] = new Ukayproduct { ID = 2, BrandName = "Gucci Belt", Price = 1500, Stock = 12 };
            inventory[2] = new Ukayproduct { ID = 3, BrandName = "Billabong Surfing Shorts", Price = 1200, Stock = 25 };
            inventory[3] = new Ukayproduct { ID = 4, BrandName = "Supreme Cap", Price = 2000, Stock = 5 };
            inventory[4] = new Ukayproduct { ID = 5, BrandName = "Stussy Hoodie", Price = 900, Stock = 28 };
            inventory[5] = new Ukayproduct { ID = 6, BrandName = "Vans Off The Wall Shorts", Price = 750, Stock = 20 };
            inventory[6] = new Ukayproduct { ID = 7, BrandName = "Santa Cruz T-Shirt", Price = 800, Stock = 35 };
            inventory[7] = new Ukayproduct { ID = 8, BrandName = "Roxy Surfing Shorts", Price = 1200, Stock = 40 };
            inventory[8] = new Ukayproduct { ID = 9, BrandName = "O'Neill T-Shirt", Price = 500, Stock = 67 };
            inventory[9] = new Ukayproduct { ID = 10, BrandName = "Levi's 512 Bootcut Jeans", Price = 2500, Stock = 15 };
            inventory[10] = new Ukayproduct { ID = 11, BrandName = "Chrome Hearts Long Sleeve", Price = 2500, Stock = 10 };
            inventory[11] = new Ukayproduct { ID = 12, BrandName = "Carhartt Jacket", Price = 1500, Stock = 15 };
            inventory[12] = new Ukayproduct { ID = 13, BrandName = "Dickies Cargo Pants", Price = 1800, Stock = 20 };
            inventory[13] = new Ukayproduct { ID = 14, BrandName = "Ralph Lauren Polo Shirt", Price = 5000, Stock = 30 };
            inventory[14] = new Ukayproduct { ID = 15, BrandName = "Gildan T-Shirt", Price = 100, Stock = 100 };
            inventory[15] = new Ukayproduct { ID = 16, BrandName = "Mixed Brand Jacket", Price = 150, Stock = 90 };
            inventory[16] = new Ukayproduct { ID = 17, BrandName = "Mixed Brand Pants", Price = 120, Stock = 150 };
            inventory[17] = new Ukayproduct { ID = 18, BrandName = "Mixed Brand Sport Shoes", Price = 1200, Stock = 59 };
            inventory[18] = new Ukayproduct { ID = 19, BrandName = "Mixed Brand Casual Shoes", Price = 900, Stock = 90 };
            inventory[19] = new Ukayproduct { ID = 20, BrandName = "Mixed Brand Formal Shoes", Price = 1300, Stock = 39 };
        }
    }
