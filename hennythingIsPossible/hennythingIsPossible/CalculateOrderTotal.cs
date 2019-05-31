using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hennythingIsPossible
{
   public class CalculateOrderTotal 
    {

        public double Subtotal { get; set; }
        public double SalesTaxPercent { get; set; } 
        public double SalesTaxAmount { get; set; }
        public double GrandTotal { get; set; }
        public double AmountPaid { get; set; }
        public double ChangeCash { get; set; }
        public List<Liquor> liquorOrderList;

        public List<Liquor> LiquorOrderListForCalculations { get; set; }

        public CalculateOrderTotal(OrderedItems order)
        {
            LiquorOrderListForCalculations = order.LiquorOrderList;
            Totals();
        }

        public CalculateOrderTotal()
        {

        }

        public void Totals() 
        {
            List<double> costs = new List<double>();
            Subtotal = 0;
            SalesTaxPercent = 0.06;
            GrandTotal = 0;

            foreach (var liquor in LiquorOrderListForCalculations)
            {
                Subtotal = liquor.Price + Subtotal;
            }
            costs.Add(Subtotal);
            double sum = costs.Sum();

            double amountOfSalesTax = Math.Round(sum * SalesTaxPercent, 2);
            GrandTotal = sum + amountOfSalesTax;

            SalesTaxAmount = Math.Round(sum * SalesTaxPercent, 2);
            GrandTotal =sum + SalesTaxAmount;

        }


        public bool DoesUserHaveEnoughCashFunds(double cashAmount)
        {
            if (cashAmount < GrandTotal)
            {
                return false;
            }
            else
            {
                ChangeCash = cashAmount - GrandTotal;
                this.AmountPaid = cashAmount;
                return true;
            }
        }
    }
}
