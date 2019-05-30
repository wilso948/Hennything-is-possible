using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Controller : OrderedItems
    {

        public List<Liquor> Menu { get; set; }

        public Liquor CurrentLiquorPick { get; set; }

        
        //MenuView obj;
        //ConsoleColor color;

        public Controller()
        {
            Menu = Inventory.CreateInventoryList(Inventory.ImportFileToString());
            LiquorOrderList = new List<Liquor>();

        }

        public void BuyProduct(Controller obj, OrderedItems customerOrder)
        {
            Console.Clear();
            string userInput = null;
            do
            {
                var filteredList = obj.FilterListByCategory(obj.Menu, obj.PromptUserForLiquorType());
                if (filteredList.Count > 0)
                {
                    obj.PickLiquorFromFilteredList(filteredList);
                    obj.AddAlcoholToOrder(customerOrder, obj.CurrentLiquorPick);
                }
                else
                {
                    Console.WriteLine("\nSorry, none in stock.\n");
                }

                Console.Write("Would you like to add more? Choose (Yes or No): ");
                userInput = Console.ReadLine();

            } while (userInput.Equals("yes", StringComparison.OrdinalIgnoreCase));

        }

        public string PromptUserForLiquorType()
        {
            var liquorTypes = Enum.GetValues(typeof(LiquorType));
            foreach (var liquor in liquorTypes)
            {
                Console.WriteLine($"{liquor.ToString()}");
            }
            Console.Write("Pick a liquor: ");

            return Console.ReadLine();

            //add validation so user can enter number instead of type name

        }

        public List<Liquor> FilterListByCategory(List<Liquor> menu, string category)
        {
            var filteredLiquorList = new List<Liquor>();

            foreach (var liquor in menu)
            {
                if (liquor.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    filteredLiquorList.Add(liquor);
                }
            }

            return filteredLiquorList;
        }
        
        public void PickLiquorFromFilteredList(List<Liquor> filteredList)
        {

            MenuView filteredListView = new MenuView(filteredList);
            filteredListView.DisplayLiquorMenu();

            bool userInputValid = false;
            do
            {
                Console.Write($"\nPick an alcohol to choose from the chosen category (1-{filteredList.Count}): ");
                userInputValid = int.TryParse(Console.ReadLine(), out int pickLiquor);
                if (pickLiquor >= 1 && pickLiquor < filteredList.Count && userInputValid)
                {
                    CurrentLiquorPick = filteredList[pickLiquor - 1];
                }
                else
                {
                    Console.WriteLine("Sorry your input is invalid.  Try again!");
                    userInputValid = false;
                }

                //Console.ReadKey();
            } while (userInputValid == false);
           
        }

        public void AddAlcoholToOrder(OrderedItems order, Liquor alcoholPick)
        {
            Console.Write($"How many of {alcoholPick.Name} would you like? Please input a number: ");
            var quantitypick = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantitypick; i++)
            {
                order.LiquorOrderList.Add(alcoholPick);
            }

        }

    }

}

