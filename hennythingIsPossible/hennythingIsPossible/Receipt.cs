using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Receipt : PaymentType
    {
        //CalculateOrderTotal calculation;
        //List<Liquor> LiquorOrderedList;
        

        public Receipt()
        {
            //this.calculation = calculation;

            var LiquorOrderedList = new List<Liquor>();
            var calculations = new CalculateOrderTotal();
            LiquorOrderedList = calculations.liquorOrderList;
        }

        public void CashReciept()
        {
            Cash();
            Console.WriteLine();
        }

        public void CreditCardReciept()
        {
            CreditCard();
            Console.WriteLine(cvv);
            Console.WriteLine(creditExperition);
            Console.WriteLine(creditNumber);
        }

        public void CheckReciept()
        {
            Check();
        }
    }
}
