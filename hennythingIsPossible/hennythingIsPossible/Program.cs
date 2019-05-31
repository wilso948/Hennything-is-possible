using System;
using System.IO;
using System.Reflection;

namespace hennythingIsPossible
{
    class Program
    {
        static void Main(string[] args)
        {

            var startNewOrder = false;
            do
            {
                startNewOrder =  HennyApp.Run();

            } while (startNewOrder == true);

        }
    }
}

