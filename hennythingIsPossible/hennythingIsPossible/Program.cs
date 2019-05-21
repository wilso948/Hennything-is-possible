using System;

namespace hennythingIsPossible
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller obj = new Controller();
            

            switch (Menu.DisplayMainMenu())
            {
                case MenuEnum.DisplayInventory:
                    var entireMenuList = new MenuView(obj.Menu);
                    entireMenuList.DisplayLiquorMenu();                
                    break;
                case MenuEnum.AddProductToOrder:
                    var filteredList = obj.FilterListByCategory(obj.Menu, "Rum");
                    obj.PickLiquorFromFilteredList(filteredList);
                    break;
                case MenuEnum.LiquorInfoCenter:
                    InfoCenter inf = new InfoCenter("", "");
                    inf.Alcohol();
                    break;
                case MenuEnum.CashOut:
                    break;
                default:
                    break;
            }
       
            Console.ReadLine();


        }
    }
}

