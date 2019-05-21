using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hennythingIsPossible
{
    public class Inventory
    {
        public static string ImportFileToString()
        {
            string entireFileString = null;
            try
            {
                // Open the text file using a stream reader.
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "\\fileName.txt");
                using (StreamReader stream = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "HennyFile.txt")))
                {
                    // Read the stream to a string, and write the string to the console.
                    entireFileString = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entireFileString;
        }

        public static List<Liquor> CreateInventoryList(string inventoryString)
        {
            var inventoryList = new List<Liquor>();
            var result = inventoryString.Split(new string[] { "\n" }, StringSplitOptions.None);

            foreach (var item in result)
            {
                var liquorDetail = item.Split(",");
                var liqour = new Liquor(liquorDetail[0], liquorDetail[1], liquorDetail[2], double.Parse(liquorDetail[3]));
                inventoryList.Add(liqour);
            }
            return inventoryList;

        }
    }
}
