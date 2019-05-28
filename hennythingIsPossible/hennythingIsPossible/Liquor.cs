using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Liquor
    {
        public int LiquorId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Counter { get; set; }


        public Liquor(int liquorId, string name, string category, string description, double price)
        {
            this.LiquorId = liquorId;
            this.Name = name;
            this.Category = category;
            this.Description = description;
            this.Price = price;
            Counter++;

        }
    }
}

