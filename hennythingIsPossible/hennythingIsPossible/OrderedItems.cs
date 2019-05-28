using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class OrderedItems
    {
        //public OrderedItems(List<Liquor> liquorList)
        //{
        //    LiquorOrderList = liquorList;
        //}
        public List<Liquor> LiquorOrderList { get; set; }

        public string PaymentType { get; set; }
        // public int Quantity { get; set; }

        public double SubTotal { get; set; }

        public double SalesTaxAmount { get; set; }

        public double GrandTotal { get; set; }

        public string CheckNumber { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardExpiration { get; set; }

        public string CreditCardCvv { get; set; }

        public OrderedItems()
        {
            LiquorOrderList = new List<Liquor>();
        }

        // public Totals()
        //{
        //    List<double> costs = new List<double>();
        //    SubTotal = 0;
        //    SalesTaxAmount = 0.06;
        //    GrandTotal = 0;

        public void RecalculateOrderTotals()
            {
            SubTotal = 0;
            GrandTotal = 0;
                //logic to calculate subtotals and set properties:
                //foreach item in LiquorOrderList, Subtotal = item.Price + Subtotal
                foreach (var liquor in LiquorOrderList)
                {
                    SubTotal = liquor.Price + SubTotal;
                }

                GrandTotal = SubTotal + (SalesTaxAmount * SubTotal);
            }

        }
    }






        
    


