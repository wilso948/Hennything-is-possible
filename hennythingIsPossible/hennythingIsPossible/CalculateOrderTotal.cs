using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hennythingIsPossible
{
   public class CalculateOrderTotal 
    {

        PaymentType obj = new PaymentType(); 
        public double Subtotal;
        public double SalesTaxPercent;
        public double SalesTaxAmount;
        public double GrandTotal;
        public double CashAmount;
        public double ChangeCash;
        public List<Liquor> liquorOrderList = new List<Liquor>();

        public CalculateOrderTotal(OrderedItems order)
        {
            liquorOrderList = order.LiquorOrderList;
            Totals();
        }
        public CalculateOrderTotal(List<Liquor> liquorOrderList)
        {
            this.liquorOrderList = liquorOrderList;
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

            foreach (var liquor in liquorOrderList)
            {
                Subtotal = liquor.Price + Subtotal;    
            }
            costs.Add(Subtotal);
            double sum = costs.Sum();
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
                this.CashAmount = cashAmount;
                return true;
            }
        }
    }
}
