using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Menu
    {
        public static Enum DisplayMainMenu()
        {
            Console.WriteLine("-- Main Menu --");
            Console.WriteLine("1). Display Inventory");
            Console.WriteLine("2). Add Product to Order");
            Console.WriteLine("3). Liquor Info Center");
            Console.WriteLine("4). Cash Out");
            Console.Write("Select an option: ");

            if (Enum.TryParse<MenuEnum>(Console.ReadLine(), out var userMenuSelection))
            {
                return userMenuSelection;
            }
            return null;
        }
    }
}
