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
            Regex routing = new Regex("^[0-9]{8,10}$");
            Regex account = new Regex("^[0-9]{10,17}$");

            Console.Write("Please enter in your routing number (8-10 digits): ");
            CheckRoutingNumber = Console.ReadLine();

            Match validRouting = routing.Match(CheckRoutingNumber);
            if (validRouting.Success)
            {
                Console.Write("Please enter in your account number (10-17 digits): ");
                CheckAccountNumber = Console.ReadLine();
                Match validAccount = account.Match(CheckAccountNumber);
                if (validAccount.Success)
                {
                    Console.WriteLine("Check Information Valid");
                    orderCalculation.AmountPaid = orderCalculation.GrandTotal;
                    PaymentMethod = PaymentMethodEnum.Check;
                    PaymentDate = DateTime.Now;
                    PaymentStatus = PaymentStatusEnum.Complete;
                }
                else
                {
                    Console.WriteLine("Account Number Invalid");
                    SelectPaymentMethod(orderCalculation);
                }

            }
            else
            {
                Console.WriteLine("Account Number Invalid.");
                SelectPaymentMethod(orderCalculation);
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
                    Console.WriteLine("the payment amount wasn't enough!! .");
                    checkcash = true;
                }
            }
            return userEnteredCash;
        }

        public void ProcessCreditCardPayment(CalculateOrderTotal orderCalculation)
        {
            bool checkout = true;
            while (checkout)
            {
                
                Regex cardNumber = new Regex(@"(^[0-9]{16})$");
                Regex cardExpiration = new Regex(@"(0[1-9]|10|11|12)/[2]{1}[0-9]{3}$");
                Regex cardCvv = new Regex(@"(^[0-9]{3})$");

                Console.Write("Please enter your credit card number (16 digits, no symbols): ");
                CreditCardNumber = Console.ReadLine();
                Match validateCreditNumber = cardNumber.Match(CreditCardNumber);

                if (validateCreditNumber.Success)
                {
                    Console.WriteLine("The card number entered is valid");
                    Console.WriteLine();
                    Console.Write("Please enter the credit card expiration (MM/YYYY): ");
                    CreditCardExpiration = Console.ReadLine();
                    Match expiration = cardExpiration.Match(CreditCardExpiration);
                    if (expiration.Success)
                    {
                        Console.WriteLine("valid");
                        Console.WriteLine();
                        Console.Write("Please enter the 3-digit credit card CVV: ");
                        CreditCardCvv = Console.ReadLine();
                        Match validateCvv = cardCvv.Match(CreditCardCvv);
                        if (validateCvv.Success)
                        {
                            Console.WriteLine("valid");
                            PaymentMethod = PaymentMethodEnum.CreditCard;
                            orderCalculation.AmountPaid = orderCalculation.GrandTotal;
                            PaymentDate = DateTime.Now;
                            PaymentStatus = PaymentStatusEnum.Complete;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("invalid CVV number.");
                            Console.WriteLine("Decline");
                            SelectPaymentMethod(orderCalculation);
                            break;
                        }
                    }
                    else

                    {
                        Console.WriteLine("invalid expiration date.");
                        Console.WriteLine("Decline");
                        SelectPaymentMethod(orderCalculation);
                        break;

                    }

                }
                else
                {
                    Console.WriteLine("invalid credit card number.");
                    Console.WriteLine("Decline");
                    SelectPaymentMethod(orderCalculation);
                    break;
                }
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
