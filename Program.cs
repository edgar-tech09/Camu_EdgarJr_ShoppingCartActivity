using System;

namespace Camu_EdgarJr_ShoppingCartActivity
{
  
    class Program
    {
        static Ukayproduct[] inventory = new Ukayproduct[20];

        static CartItem[] SelectedItems = new CartItem[20];
        static int CartItems = 0;

        static void Main(string[] args)
        {
            SetupInventory();

            bool shopping = true;

            while (shopping)
            {
                Console.Clear();
                ShowMenu();
                Console.Write("\nEnter Product ID to purchase [Type 'X' to Finish]: ");
                string userInput = Console.ReadLine();

                if (userInput.ToUpper() == "X")
                {
                    shopping = false;
                    Console.WriteLine("\nProceeding to checkout...");
                }
                else if (int.TryParse(userInput, out int prodChoice))
                {
                    ProcessOrder(prodChoice);
                }
                else
                {
                    Console.WriteLine("Invalid input. Press any key...");
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

        static void ShowMenu()
        {
            Console.WriteLine("Jhear's Thrift Shop");
            Console.WriteLine("ID".PadRight(5) + "BRAND NAME".PadRight(30) + "PRICE".PadRight(15) + "STOCK");
            Console.WriteLine("---------------------------------------------------------------");

            foreach (var item in inventory)
            {
                if (item != null) item.DisplayUkayProd();
            }
        }

        static void ProcessOrder(int prodID)
        {
            Ukayproduct PickedProduct = null;

            foreach (var item in inventory)
            {
                if (item != null && item.ID == prodID)
                {
                    PickedProduct = item;
                    break;
                }
            }

            if (PickedProduct == null)
            {
                Console.WriteLine("Item not found.");
                Console.ReadKey();
                return;
            }

            if (PickedProduct.Stock == 0)
            {
                Console.WriteLine("Out of stock.");
                Console.ReadKey();
                return;
            }

            Console.Write("How many " + PickedProduct.BrandName + "? ");
            if (!int.TryParse(Console.ReadLine(), out int orderqty) || orderqty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                Console.ReadKey();
                return;
            }

            if (orderqty > PickedProduct.Stock)
            {
                Console.WriteLine("Not enough stock.");
                Console.ReadKey();
                return;
            }

            bool setup = false;

            for (int i = 0; i < CartItems; i++)
            {
                if (SelectedItems[i].Product.ID == PickedProduct.ID)
                {
                    SelectedItems[i].Quantity += orderqty;
                    setup = true;
                    break;
                }
            }

            if (!setup)
            {
                SelectedItems[CartItems] = new CartItem();
                SelectedItems[CartItems].Product = PickedProduct;
                SelectedItems[CartItems].Quantity = orderqty;
                CartItems++;
            }

            PickedProduct.Stock -= orderqty;

            Console.WriteLine("Added successfully!");

            string next;
            do
            {
                Console.Write("\nPress Y to continue shopping or X to checkout: ");
                next = Console.ReadLine().ToUpper();

                if (next == "X")
                {
                    ShowCheckout();
                    Environment.Exit(0);
                }
                else if (next != "Y")
                {
                    Console.WriteLine("Invalid input. Please enter Y or X only.");
                }

            } while (next != "Y");
        }



        static void ShowCheckout()
        {
            Console.Clear();
            Console.WriteLine("=== FINAL RECEIPT ===");

            double GrandTotal = 0;

            for (int i = 0; i < CartItems; i++)
            {
                double subtotal = SelectedItems[i].GetSubtotal();
                Console.WriteLine(SelectedItems[i].Product.BrandName + " x" + SelectedItems[i].Quantity + " = P " + subtotal);
                GrandTotal += subtotal;
            }

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Total: P " + GrandTotal);

            double disc = 0;
            if (GrandTotal >= 5000)
            {
                disc = GrandTotal * 0.10;
                Console.WriteLine("Discount (10%): -P " + disc);
            }

            double FinalPay = GrandTotal - disc;
            Console.WriteLine("Final Payment: P " + FinalPay);

            Console.WriteLine("\nRemaining Stock:");
            foreach (var item in inventory)
            {
                if (item != null)
                    item.DisplayUkayProd();
            }
            Console.WriteLine();
            Console.WriteLine("THANK YOU, MA'AM/SIR!!");
            Console.WriteLine();
            Console.WriteLine("\nPress ENTER to exit");
            Console.ReadKey();
        }   

            static void ViewCart()
            {
                Console.WriteLine("\n=== YOUR CART ===");

                if (CartItems == 0)
                {
                    Console.WriteLine("Cart is empty.");
                    return;
                }

                for (int i = 0; i < CartItems; i++)
                {
                    Console.WriteLine((i + 1) + ". "
                        + SelectedItems[i].Product.BrandName
                        + " x" + SelectedItems[i].Quantity
                        + " = P " + SelectedItems[i].GetSubtotal());

                }
            }
        static void RemoveItem()
        {
            ViewCart();

            Console.Write("\nEnter item number to remove: ");
            if (int.TryParse(Console.ReadLine(), out int CartIndex))
            {
                CartIndex--;

                if (CartIndex >= 0 && CartIndex < CartItems)
                {
                    SelectedItems[CartIndex] = SelectedItems[CartItems - 1];
                    CartItems--;
                    Console.WriteLine("Removed Item");
                }
                else
                {
                    Console.WriteLine("Invalid item number");
                }
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        }

        static void ClearCart()
        {
            CartItems = 0;
            Console.WriteLine("All items removed from the cart");
        }
    }
}



