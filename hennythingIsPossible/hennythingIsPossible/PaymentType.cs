using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace hennythingIsPossible
{

    public class PaymentType
    {
        public Enum PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public Enum PaymentStatus { get; set; }

        public double AmountPaid { get; set; }

        public string CreditCardExpiration { get; set; }

        public string CreditCardCvv { get; set; }

        public string CreditCardNumber { get; set; }

        public double userEnteredCash;

        public string CheckRoutingNumber { get; set; }

        public string CheckAccountNumber { get; set; }


    }
}

