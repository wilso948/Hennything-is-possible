using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class ReceiptLineItem
    {

        public int LiquorId { get; set; }

        public string LiquorName { get; set; }

        public int Quantity { get; set; }

        public double LineItemSubtotal { get; set; }

        public double UnitPrice { get; set; }

    }
}
