using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class MenuView
    {
        List<Liquor> Items = new List<Liquor>();

        public MenuView(List<Liquor> items)
        {
            this.Items = items;
        }

        public void DisplayLiquorMenu()
        {
            int i = 0;
            string s = string.Format("{0,-5}{1, -9}{2,-30} {3,-10} {4, -20} {5, -8}", "","LiquorID", "Name", "Category", "Description", "Price");

            Console.WriteLine(s);

            foreach (Liquor item in Items)
            {
                string b = string.Format("{0,-5} {1, -9} {2,-30} {3,-10} {4, -20} {5, -8:C2}", i + 1 + ".)", item.LiquorId, item.Name, item.Category, item.Description, item.Price);
                Console.WriteLine(b);
                i++;
            }
        }

        public static void DisplayShoppingCart()
        {

        }

        public static void DisplayCheckOutCart(Receipt receipt, CalculateOrderTotal orderCalculations)
        {

            Console.WriteLine();
            Console.WriteLine("------------------------------- SHOPPING CART -------------------------------");
            Console.WriteLine();

            Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10} {5, 10}", "", "ID" ,"Name", "Quantity", "Unit Price", "Item Subtotal"));

            int i = 0;

            foreach (var item in receipt.ReceiptLineItemsList)
            {
                Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10:C2} {5, 10:C2}", i + 1 + ".)", item.LiquorId, item.LiquorName, item.Quantity, item.UnitPrice, item.LineItemSubtotal));
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Total units in cart: {receipt.LiquorListForReceipt.Count}");
            Console.WriteLine(string.Format("{0} {1:C2} ", "Subtotal: ", orderCalculations.subtotal));
            Console.WriteLine("---------------------------");

        }

        public static void DisplayCartSummary(OrderedItems order, CalculateOrderTotal calculatedOrder)
        {
            Console.WriteLine(string.Format("{0, 70} {1} {2, 15} {3:C2}","Items in cart: ", order.LiquorOrderList.Count, "Subtotal: ", order.SubTotal));

        }
    }
}
