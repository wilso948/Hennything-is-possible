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

        public static void DisplayCheckoutCart(Receipt receipt, CalculateOrderTotal orderCalculations)
        {
            Console.Clear();
            ConsoleColor color = ConsoleColor.Red;
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.WriteLine("------------------------------- SHOPPING CART -------------------------------");
            Console.WriteLine();

            Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10} {5, 10}", "", "ID", "Name", "Quantity", "Unit Price", "Item Subtotal"));

            int i = 0;

            foreach (var item in receipt.ReceiptLineItemsList)
            {
                Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10:C2} {5, 10:C2}", i + 1 + ".)", item.LiquorId, item.LiquorName, item.Quantity, item.UnitPrice, item.LineItemSubtotal));
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine(string.Format("{0, -15} {1} ", "Total units:", orderCalculations.LiquorOrderListForCalculations.Count));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Subtotal:", orderCalculations.Subtotal));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Sales Tax:", orderCalculations.SalesTaxAmount));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Grandtotal:", orderCalculations.GrandTotal));
            Console.WriteLine("---------------------------");
        }

        public static void DisplayTransactionRecord(Receipt receipt, CalculateOrderTotal orderCalculations)
        {
            Console.Clear();

            ConsoleColor color = ConsoleColor.Red;
            Console.ForegroundColor = color;
            Console.WriteLine("----------------------------- TRANSACTION RECORD -----------------------------");
            Console.WriteLine();

            color = ConsoleColor.DarkCyan;
            Console.ForegroundColor = color;
            //string order = string.Format("{0,-40} {1,-40} {2,-40}", "Name", "Quantity", "Price per item");
            //Console.WriteLine(order);
            Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10} {5, 10}", "", "ID", "Name", "Quantity", "Unit Price", "Item Subtotal"));
            // color = ConsoleColor.Blue;
            //Console.ForegroundColor = color;
            int i = 0;
            foreach (var item in receipt.ReceiptLineItemsList)
            {
                Console.WriteLine(string.Format("{0,-5} {1, -9} {2,-30} {3,-5} {4, 10:C2} {5, 10:C2}", i + 1 + ".)", item.LiquorId, item.LiquorName, item.Quantity, item.UnitPrice, item.LineItemSubtotal));
                i++;
            }
            
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine(string.Format("{0, -15} {1} ", "Total units:", orderCalculations.LiquorOrderListForCalculations.Count));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Subtotal:", orderCalculations.Subtotal));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Sales Tax:", orderCalculations.SalesTaxAmount));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Grandtotal:", orderCalculations.GrandTotal));
            Console.WriteLine("---------------------------");
            Console.WriteLine(string.Format("{0, -15} {1} ", "Payment Method:", receipt.PaymentMethod));
            Console.WriteLine(string.Format("{0, -15} {1} ", "Payment Date:", receipt.PaymentDate));
            Console.WriteLine(string.Format("{0, -15} {1} ", "Payment Status:", receipt.PaymentStatus));
            Console.WriteLine("---------------------------");

            switch (receipt.PaymentMethod)
            {
                case PaymentMethodEnum.Cash:
                    DisplayCashPaymentDetails(receipt, orderCalculations);
                    break;
                case PaymentMethodEnum.CreditCard:
                    DisplayCreditPaymentDetails(receipt, orderCalculations);
                    break;
                case PaymentMethodEnum.Check:
                    DisplayCheckPaymentDetails(receipt, orderCalculations);
                    break;
                default:
                    break;
            }
            Console.WriteLine("---------------------------");
            Console.ResetColor();
        }

        public static void DisplayCashPaymentDetails(Receipt receipt, CalculateOrderTotal orderCalculations)
        {
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Cash Paid:", orderCalculations.AmountPaid));
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Change:", orderCalculations.ChangeCash));

        }

        public static void DisplayCheckPaymentDetails(Receipt receipt, CalculateOrderTotal orderCalculations)
        {
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Check Amt Paid:", orderCalculations.AmountPaid));
            //add checking info
        }

        public static void DisplayCreditPaymentDetails(Receipt receipt, CalculateOrderTotal orderCalculations)
        {
            Console.WriteLine(string.Format("{0, -15} {1:C2} ", "Credit Amt Paid:", orderCalculations.AmountPaid));
            //add masked credit card number
        }

        public static void DisplayCartSummary(OrderedItems order, CalculateOrderTotal calculatedOrder)
        {
            Console.WriteLine(string.Format("{0, 70} {1} {2, 15} {3:C2}","Items in cart: ", order.LiquorOrderList.Count, "Subtotal: ", order.SubTotal));
        }

    }
}
