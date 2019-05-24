using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class HennyApp
    {

        public static void Run()
        {
            Controller obj = new Controller();
            OrderedItems customerOrder = new OrderedItems();
            customerOrder.SalesTaxAmount = 0.06;
            bool userWantsToQuit = false;
         
            HennyArt.DisplayHennyArt();

            do
            {
                switch (Menu.DisplayMainMenu())
                {
                    case MenuEnum.DisplayInventory:
                        var entireMenuList = new MenuView(obj.Menu);
                        entireMenuList.DisplayLiquorMenu();
                        break;
                    case MenuEnum.AddProductToOrder:
                        obj.BuyProduct(obj, customerOrder);
                        customerOrder.CalculateOrderTotal();
                        Console.WriteLine(string.Format("{0} {1:C2} ","Subtotal: ",customerOrder.SubTotal));
                        Console.WriteLine(string.Format("{0} {1:C2} ","Grand Total: ",customerOrder.GrandTotal));                    
                        break;
                    case MenuEnum.LiquorInfoCenter:
                        InfoCenter inf = new InfoCenter("", "");
                        inf.Alcohol();
                        break;
                    case MenuEnum.CashOut:
                        // Display customerOrder
                        CalculateOrderTotal orderCalculations = new CalculateOrderTotal(customerOrder);
                        Console.WriteLine(string.Format("{0} {1:C2} ", "Subtotal: ", orderCalculations.subtotal));
                        Console.WriteLine(string.Format("{0} {1:C2} ", "Grand Total: ", orderCalculations.grandTotal));
                        Console.WriteLine();
                        
                        PaymentType paymentobj = new PaymentType();
                        paymentobj.PaymentOption();
                        break;
                    case MenuEnum.Quit:
                        Console.WriteLine("Bye!");
                        userWantsToQuit = true;
                        break;
                    default:
                        Console.WriteLine("Try again");
                        break;
                }

                Console.WriteLine("\n... press any key to continue ...");
                Console.ReadKey();

            } while (userWantsToQuit.Equals(false));

            Console.ReadLine();
        }


    }
}
