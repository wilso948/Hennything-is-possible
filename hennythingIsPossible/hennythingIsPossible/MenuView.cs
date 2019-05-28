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

        public static void DisplayReceipt(Receipt receipt)
        {
            //var list = new List<ShoppingCartLineItem>();

            foreach (var item in receipt.LiquorListForReceipt)
            {

            }

            int i = 0;
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine("SHOPPING CART");
            Console.WriteLine("---------------------------");


            Console.WriteLine(string.Format("{0,-4}{1,-30} {2,-10} {3, -8}", "", "Name", "Category", "Description", "Price"));

            foreach (Liquor item in receipt.LiquorListForReceipt)
            {

                Console.WriteLine(string.Format("{0,-4}{1,-30} {2,-10} {3, -8}", i + 1 + ".)", item.Name, item.Category, item.Price));
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine($"Total quantity: {receipt.LiquorListForReceipt.Count}");
            //Console.WriteLine(string.Format("Subotal: {0:C2}", receipt.SubTotal));
            //Console.WriteLine(string.Format("Sales Tax: {0:P1}", receipt.SalesTaxAmount));
            //Console.WriteLine(string.Format("Total: {0:C2}", receipt.GrandTotal));
        }
    }
}
