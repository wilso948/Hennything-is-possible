using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class MenuView
    {
        List<Liquor> Items = new List<Liquor>();
        public MenuView(List<Liquor> items)
        {
            this.Items = items;

        }

        public void DisplayMenu()
        {
            int i = 0;
            string s = string.Format("{0,-4}{1,-40} {2,-30} {3, -40} {4, -20}", "", "Name", "Category", "Description", "Price");

            Console.WriteLine(s);

            foreach (Liquor item in Items)
            {
                string b = string.Format("{0,-4}{1,-40} {2,-30} {3, -40} {4, -20}", i + 1 + ".)", item.Name, item.Category, item.Description, item.Price);

                Console.WriteLine(b);
                i++;
            }
        }
    }
}

