using System;
using PrimeCalculator;

namespace PrimeCalculatorConsole
{
    public class ConsoleCalculator : HighestPrimeCalculator
    {
        protected override void OnEveryThousandMilliseconds(long millisecondsElapsed)
        {
            Console.WriteLine("Seconds passed: {0}", (int) millisecondsElapsed/1000);
        }

        protected override void OnLargestPrimeFound(long largestPrime)
        {
            Console.WriteLine($"Largest Prime Found So Far: {largestPrime}");
        }

        protected override void OnFinishedCalculation(long largestPrime, uint timelimitInSeconds)
        {
            Console.WriteLine("Calculation Complete!\nLargest Prime found in {0} seconds was {1}", timelimitInSeconds, largestPrime);
        }
    }
}