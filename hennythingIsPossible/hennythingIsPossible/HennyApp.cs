using System;
using System.Collections.Generic;
using System.Text;

namespace hennythingIsPossible
{
    public class HennyApp
    {
        public static void Run()
        {
            //This is Matt's old stuff. We can get rid of it as we move functionality over to the main stuff. 

            HennyArt.DisplayHennyArt();

            //initialize inventory
            var inventoryList = Inventory.CreateInventoryList(Inventory.ImportFileToString());
            //var customerOrder = new Order();

            //switch case for menu
            //display main menu: 
            //1-display inventory
            DisplayInventoryList(inventoryList);
            //2-add liquor to order
            //3-see order
            //4-cash out

            Console.ReadLine();
        }

        public static void DisplayInventoryList(List<Liquor> inventoryList)
        {
           
            Console.WriteLine($"Total items: {inventoryList.Count}");

            foreach (var item in inventoryList)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Price: {item.Price}");

                Console.WriteLine();
            }
        }

        public static void AddProductToOrder(Order customerOrder, Liquor liquor, int quantity)
        {
            //add liquor to customerOrder, quantity number of times
            //for int i=0, i<quantity, i++ ... customerOrder.LiquorOrderList.Add(liquor);

        }

        public static void DisplayOrder(Order customerOrder)
        {
            //foreach item in customerOrder, display liquor, quanitites, subtotal, salestax, grand total
        }

        public static void ProcessPayment(Order orderList, PaymentType paymentType)
        {
            //if paymentType = PaymentType.Cash, then ask for amount and calculate change
            //if paymentType = Check, then ask for check number
            //if paymentType = Credit, then ask for credit card number, expiration, CVV
            //possibly add order.Status. 
        }

    }
}
