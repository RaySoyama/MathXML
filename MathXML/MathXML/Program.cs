using System;
using System.Collections.Generic;

namespace MathXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //Parse Data
            List<Operation> listOfOperations = XMLParser.LoadXML("math.xml");

            //Print Output
            foreach (Operation operation in listOfOperations)
            {
                Console.WriteLine(operation.CreateOutput());
            }

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter))
            {
                //Stall till enter is pressed
            }
        }
    }
}
