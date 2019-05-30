using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class OrderedItems
    {

        public List<Liquor> LiquorOrderList { get; set; }

        public string PaymentType { get; set; }

        public double SubTotal { get; set; }

        public double SalesTaxAmount { get; set; }

        public double GrandTotal { get; set; }

        public OrderedItems()
        {
            LiquorOrderList = new List<Liquor>();
        }

        public void RecalculateOrderTotals()
            {
                SubTotal = 0;
                GrandTotal = 0;

                foreach (var liquor in LiquorOrderList)
                {
                    SubTotal = liquor.Price + SubTotal;
                }
                GrandTotal = SubTotal + (SalesTaxAmount * SubTotal);
            }
        }
    }






        
    


