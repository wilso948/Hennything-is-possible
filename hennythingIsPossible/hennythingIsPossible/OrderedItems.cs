using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class OrderedItems
    {
        public OrderedItems()
        {
            LiquorOrderList = new List<Liquor>();
        }

        public OrderedItems(List<Liquor> liquorList)
        {
            LiquorOrderList = liquorList;
        }
        public List<Liquor> LiquorOrderList { get; set; }

        public Enum PaymentType { get; set; }

        public double Subtotal { get; set; }

        public double SalesTaxAmount { get; set; }

        public double GrandTotal { get; set; }

        public string CheckNumber { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardExpiration { get; set; }

        public string CreditCardCvv { get; set; }

        public void CalculateSubtotal()
        {
            //logic to calculate subtotals and set properties:
            //foreach item in LiquorOrderList, Subtotal = item.Price + Subtotal
            //GrandTotal = SubTotal + (SalesTaxAmount * SubTotal)
        }

    }
}

