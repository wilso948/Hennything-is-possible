﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hennythingIsPossible
{
   public class CalculateOrderTotal 
    {

        //PaymentType obj = new PaymentType(); 
        public double Subtotal;
        public double SalesTax;
        public double GrandTotal;
        public double CashAmount;
        public double ChangeCash;
        public List<Liquor> liquorOrderList;

        public List<Liquor> LiquorOrderListForCalculations { get; set; }

        public CalculateOrderTotal(OrderedItems order)
        {
            LiquorOrderListForCalculations = order.LiquorOrderList;
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
            SalesTax = 0.06;
            GrandTotal = 0;

            foreach (var liquor in LiquorOrderListForCalculations)
            {
                Subtotal = liquor.Price + Subtotal;
            }
            costs.Add(Subtotal);
            double sum = costs.Sum();
            double amountOfSalesTax = Math.Round(sum * SalesTax, 2);
            GrandTotal = sum + amountOfSalesTax;

            //Subtotal = 0;
            //GrandTotal = 0;
            //foreach (var liquor in LiquorOrderListForCalculations)
            //{
            //    Subtotal = liquor.Price + Subtotal;
            //}

            //GrandTotal = Subtotal + (SalesTax * Subtotal);

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
