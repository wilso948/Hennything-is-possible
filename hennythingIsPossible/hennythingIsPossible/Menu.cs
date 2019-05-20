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
            Console.WriteLine("Display Inventory");
            Console.WriteLine("Add Product to Order");
            Console.WriteLine("Cash Out");
            Console.Write("Select an option: ");

            if (Enum.TryParse<MenuEnum>(Console.ReadLine(), out var userMenuSelection))
            {
                return userMenuSelection;
            }
            return null;
        }
    }
}
