using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment1.Exercise12
{
    public class Input
    {
        public int ReadInt(string varName)
        {
            Console.Write($"{varName}: ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid number. Please provide a valid number");
                Console.Write($"{varName}: ");
            }

            return value;
        }

        public int ReadInt(string varName, int minValue)
        {
            Console.Write($"{varName}: ");
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value < minValue)
            {
                Console.WriteLine("Invalid number. Please provide a valid number");
                Console.Write($"{varName}: ");
            }

            return value;
        }

        public decimal ReadDecimal(string varName)
        {
            Console.Write($"{varName}: ");
            decimal value;
            while (!decimal.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid number. Please provide a valid number");
                Console.Write($"{varName}: ");
            }

            return value;
        }
    }
}
