using System;

namespace hennythingIsPossible
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller obj = new Controller();
            //InfoCenter inf = new InfoCenter("", "");
            //inf.Alcohol();

            //obj.FilterListByCategory(obj.Menu, "rum");
            var filteredList = obj.FilterListByCategory(obj.Menu, "rum");

            foreach (var item in filteredList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
            }

            Console.ReadLine();

            obj.PickAlcoholFromFilteredList(filteredList);

            Console.WriteLine($"{obj.currentalcoholPick.Name} has been added.");

            Console.ReadLine();
        }
    }
}

