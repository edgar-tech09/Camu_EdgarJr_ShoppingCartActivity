using System;

namespace Camu_EdgarJr_ShoppingCartActivity
{

    class Program
    {
        static Ukayproduct[] inventory = new Ukayproduct[20];

        static CartItem[] SelectedItems = new CartItem[20];

        static int receiptNo = 1;

        static int CartItems = 0;


        static void Main(string[] args)
        {
            SetupInventory();

            bool shopping = true;

            while (shopping)
            {
                Console.Clear();

                ShowMenu();

                Console.Write("\nChoose Option: ");

                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "1")
                {
                    Console.Write("Enter Product ID: ");

                    if (int.TryParse(Console.ReadLine(), out int prodChoice))
                    {
                        ProcessOrder(prodChoice);

                        Console.WriteLine("\nPress any ENTER to continue...");

                        Console.ReadKey();
                    }
                }

                else if (userInput == "2")
                {
                    ViewCart();

                    Console.ReadKey();
                }

                else if (userInput == "3")
                {
                    RemoveItem();

                    Console.ReadKey();
                }

                else if (userInput == "4")
                {
                    ClearCart();

                    Console.ReadKey();
                }

                else if (userInput == "X")
                {
                    shopping = false;

                    Console.WriteLine("\nProceeding to checkout...");
                }

                else
                {
                    Console.WriteLine("Invalid input.");

                    Console.ReadKey();
                }
            }

            ShowCheckout();
        }

        static void SetupInventory()
        {
            inventory[0] = new Ukayproduct();

            inventory[0].SetID(1);
            inventory[0].SetBrandName("Bape T-Shirt");
            inventory[0].SetPrice(1000);
            inventory[0].SetStock(20);

            inventory[1] = new Ukayproduct();

            inventory[1].SetID(2);
            inventory[1].SetBrandName("Gucci Belt");
            inventory[1].SetPrice(1500);
            inventory[1].SetStock(12);

            inventory[2] = new Ukayproduct();

            inventory[2].SetID(3);
            inventory[2].SetBrandName("Billabong Surfing Shorts");
            inventory[2].SetPrice(1200);
            inventory[2].SetStock(25);

            inventory[3] = new Ukayproduct();

            inventory[3].SetID(4);
            inventory[3].SetBrandName("Supreme Cap");
            inventory[3].SetPrice(2000);
            inventory[3].SetStock(5);

            inventory[4] = new Ukayproduct();

            inventory[4].SetID(5);
            inventory[4].SetBrandName("Stussy Hoodie");
            inventory[4].SetPrice(900);
            inventory[4].SetStock(28);

            inventory[5] = new Ukayproduct();

            inventory[5].SetID(6);
            inventory[5].SetBrandName("Vans Off The Wall Shorts");
            inventory[5].SetPrice(750);
            inventory[5].SetStock(20);

            inventory[6] = new Ukayproduct();

            inventory[6].SetID(7);
            inventory[6].SetBrandName("Santa Cruz T-Shirt");
            inventory[6].SetPrice(800);
            inventory[6].SetStock(35);

            inventory[7] = new Ukayproduct();

            inventory[7].SetID(8);
            inventory[7].SetBrandName("Roxy Surfing Shorts");
            inventory[7].SetPrice(1200);
            inventory[7].SetStock(40);

            inventory[8] = new Ukayproduct();

            inventory[8].SetID(9);
            inventory[8].SetBrandName("O'Neill T-Shirt");
            inventory[8].SetPrice(500);
            inventory[8].SetStock(67);

            inventory[9] = new Ukayproduct();

            inventory[9].SetID(10);
            inventory[9].SetBrandName("Levi's 512 Bootcut Jeans");
            inventory[9].SetPrice(2500);
            inventory[9].SetStock(15);

            inventory[10] = new Ukayproduct();

            inventory[10].SetID(11);
            inventory[10].SetBrandName("Chrome Hearts Long Sleeve");
            inventory[10].SetPrice(2500);
            inventory[10].SetStock(10);

            inventory[11] = new Ukayproduct();

            inventory[11].SetID(12);
            inventory[11].SetBrandName("Carhartt Jacket");
            inventory[11].SetPrice(1500);
            inventory[11].SetStock(15);

            inventory[12] = new Ukayproduct();

            inventory[12].SetID(13);
            inventory[12].SetBrandName("Dickies Cargo Pants");
            inventory[12].SetPrice(1800);
            inventory[12].SetStock(20);

            inventory[13] = new Ukayproduct();

            inventory[13].SetID(14);
            inventory[13].SetBrandName("Ralph Lauren Polo Shirt");
            inventory[13].SetPrice(5000);
            inventory[13].SetStock(30);

            inventory[14] = new Ukayproduct();

            inventory[14].SetID(15);
            inventory[14].SetBrandName("Gildan T-Shirt");
            inventory[14].SetPrice(100);
            inventory[14].SetStock(100);

            inventory[15] = new Ukayproduct();

            inventory[15].SetID(16);
            inventory[15].SetBrandName("Mixed Brand Jacket");
            inventory[15].SetPrice(150);
            inventory[15].SetStock(90);

            inventory[16] = new Ukayproduct();

            inventory[16].SetID(17);
            inventory[16].SetBrandName("Mixed Brand Pants");
            inventory[16].SetPrice(120);
            inventory[16].SetStock(150);

            inventory[17] = new Ukayproduct();

            inventory[17].SetID(18);
            inventory[17].SetBrandName("Mixed Brand Sport Shoes");
            inventory[17].SetPrice(1200);
            inventory[17].SetStock(59);

            inventory[18] = new Ukayproduct();

            inventory[18].SetID(19);
            inventory[18].SetBrandName("Mixed Brand Casual Shoes");
            inventory[18].SetPrice(900);
            inventory[18].SetStock(90);

            inventory[19] = new Ukayproduct();

            inventory[19].SetID(20);
            inventory[19].SetBrandName("Mixed Brand Formal Shoes");
            inventory[19].SetPrice(1300);
            inventory[19].SetStock(39);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Jhear's Thrift Shop");

            Console.WriteLine("\n[1] Purchase Item");
            Console.WriteLine("[2] View Cart");
            Console.WriteLine("[3] Delete Item");
            Console.WriteLine("[4] Clear Cart");
            Console.WriteLine("[X] Checkout");

            Console.WriteLine("\nID".PadRight(5) + "BRAND NAME".PadRight(30) + "PRICE".PadRight(15) + "STOCK");

            Console.WriteLine("---------------------------------------------------------------");

            foreach (var item in inventory)
            {
                if (item != null)
                {
                    item.DisplayUkayProd();
                }
            }
        }

