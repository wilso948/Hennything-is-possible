using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    class PaymentMethods
    {
        public PaymentMethods()
        {
            var order = new Order();
        }

        public void PaymentMethod()
        {
            Console.WriteLine("Would you like to pay with Cash, Credit, or Check? (Or enter 1/2/3 respectively.");
            var paymentChoice = Console.ReadLine();
            if(Enum.TryParse<PaymentType>(paymentChoice,out PaymentType validPaymentChoice))
            {
                switch (validPaymentChoice)
                {
                    case PaymentType.Cash:
                        //PayWithCash();
                        break;
                    case PaymentType.Credit:
                        //PayWithCreditCard();
                        break;
                    case PaymentType.Check:
                        //PayWithCheck();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
            }
        }
    }
}
