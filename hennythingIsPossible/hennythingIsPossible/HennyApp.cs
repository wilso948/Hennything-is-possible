﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class HennyApp
    {

        public static void Run()
        {
            DisplayLogo.DisplayLogoArt();
            InfoCenter infoCenter = new InfoCenter();
            Controller obj = new Controller();
            OrderedItems customerOrder = new OrderedItems();
            CalculateOrderTotal orderCalculations = new CalculateOrderTotal(customerOrder);
            customerOrder.SalesTaxAmount = 0.06;
            bool userWantsToQuit = false;
         
            do
            {
                switch (Menu.DisplayMainMenu(customerOrder, orderCalculations))
                {
                    case MenuEnum.DisplayInventory:
                        var entireMenuList = new MenuView(obj.Menu);
                        entireMenuList.DisplayLiquorMenu();
                        break;
                    case MenuEnum.AddProductToOrder:
                        obj.BuyProduct(obj, customerOrder);
                        customerOrder.RecalculateOrderTotals();                 
                        break;
                    case MenuEnum.LiquorInfoCenter:
                        infoCenter.Alcohol();
                        break;
                    case MenuEnum.CashOut:
                        customerOrder.RecalculateOrderTotals();
                        Receipt receiptObj = new Receipt(orderCalculations);
                        orderCalculations.Totals();
                        MenuView.DisplayCheckoutCart(receiptObj, orderCalculations);
                        receiptObj.SelectPaymentMethod(orderCalculations);                
                        MenuView.DisplayTransactionRecord(receiptObj, orderCalculations);
                       
                        break;
                    case MenuEnum.Quit:
                        Console.WriteLine("\nBye!");
                        userWantsToQuit = true;
                        break;
                    default:
                        Console.WriteLine("\nTry again");
                        break;
                }

                Console.WriteLine("\n... press any key to continue ...");
                Console.ReadKey();

            } while (userWantsToQuit.Equals(false));

            Console.ReadLine();
        }
    }
}
