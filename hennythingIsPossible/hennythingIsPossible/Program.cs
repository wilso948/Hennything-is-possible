using System;
using System.IO;
using System.Reflection;

namespace hennythingIsPossible
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller obj = new Controller();
            OrderedItems customerOrder = new OrderedItems();
            
            HennyArt.DisplayHennyArt();

            switch (Menu.DisplayMainMenu())
            {
                case MenuEnum.DisplayInventory:
                    var entireMenuList = new MenuView(obj.Menu);
                    entireMenuList.DisplayLiquorMenu();                
                    break;
                case MenuEnum.AddProductToOrder:
                    var filteredList = obj.FilterListByCategory(obj.Menu, "Rum");
                    obj.PickLiquorFromFilteredList(filteredList);
                    obj.AddAlcoholToOrder(customerOrder, obj.CurrentLiquorPick);
                    customerOrder.CalculateSubtotal();
                    break;
                case MenuEnum.LiquorInfoCenter:
                    InfoCenter inf = new InfoCenter("", "");
                    inf.Alcohol();
                    break;
                case MenuEnum.CashOut:
                    //Display customerOrder
                    //Display payment options, choose payment, process payment
                    break;
                default:
                    break;
            }
       
            Console.ReadLine();


        }
    }
}

