using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class InfoCenter
    {
        string Name { get; set; }
        string Definition { get; set; }

        public InfoCenter(string name, string definition)
        {
            this.Name = name;
            this.Definition = definition;
        }
        List<InfoCenter> Types = new List<InfoCenter>();

        public void Alcohol()
        {
            Console.Clear();
            Types.Add(new InfoCenter("Rum", "Rum is a distilled alcoholic drink made from sugarcane byproducts, such as molasses, or directly from sugarcane juice, by a process of fermentation and distillation. The distillate, a clear liquid, is then usually aged in oak barrels"));
            Types.Add(new InfoCenter("Vodka", "Vodka is a clear distilled alcoholic beverage originating from Poland and Russia, composed primarily of water and ethanol, but sometimes with traces of impurities and flavorings. "));
            Types.Add(new InfoCenter("Gin", "Gin is a distilled alcoholic drink that derives its predominant flavour from juniper berries. Gin is one of the broadest categories of spirits, all of various origins, styles, and flavour profiles, that revolve around juniper as a common ingredient"));
            Types.Add(new InfoCenter("Tequila", "Tequila is a regional distilled beverage and type of alcoholic drink made from the blue agave plant, primarily in the area surrounding the city of Tequila, 65 km northwest of Guadalajara, and in the Jaliscan Highlands of the central western Mexican state of Jalisco"));
            Types.Add(new InfoCenter("Brandy", "Brandy is a spirit produced by distilling wine. Brandy generally contains 35–60% alcohol by volume and is typically drunk as an after-dinner digestif. Some brandies are aged in wooden casks."));
            Types.Add(new InfoCenter("Whiskey", "Whisky or whiskey is a type of distilled alcoholic beverage made from fermented grain mash. Various grains are used for different varieties, including barley, corn, rye, and wheat. Whisky is typically aged in wooden casks, generally made of charred white oak."));
            bool run = true;
            while (run)
            {
                int index = 1; // we gotta figure out a way to start the index at 1 so it shows 1 on the screen
                Console.WriteLine("Which one would you like to learn about?");

                foreach (var item in Types)
                {
                    Console.WriteLine(index + ".) " + item.Name);
                    index++;
                }

                int userInput = int.Parse(Console.ReadLine());
                
                Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                Console.ReadLine();

                //if (userInput == 1)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                //else if (userInput == 2)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                //else if (userInput == 3)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                //else if (userInput == 4)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                //else if (userInput == 5)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                //else if (userInput == 6)
                //{
                //    Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition);
                //    Console.ReadLine();

                //}
                Console.WriteLine("Do you want to run it again? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "n")
                {
                    run = false; // we need to make sure we dont fall into a loop here!!!!
                }
            }


        }
    }
}

