using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class OrderedItems
    {

        private string name;
        public string Name { get { return name; } }
        private double price;
        public double Price { get { return price; } }
        public int Quantity { get; set; }
        public OrderedItems(string name, double price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.Quantity = quantity;
        }

    }
}

