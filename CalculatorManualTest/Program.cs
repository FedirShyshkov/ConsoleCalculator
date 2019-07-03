using ConsoleCalculatorLibrary;
using System;

namespace CalculatorManualTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new ConsoleCalculator();
            while (true)
            {
                try
                {
                    Console.WriteLine("Please input the expression to be calculated:");
                    string input = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Result: ");
                    Console.WriteLine(calculator.Calculate(input));                    
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Expression is corrupted: {ex.Message}");
                }
                catch
                {
                    Console.WriteLine("System exception, please contact administrator");
                }
                finally
                {
                    Console.WriteLine(" -----------");
                    Console.WriteLine();
                }
            }

        }
    }
}
