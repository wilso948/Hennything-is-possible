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

        public void SelectPaymentMethod()
        {

            //add evaluation if paymentstatus = paymentstatusenum.pending then run logic. else "already paid"

            bool run = true;
            while (run == true)
            {
                Console.WriteLine("How would you like to pay?\n1.) Cash\n2.) Credit Card\n3.) Check");
                Console.WriteLine();
                int input = 0;

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
                    ProcessCashPayment();
                    PaymentMethod = PaymentMethodEnum.Cash;
                    PaymentStatus = PaymentStatusEnum.Complete;

                }
                else if (input == 2)
                {
                    ProcessCreditCardPayment();
                    PaymentMethod = PaymentMethodEnum.CreditCard;
                    PaymentStatus = PaymentStatusEnum.Complete;


                }
                else if (input == 3)
                {
                    ProcessCheckPayment();
                    PaymentMethod = PaymentMethodEnum.Check;
                    PaymentStatus = PaymentStatusEnum.Complete;
                    Console.WriteLine(CheckRoutingNumber);
                    Console.WriteLine(CheckAccountNumber);
                }
            }

        }

        //public void CashReciept()
        //{
        //    ProcessCashPayment();
        //    //Console.WriteLine();

        //    foreach (var item in LiquorListForReceipt)
        //    {
        //        Console.WriteLine((string.Format("{0} {1:C2}", item.Name, item.Price)));

        //    }
        //}

        //public void CreditCardReciept()
        //{
        //    ProcessCreditCardPayment();
        //    Console.WriteLine(CreditCardCvv);
        //    Console.WriteLine(CreditCardExpiration);
        //    Console.WriteLine(CreditCardNumber);

        //    foreach (var item in LiquorListForReceipt)
        //    {
        //        Console.WriteLine((string.Format("{0} {1:C2}", item.Name, item.Price)));

        //    }
        //}

        //public void CheckReciept()
        //{
        //    ProcessCheckPayment();
        //    Console.WriteLine(CheckRoutingNumber);
        //    Console.WriteLine(CheckAccountNumber);

        //    foreach (var item in LiquorListForReceipt)
        //    {
        //        Console.WriteLine((string.Format("{0} {1:C2}", item.Name, item.Price)));

        //    }
        //}

        public void ProcessCheckPayment()
        {
            Regex routing = new Regex("^[0-9]{8,10}$");
            Regex account = new Regex("^[0-9]{10,17}$");

            Console.WriteLine("Please enter in your routing number.(8-10 digits)");
            CheckRoutingNumber = Console.ReadLine();

            Match validRouting = routing.Match(CheckRoutingNumber);
            if (validRouting.Success)
            {
                Console.WriteLine("Please enter in your account number. (10-17 digits) ");
                CheckAccountNumber = Console.ReadLine();
                Match validAccount = account.Match(CheckAccountNumber);
                if (validAccount.Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("Invalid");
                    SelectPaymentMethod();
                }

            }
            else
            {
                Console.WriteLine("Invalid.");
                SelectPaymentMethod();
            }

        }

        public double ProcessCashPayment()
        {
            var calc = new CalculateOrderTotal();
            bool checkcash = true;
            while (checkcash == true)
            {
                Console.WriteLine("Please enter the payment amount : ");
                bool isUserEnteredCashADouble = double.TryParse(Console.ReadLine(), out userEnteredCash);
                if (isUserEnteredCashADouble == false)
                {
                    Console.WriteLine("You entered invalid amount!");
                    checkcash = true;
                }
                else if (calc.DoesUserHaveEnoughCashFunds(userEnteredCash))
                {
                    Console.WriteLine("Enough funds");
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

        public void ProcessCreditCardPayment()
        {
            bool checkout = true;
            while (checkout)
            {
                Console.WriteLine("Please enter your credit card number:");
                Regex cardNumber = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$");
                Regex cardExpiration = new Regex(@"^((0[1-9])|(1[0-2]))\/((2019)|(202[0-9]))$");
                Regex cardCvv = new Regex(@"^[0-9]{3,4}$");

                //string creditExperition;
                //string cvv;
                CreditCardNumber = Console.ReadLine();
                Match validateCreditNumber = cardNumber.Match(CreditCardNumber);

                if (validateCreditNumber.Success)
                {
                    Console.WriteLine("The card number entered is vaild");
                    Console.WriteLine();
                    Console.WriteLine("Please enter the credit card expiration in the form of(MM/YYYY)");
                    CreditCardExpiration = Console.ReadLine();
                    Match expiration = cardExpiration.Match(CreditCardExpiration);
                    if (expiration.Success)
                    {
                        Console.WriteLine("valid");
                        Console.WriteLine();
                        Console.WriteLine("Please enter the credit card CVV");
                        CreditCardCvv = Console.ReadLine();
                        Match validateCvv = cardCvv.Match(CreditCardCvv);
                        if (validateCvv.Success)
                        {
                            Console.WriteLine("valid");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("invalid CVV number.");
                            Console.WriteLine("Decline");
                            SelectPaymentMethod();
                            break;
                        }
                    }
                    else

                    {
                        Console.WriteLine("invalid expiration date.");
                        Console.WriteLine("Decline");
                        SelectPaymentMethod();
                        break;

                    }



                }
                else
                {
                    Console.WriteLine("invalid credit card number.");
                    Console.WriteLine("Decline");
                    SelectPaymentMethod();
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

            //foreach (var receiptLineItem in ReceiptLineItemsList)
            //{
            //    Console.WriteLine($"id: {receiptLineItem.LiquorId}, n: {receiptLineItem.LiquorName}, q: {receiptLineItem.Quantity}, p: {receiptLineItem.UnitPrice}, t: {receiptLineItem.LineItemSubtotal}");
            //}
            //Console.WriteLine();

        }
    }
}