        static void ProcessOrder(int prodID)
        {
            Ukayproduct PickedProduct = null;

            foreach (var item in inventory)
            {
                if (item != null && item.GetID() == prodID)
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

            if (PickedProduct.GetStock() == 0)
            {
                Console.WriteLine("Out of stock.");

                Console.ReadKey();

                return;
            }

            Console.Write("How many " + PickedProduct.GetBrandName() + "? ");

            if (!int.TryParse(Console.ReadLine(), out int orderqty) || orderqty <= 0)
            {
                Console.WriteLine("Invalid quantity.");

                Console.ReadKey();

                return;
            }

            if (orderqty > PickedProduct.GetStock())
            {
                Console.WriteLine("Not enough stock.");

                Console.ReadKey();

                return;
            }

            bool setup = false;

            for (int i = 0; i < CartItems; i++)
            {
                if (SelectedItems[i].Product.GetID() == PickedProduct.GetID())
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

            PickedProduct.SetStock(PickedProduct.GetStock() - orderqty);

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

            Console.WriteLine("Receipt No: " + receiptNo);

            Console.WriteLine("Date: " + DateTime.Now);

            Console.WriteLine("=== FINAL RECEIPT ===");

            double GrandTotal = 0;

            for (int i = 0; i < CartItems; i++)
            {
                double subtotal = SelectedItems[i].GetSubtotal();

                Console.WriteLine(
                    SelectedItems[i].Product.GetBrandName()
                    + " x" + SelectedItems[i].Quantity
                    + " = P " + subtotal);

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

            double payment;

            do
            {
                Console.Write("\nEnter payment: ");
            }

            while (!double.TryParse(Console.ReadLine(), out payment) || payment < FinalPay);

            double change = payment - FinalPay;

            Console.WriteLine("Payment: P " + payment);

            Console.WriteLine("Change: P " + change);

            Console.WriteLine("\nRemaining Stock:");

            foreach (var item in inventory)
            {
                if (item != null)
                {
                    item.DisplayUkayProd();
                }
            }

            Console.WriteLine();

            Console.WriteLine("THANK YOU, MA'AM/SIR!!");

            Console.WriteLine();

            Console.WriteLine("\nPress ENTER to exit");

            Console.ReadKey();

            receiptNo++;
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
                    + SelectedItems[i].Product.GetBrandName()
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
