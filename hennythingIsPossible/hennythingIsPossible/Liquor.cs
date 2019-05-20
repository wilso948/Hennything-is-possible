using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Liquor
    {

        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Liquor(string name, string category, string description, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Price = price;

        }
    }
}

