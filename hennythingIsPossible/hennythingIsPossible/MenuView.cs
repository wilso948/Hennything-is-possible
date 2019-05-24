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

        public void DisplayLiquorMenu()
        {
            int i = 0;
            string s = string.Format("{0,-4}{1,-30} {2,-10} {3, -20} {4, -8}", "", "Name", "Category", "Description", "Price");

            Console.WriteLine(s);

            foreach (Liquor item in Items)
            {
                string b = string.Format("{0,-4}{1,-30} {2,-10} {3, -20} {4, -8:C2}", i + 1 + ".)", item.Name, item.Category, item.Description, item.Price);
                Console.WriteLine(b);
                i++;
            }
        }
    }
}
