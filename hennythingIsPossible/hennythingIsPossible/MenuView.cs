using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class MenuView
    {
        CalculateOrderTotal orderCalculations = new CalculateOrderTotal();
        
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

            ConsoleColor color = ConsoleColor.DarkRed;
            Console.ForegroundColor = color;
            string s = string.Format("{0,100}", "********TRANSACTION RECORD********");
            Console.WriteLine(s);
            color = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = color;
            string order = string.Format("{0,-40} {1,-40} {2,-40}", "Name", "Quantity", "Price per item");
            Console.WriteLine(order);
           // color = ConsoleColor.Blue;
            //Console.ForegroundColor = color;
            foreach (var item in receipt.ReceiptLineItemsList)
            {
                order = string.Format("{0,-40} {1,-40} {2,-40}", item.LiquorId, item.LiquorName, item.Quantity, item.UnitPrice, item.LineItemSubtotal);
                Console.WriteLine(order);
            }
            
            Console.WriteLine();
            Console.WriteLine("Sales Tax: " + "$" + orderCalculations.SalesTaxAmount);
            Console.WriteLine(string.Format("{0} {1:C2} ", "Subtotal: ", orderCalculations.Subtotal));
            Console.WriteLine("Grand Total: " + "$" + orderCalculations.GrandTotal);
            Console.WriteLine("Paid with " + "" + receipt.PaymentMethod);
            if (receipt.PaymentMethod.Equals(PaymentMethodEnum.Cash))

            {
                Console.WriteLine("Paid: " + "$" + orderCalculations.CashAmount);
                Console.WriteLine("Change: " + "$" + orderCalculations.ChangeCash);
            }
            else
            {
                Console.WriteLine("Paid " + "$" + orderCalculations.GrandTotal);
            }

            DateTime today = DateTime.Now;
            Console.WriteLine(today);


            //Console.WriteLine();
            //Console.WriteLine("------------------------------- SHOPPING CART -------------------------------");
            //Console.WriteLine();

            //Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10} {5, 10}", "", "ID" ,"Name", "Quantity", "Unit Price", "Item Subtotal"));

            //int i = 0;

            //foreach (var item in receipt.ReceiptLineItemsList)
            //{
            //    Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10:C2} {5, 10:C2}", i + 1 + ".)", item.LiquorId, item.LiquorName, item.Quantity, item.UnitPrice, item.LineItemSubtotal));
            //    i++;
            //}

            //Console.WriteLine();
            //Console.WriteLine("---------------------------");
            //Console.WriteLine($"Total units in cart: {receipt.LiquorListForReceipt.Count}");
            //Console.WriteLine(string.Format("{0} {1:C2} ", "Subtotal: ", orderCalculations.Subtotal));
            //Console.WriteLine("---------------------------");

        }

        public static void DisplayCartSummary(OrderedItems order, CalculateOrderTotal calculatedOrder)
        {
            Console.WriteLine(string.Format("{0, 70} {1} {2, 15} {3:C2}","Items in cart: ", order.LiquorOrderList.Count, "Subtotal: ", order.SubTotal));

        }

        public static void DisplayPaymentSummary(Receipt receipt)
        {
            Console.WriteLine($"Payment Method: {receipt.PaymentMethod}");
            Console.WriteLine($"Payment Date {receipt.PaymentDate}");
            Console.WriteLine($"Payment Status: "); 
        }
    }
}
