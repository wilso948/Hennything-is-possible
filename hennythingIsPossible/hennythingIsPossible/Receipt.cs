using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class Receipt : PaymentType
    {
        //CalculateOrderTotal calculation;
        //List<Liquor> LiquorOrderedList;

        //added List<liquor> property for the Receipt object
        public List<Liquor> LiquorListForReceipt { get; set; }

        public Receipt()
        {
            //this.calculation = calculation;

            var LiquorOrderedList = new List<Liquor>();
            var calculations = new CalculateOrderTotal();
            LiquorOrderedList = calculations.liquorOrderList;
        }

        //added a new constructor to take in an OrderedItem object -mattyo
        public Receipt(OrderedItems orderedItems)
        {
            LiquorListForReceipt = orderedItems.LiquorOrderList;
           
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
