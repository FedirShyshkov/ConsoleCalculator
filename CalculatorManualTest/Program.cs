using ConsoleCalculatorLibrary;
using System;

namespace CalculatorManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ConsoleCalculator();

            string input = Console.ReadLine();

            Console.WriteLine(calculator.Calculate(input));
            Console.ReadKey();
        }
    }
}
