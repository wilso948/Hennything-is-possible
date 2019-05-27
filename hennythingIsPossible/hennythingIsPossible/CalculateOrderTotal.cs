using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hennythingIsPossible
{
   public class CalculateOrderTotal 
    {

        //PaymentType obj = new PaymentType(); 
        public double subtotal;
        public double salesTax;
        public double grandTotal;
        public double cashAmount;
        public double changeCash;
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
            subtotal = 0;
            salesTax = 0.06;
            grandTotal = 0;

            foreach (var liquor in liquorOrderList)
            {
                subtotal = liquor.Price + subtotal;    
            }
            costs.Add(subtotal);
            double sum = costs.Sum();
            double amountOfSalesTax = Math.Round(sum * salesTax, 2);
            grandTotal =sum + amountOfSalesTax;

        }


        public bool EnoughCashFunds(double cashAmount)
        {
            if (cashAmount < grandTotal)
            {
                return false;
            }
            else
            {
                changeCash = cashAmount - grandTotal;
                this.cashAmount = cashAmount;
                return true;
            }
        }
    }
}
