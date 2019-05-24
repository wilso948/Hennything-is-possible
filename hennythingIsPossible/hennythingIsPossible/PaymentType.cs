using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace hennythingIsPossible
{

    public class PaymentType
    {
        public string creditExperition { get; set; }
        public string cvv { get; set; }
        public string creditNumber { get; set; }
        public double input;
        public string userRouting { get; set; }
        public string userAccount { get; set; }
        public PaymentType()
        {

        }
        //public void PaymentOption()
        //{
        //    //string paymentMathod = "";
        //    bool run = true;
        //    while (run == true)
        //    {
        //        Console.WriteLine("How would you like to pay?\n1.) Cash\n2.) Credit Card\n3.) Check");
        //        Console.WriteLine();
        //        int input = 0;
               
        //        bool option = int.TryParse(Console.ReadLine(), out input);

        //        if (option == false)
        //        {
        //            Console.WriteLine("Sorry didn't understand input!");
        //            run = true;
        //        }
        //        else if (input >= 1 && input <= 3)
        //        {
        //            run = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("I'm sorry! That was an invalid option.");
        //            run = true;
        //        }
        //        if (input == 1)
        //        {
        //            Cash();
        //            //paymentMathod = "Cash";
        //        }
        //        else if (input == 2)
        //        {
        //            CreditCard();
        //            //paymentMathod = "Credit Card";

        //        }
        //        else if (input == 3)
        //        {

        //            Check();
        //            //paymentMathod = "Check";
        //        }
        //    }
        //    //return paymentMathod;

        //}
        //public void Check()
        //{
        //    Regex routing = new Regex("^[0-9]{8,10}$");
        //    Regex account = new Regex("^[0-9]{10,17}$");

        //    Console.WriteLine("Please enter in your routing number.(8-10 digits)");
        //    userRouting = Console.ReadLine();

        //    Match validRouting = routing.Match(userRouting);
        //    if (validRouting.Success)
        //    {
        //        Console.WriteLine("Please enter in your account number. (10-17 digits) ");
        //        userAccount = Console.ReadLine();
        //        Match validAccount = account.Match(userAccount);
        //        if (validAccount.Success)
        //        {
        //            Console.WriteLine("valid");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid");
        //            PaymentOption();
        //        }

        //    }
        //    else
        //    {
        //        Console.WriteLine("Invalid.");
        //        PaymentOption();
        //    }

        //}
        //public double Cash()
        //{
        //    var calc = new CalculateOrderTotal();
        //    bool checkcash = true;
        //    while (checkcash == true)
        //    {
        //        Console.WriteLine("Please enter the payment amount : ");
        //        bool checkinput = double.TryParse(Console.ReadLine(), out input);
        //        if (checkinput == false)
        //        {
        //            Console.WriteLine("You entered invalid amount!");
        //            checkcash = true;
        //        }
        //        else if (calc.EnoughFunds(input))
        //        {
        //            Console.WriteLine("Enough funds");
        //            checkcash = false;
        //        }
        //        else
        //        {
        //            Console.WriteLine("the payment amount wasn't enough!! .");
        //            checkcash = true;
        //        }
        //    }
        //    return input;
        //}
        //public void CreditCard()
        //{
        //    bool checkout = true;
        //    while (checkout)
        //    {
        //        Console.WriteLine("Please enter your credit card number:");
        //        Regex cardNumber = new Regex(@"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$");
        //        Regex cardExpiration = new Regex(@"^((0[1-9])|(1[0-2]))\/((2019)|(202[0-9]))$");
        //        Regex cardCvv = new Regex(@"^[0-9]{3,4}$");

        //        //string creditExperition;
        //        //string cvv;
        //        creditNumber = Console.ReadLine();
        //        Match validateCreditNumber = cardNumber.Match(creditNumber);

        //        if (validateCreditNumber.Success)
        //        {
        //            Console.WriteLine("The card number entered is vaild");
        //            Console.WriteLine();
        //            Console.WriteLine("Please enter the credit card expiration in the form of(MM/YYYY)");
        //            creditExperition = Console.ReadLine();
        //            Match expiration = cardExpiration.Match(creditExperition);
        //            if (expiration.Success)
        //            {
        //                Console.WriteLine("valid");
        //                Console.WriteLine();
        //                Console.WriteLine("Please enter the credit card CVV");
        //                cvv = Console.ReadLine();
        //                Match validateCvv = cardCvv.Match(cvv);
        //                if (validateCvv.Success)
        //                {
        //                    Console.WriteLine("valid");
        //                    break;
        //                }
        //                else
        //                {
        //                    Console.WriteLine("invalid CVV number.");
        //                    Console.WriteLine("Decline");
        //                    PaymentOption();
        //                    break;
        //                }
        //            }
        //            else

        //            {
        //                Console.WriteLine("invalid expiration date.");
        //                Console.WriteLine("Decline");
        //                PaymentOption();
        //                break;

        //            }



        //        }
        //        else
        //        {
        //            Console.WriteLine("invalid credit card number.");
        //            Console.WriteLine("Decline");
        //            PaymentOption();
        //            break;
        //        }
        //    }

        //}
    }
}

