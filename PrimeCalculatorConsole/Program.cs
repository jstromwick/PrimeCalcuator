using System;

namespace PrimeCalculatorConsole
{
    internal class Program
    {
        private const uint Seconds = 60;

        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the prime calculator!");
            Console.WriteLine("Hit 'r' to start calculating primes, or 'q' to quit");

            var consoleCalculator = new ConsoleCalculator();
            while (true)
            {
                var input = Console.ReadKey();
                Console.WriteLine();
                if (input.Key == ConsoleKey.Q)
                {
                    break;
                }

                if (input.Key == ConsoleKey.R)
                {
                    consoleCalculator.CalculateHighestPrime(Seconds);
                    continue;
                }

                Console.WriteLine("No known command for character '{0}'", input.KeyChar);
            }
        }
    }
}