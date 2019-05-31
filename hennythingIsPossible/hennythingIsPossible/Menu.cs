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
           // color = ConsoleColor.Green;
           // Console.ForegroundColor = color;
            Console.WriteLine("2). Add Product to Order");
            //color = ConsoleColor.Magenta;
            //Console.ForegroundColor = color;
            Console.WriteLine("3). Liquor Info Center");
            //color = ConsoleColor.DarkYellow;
           // Console.ForegroundColor = color;
            Console.WriteLine("4). Cash Out");
           // color = ConsoleColor.Blue;
           // Console.ForegroundColor = color;
            Console.WriteLine("5). New Order");
            Console.WriteLine("6). Quit");

            Console.WriteLine();
           // color = ConsoleColor.DarkMagenta;
           // Console.ForegroundColor = color;
            Console.Write("Select an option: ");

            if (Enum.TryParse<MenuEnum>(Console.ReadLine(), out var userMenuSelection))
            {
                return userMenuSelection;
            }
            return null;
        }
    }
}
