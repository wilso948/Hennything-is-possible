using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class InfoCenter
    {
        string Name { get; set; }
        string Definition { get; set; }
        string Example { get; set; }

        List<InfoCenter> Types = new List<InfoCenter>();

        public InfoCenter()
        {

        }

        public InfoCenter(string name, string definition, string example)
        {
            this.Name = name;
            this.Definition = definition;
            this.Example = example;
        }

        public void Alcohol()
        {
            ConsoleColor color = ConsoleColor.Green;
            Console.ForegroundColor = color;
            Console.Clear();
            Types.Add(new InfoCenter("Rum", "Rum is a distilled alcoholic drink made from sugarcane byproducts, such as molasses, or directly from sugarcane juice, by a process of fermentation and distillation. The distillate, a clear liquid, is then usually aged in oak barrels", "Ginger beer and lime make just about anything taste good, and seem especially well suited to sweet - and - spicy dark rum.This adult soda beverage pairs well with BBQs, sunny afternoons, and Instagram.Combine ginger beer and rum in a tall glass over ice, garnish with a lime wedge."));
            Types.Add(new InfoCenter("Vodka", "Vodka is a clear distilled alcoholic beverage originating from Poland and Russia, composed primarily of water and ethanol, but sometimes with traces of impurities and flavorings. ", "Pour 50ml mandarin vodka into a shaker with 1 tbsp orange liqueur, 1 tbsp lime juice and 50ml cranberry juice. Fill up the shaker with ice then shake hard. Strain in to a martini glass and garnish with a slice of orange zest."));
            Types.Add(new InfoCenter("Gin", "Gin is a distilled alcoholic drink that derives its predominant flavour from juniper berries. Gin is one of the broadest categories of spirits, all of various origins, styles, and flavour profiles, that revolve around juniper as a common ingredient", "Put the lime and gin in a highball glass filled with ice. Add soda to top and stir. Combine all ingredients in a cocktail shaker with ice. Shake well, then strain into a cocktail glass with a maraschino cherry."));
            Types.Add(new InfoCenter("Tequila", "Tequila is a regional distilled beverage and type of alcoholic drink made from the blue agave plant, primarily in the area surrounding the city of Tequila, 65 km northwest of Guadalajara, and in the Jaliscan Highlands of the central western Mexican state of Jalisco", "Combine the tequila (reposado, preferably), lime juice, and salt in a tall glass. Add ice, top off with grapefruit soda, and stir. Shake well with cracked ice, then strain into a chilled cocktail glass and garnish with a twist of lemon peel."));
            Types.Add(new InfoCenter("Brandy", "Brandy is a spirit produced by distilling wine. Brandy generally contains 35–60% alcohol by volume and is typically drunk as an after-dinner digestif. Some brandies are aged in wooden casks.", "Mix brandy with cranberry juice and serve in a martini glass for a sweet, colorful cocktail. Mix in a shot of triple sec and garnish with a twist of lime peel for an alternative version of the chic cosmopolitan. Use any variety of cranberry juice cocktail to add a hint of another flavor,"));
            Types.Add(new InfoCenter("Whiskey", "Whisky or whiskey is a type of distilled alcoholic beverage made from fermented grain mash. Various grains are used for different varieties, including barley, corn, rye, and wheat. Whisky is typically aged in wooden casks, generally made of charred white oak.", "Combine espresso, bourbon, simple syrup, and bitters in a shaker and fill with ice. Stir with a bar spoon for 30 seconds and strain into a rocks glass filled with ice. Twist lemon peel over the drink and rub around the rim of the glass."));
            bool run = true;
            while (run)
            {
                int index = 1; 
                Console.WriteLine("Which one would you like to learn about?");
                

                foreach (var item in Types)
                {
                    Console.WriteLine(index + ".) " + item.Name);
                    index++;
                }
                Console.WriteLine("");
                Console.Write("Enter a number: ");

                int userInput = int.Parse(Console.ReadLine());

                Console.WriteLine("");

                Console.WriteLine("{1}. Hit enter to see an example", Types[userInput - 1].Name, Types[userInput - 1].Definition, Types[userInput - 1].Example);
                Console.ReadLine();
                color = ConsoleColor.Yellow;
                Console.ForegroundColor = color;
                Console.WriteLine(Types[userInput -1].Example);


                Console.WriteLine("Do you want to run it again? (y/n)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "n")
                {
                    run = false; 
                }
                
            }


        }
    }
}

