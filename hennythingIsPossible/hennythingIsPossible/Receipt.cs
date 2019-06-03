using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace hennythingIsPossible
{
    public class Receipt : PaymentType
    {

        public List<Liquor> LiquorListForReceipt { get; set; }

        public List<ReceiptLineItem> ReceiptLineItemsList { get; set; }
       


        public Receipt(CalculateOrderTotal calculatedOrder)
        {     
            LiquorListForReceipt = calculatedOrder.LiquorOrderListForCalculations;
            ReceiptLineItemsList = new List<ReceiptLineItem>();
            UpdateReceiptLineItems();
            PaymentStatus = PaymentStatusEnum.Pending;
          
        }

        public void SelectPaymentMethod(CalculateOrderTotal orderCalculation)
        {

            bool run = true;
            while (run == true)
            {
                ConsoleColor color = ConsoleColor.Cyan;
                Console.ForegroundColor = color;
                Console.Write("How would you like to pay?\n1.) Cash\n2.) Credit Card\n3.) Check");
                Console.WriteLine();
                int input = 0;

                color = ConsoleColor.Red;
                Console.ForegroundColor = color;

                bool option = int.TryParse(Console.ReadLine(), out input);

                if (option == false)
                {
                    Console.WriteLine("Sorry didn't understand input!");
                    run = true;
                }
                else if (input >= 1 && input <= 3)
                {
                    run = false;
                }
                else
                {
                    Console.WriteLine("I'm sorry! That was an invalid option.");
                    run = true;
                }
                if (input == 1)
                {                  
                    ProcessCashPayment(orderCalculation);
                }
                else if (input == 2)
                {
                    ProcessCreditCardPayment(orderCalculation);
                }
                else if (input == 3)
                {
                    ProcessCheckPayment(orderCalculation);
                }
            }

        }

        public void ProcessCheckPayment(CalculateOrderTotal orderCalculation)
        {
            bool isRoutingNumberValid = false;
            bool isAccountNumberValid = false;

            isRoutingNumberValid = ValidatePaymentInput("Please enter in your routing number (8-10 digits): ", new Regex("^[0-9]{8,10}$"), 3);

            if (isRoutingNumberValid == true)
            {
                isAccountNumberValid = ValidatePaymentInput("Please enter in your account number (10-17 digits): ", new Regex("^[0-9]{10,17}$"), 3);
            }

            if (isRoutingNumberValid == true && isAccountNumberValid == true)
            {
                Console.WriteLine("Checking Information Valid");
                orderCalculation.AmountPaid = orderCalculation.GrandTotal;
                PaymentMethod = PaymentMethodEnum.Check;
                PaymentDate = DateTime.Now;
                PaymentStatus = PaymentStatusEnum.Complete;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Checking account info failed");
                Console.WriteLine("Please try again ...");
                Console.ReadLine();
            }

        }

        public double ProcessCashPayment(CalculateOrderTotal orderCalculation)
        {
            var calc = new CalculateOrderTotal();
            bool checkcash = true;
            while (checkcash == true)
            {
                Console.Write("Please enter the payment amount: $");
                bool isUserEnteredCashADouble = double.TryParse(Console.ReadLine(), out userEnteredCash);
                if (isUserEnteredCashADouble == false)
                {
                    Console.WriteLine("You entered invalid amount!");
                    checkcash = true;
                }
                else if (orderCalculation.DoesUserHaveEnoughCashFunds(userEnteredCash))
                {
                    Console.WriteLine("Enough funds");
                    PaymentMethod = PaymentMethodEnum.Cash;
                    PaymentDate = DateTime.Now;
                    PaymentStatus = PaymentStatusEnum.Complete;
                    checkcash = false;
                }
                else
                {
                    Console.WriteLine("the payment amount wasn't enough!!");
                    checkcash = true;
                }
            }
            return userEnteredCash;
        }

        public void ProcessCreditCardPayment(CalculateOrderTotal orderCalculation)
        {

            bool isCardNumberValid = false;
            bool isExpirationDateValid = false;
            bool isCardCvvValid = false;

            isCardNumberValid = ValidatePaymentInput("Please enter your credit card number (16 digits, no symbols): ", new Regex(@"(^[0-9]{16})$"), 3 );

            if (isCardNumberValid == true)
            {
                isExpirationDateValid = ValidatePaymentInput("Please enter expiration date (mm/yyyy): ", new Regex(@"(0[1-9]|10|11|12)/[2]{1}[0-9]{3}$"), 3);
            }

            if (isCardNumberValid == true && isExpirationDateValid == true)
            {
                isCardCvvValid = ValidatePaymentInput("Please enter 3-digit CVV: ", new Regex(@"(^[0-9]{3})$"), 3);
            }

            if (isCardNumberValid == true && isExpirationDateValid == true && isCardCvvValid == true)
            {
                Console.WriteLine("Credit card payment successful");
                PaymentMethod = PaymentMethodEnum.CreditCard;
                orderCalculation.AmountPaid = orderCalculation.GrandTotal;
                PaymentDate = DateTime.Now;
                PaymentStatus = PaymentStatusEnum.Complete;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Credit card payment failed");
                Console.WriteLine("Please try again ...");
                Console.ReadLine();
            }

        }

        public bool ValidatePaymentInput(string inputPrompt, Regex pattern, int retryLimit)
        {
            Match validateInput;

            var retryCount = 0;
            do
            {
                Console.Write(inputPrompt);
                validateInput = pattern.Match(Console.ReadLine());
                retryCount++;

            } while (!validateInput.Success && retryCount < retryLimit);

            if (validateInput.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public void UpdateReceiptLineItems()
        {

            ReceiptLineItemsList = LiquorListForReceipt
                .GroupBy(i => i.LiquorId)
                .Select(rl => new ReceiptLineItem
                {
                    LiquorId = rl.First().LiquorId,
                    LiquorName = rl.First().Name,
                    UnitPrice = rl.First().Price,
                    Quantity = rl.Count()
                    
                })
                .ToList();
           
            foreach (var item in ReceiptLineItemsList)
            {
                item.LineItemSubtotal = item.Quantity * item.UnitPrice;
            }

        }
       
    }
}
