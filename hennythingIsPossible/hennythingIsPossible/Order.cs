using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Order
    {
        //no longer used class
        private double _salesTaxRate = 0.06;

        public List<Liquor> LiquorOrderList { get; set; }

        public Enum PaymentType { get; set; }

        public double Subtotal { get; set; }

        public double SalesTaxAmount { get; set; }

        public double GrandTotal { get; set; }

        public string CheckNumber { get; set; }

        public string CreditCardNumber { get; set; }

        public string CreditCardExpiration { get; set; }

        public string CreditCardCvv { get; set; }



    }
}
