using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class CompleteOrder
    {
        public static bool NewOrder()
        {
            Console.WriteLine("Are you sure you want to start a new order? This will clear out your current order. Press y for yes.");
            string response = Console.ReadLine();
            if (response.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
