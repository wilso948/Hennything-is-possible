using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {

        }

        public static void DisplayShoppingCart(OrderedItems order)
        {
            var list = new List<ShoppingCartLineItem>();

            foreach (var item in order.LiquorOrderList)
            {

            }

            int i = 0;
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("SHOPPING CART");
            Console.WriteLine("---------------------------");


            Console.WriteLine(string.Format("{0,-4}{1,-30} {2,-10} {3, -8}", "", "Name", "Category", "Description", "Price"));

            foreach (Liquor item in order.LiquorOrderList)
            {

                Console.WriteLine(string.Format("{0,-4}{1,-30} {2,-10} {3, -8}", i + 1 + ".)", item.Name, item.Category, item.Price));
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine($"Total quantity: {order.LiquorOrderList.Count}");
            Console.WriteLine(string.Format("Subotal: {0:C2}", order.SubTotal));
            Console.WriteLine(string.Format("Sales Tax: {0:P1}", order.SalesTaxAmount));
            Console.WriteLine(string.Format("Total: {0:C2}", order.GrandTotal));

        }
    }
}
