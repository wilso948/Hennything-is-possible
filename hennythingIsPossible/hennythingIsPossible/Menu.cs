using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Menu
    {
        public static Enum DisplayMainMenu(OrderedItems order, CalculateOrderTotal calculatedOrder)
        {
            Console.Clear();

            HennyArt.DisplayHennyArt();
            MenuView.DisplayCartSummary(order, calculatedOrder);
            ConsoleColor color = ConsoleColor.Magenta;
            Console.ForegroundColor = color;
            Console.WriteLine();
            Console.WriteLine("-- Main Menu --");
            color = ConsoleColor.Yellow;
            Console.ForegroundColor = color;
            Console.WriteLine("1). Display Inventory");
            Console.WriteLine("2). Add Product to Order");
            Console.WriteLine("3). Liquor Info Center");
            Console.WriteLine("4). Cash Out");
            Console.WriteLine("5). New Order");
            Console.WriteLine("6). Quit");

            Console.WriteLine();
            Console.Write("Select an option: ");

            if (Enum.TryParse<MenuEnum>(Console.ReadLine(), out var userMenuSelection))
            {
                return userMenuSelection;
            }
            return null;
        }
    }
}
