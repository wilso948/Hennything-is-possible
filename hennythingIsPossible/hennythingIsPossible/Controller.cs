using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Controller : OrderedItems
    {

        public List<Liquor> Menu { get; set; }

        public Liquor CurrentLiquorPick { get; set; }

        
        MenuView obj;
        ConsoleColor color;

        public Controller()
        {
            Menu = Inventory.CreateInventoryList(Inventory.ImportFileToString());
            LiquorOrderList = new List<Liquor>();

            //obj = new MenuView(Menu);
            //obj.DisplayMenu();
            //Console.WriteLine();
            //Order();
        }

        //public void Order()
        //{
        //    List<OrderedItems> OrderedItems = new List<OrderedItems>();//list of ordered items
        //    bool orderAgain = true;
        //    while (orderAgain)
        //    {
        //        int quantityPerItem = 0;
        //        int choice;
        //        //Present a menu to the user and let them choose an item(by number orletter).

        //        Console.WriteLine("What would you like to order?");
        //        Console.WriteLine();
        //        Console.WriteLine("Please choose an item by a number or by a name:");
        //        var userInput = Console.ReadLine(); // I used(var) because We dont know if the user will enter a number or a string
        //        bool gotValue = int.TryParse(userInput, out choice);
        //        if (gotValue == true) //that mean the user choose  an item from the menu by it's number
        //        {
        //            //there are 31 items in the menu (the number should be 1 >= 1 and numbe <= 31 )
        //            if (choice >= 1 && choice <= 31)
        //            {
        //            // Allow the user to choose a quantity for the ordered item.
        //            QuantityCheck:
        //                {

        //                    Console.WriteLine("Please enter the quantity: ");
        //                    bool gotQuanttity = int.TryParse(Console.ReadLine(), out quantityPerItem);
        //                    if (gotQuanttity == false)//if the  user didn't enter a number
        //                    {

        //                        Console.WriteLine("you entered unvalid number for quantity!!");
        //                        goto QuantityCheck;// give the user a nother chance to choose a valid number for quantity
        //                    }
        //                }
        //                OrderedItems.Add(new OrderedItems(Menu[choice - 1].Name, Menu[choice - 1].Price, quantityPerItem));
        //            }
        //            else//the user entered a number that is not in the list
        //            {

        //                Console.WriteLine("This number is not in the menu!!");
        //                continue;// give the user a nother chance to choose from the menu
        //            }
        //        }
        //        else // that mean the user choosed an item from the menu by it's name
        //        {
        //            // check if the item name is in the menu
        //            bool findItem = false;
        //            double pricePerItem = 0;
        //            foreach (Liquor L in Menu)
        //            {
        //                if (userInput == L.Name)
        //                {
        //                    findItem = true;//the item is in the menu
        //                    pricePerItem = L.Price;
        //                }
        //            }
        //            if (findItem == true)
        //            {
        //            quantityCheck:

        //                {

        //                    Console.WriteLine("Please enter the quantity: ");
        //                    bool gotQuanttity = int.TryParse(Console.ReadLine(), out quantityPerItem);
        //                    if (gotQuanttity == false)//if the  user didn't enter a number ex string or a character
        //                    {

        //                        Console.WriteLine("you entered unvalid number for quantity!!");
        //                        goto quantityCheck;// give the user a nother chance to choose a valid number for quantity
        //                    }
        //                    OrderedItems.Add(new OrderedItems(userInput, pricePerItem, quantityPerItem));
        //                }
        //            }
        //            else if (findItem == false)// we don't have this iteam in the menu
        //            {

        //                Console.WriteLine("Sorry we don't have " + userInput);
        //                Console.WriteLine("Please try again");
        //                continue;
        //            }
        //        }
        //    }
        //}

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

            Console.Write($"\nPick an alcohol to choose from the chosen category (1-{filteredList.Count}): ");
            var pickLiquor = int.Parse(Console.ReadLine());

            CurrentLiquorPick = filteredList[pickLiquor - 1];

            //foreach (var item in filteredList)
            //{
            //    if (pickLiquor.Equals(item.Name, StringComparison.OrdinalIgnoreCase))
            //    {
            //        CurrentLiquorPick = item;
            //    }
            //}
            //Console.WriteLine($"{CurrentLiquorPick.Name} has been added.");
        }

        public void AddAlcoholToOrder(OrderedItems order, Liquor alcoholPick)
        {
            Console.WriteLine($"How many of {alcoholPick.Name} would you like? Please input a number.");
            var quantitypick = int.Parse(Console.ReadLine());
            for (int i = 0; i < quantitypick; i++)
            {
                order.LiquorOrderList.Add(alcoholPick);
            }
            //This portion is to verify that the object actually added to the list.
            foreach (var item in order.LiquorOrderList)
            {
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Price);
            }
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

            

        }

        public void BuyProduct(Controller obj, OrderedItems customerOrder)
        {
            //bool userQuit = false;
            string userInput = null;
            do
            {
                var filteredList = obj.FilterListByCategory(obj.Menu, obj.PromptUserForLiquorType());
                obj.PickLiquorFromFilteredList(filteredList);
                obj.AddAlcoholToOrder(customerOrder, obj.CurrentLiquorPick);

                Console.WriteLine("Would you like to add more? Choose (Yes or No):");
                userInput = Console.ReadLine();

                ////if (userInput == "Yes" || userInput == "yes")
                //{
                //    u = true;
                //}

            } while (userInput != "Yes");

        }
    }

}

