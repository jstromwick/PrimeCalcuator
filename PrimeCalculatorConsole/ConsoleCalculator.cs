using System;
using PrimeCalculator;

namespace PrimeCalculatorConsole
{
    public class ConsoleCalculator : HighestPrimeCalculator
    {
        private int _primesSoFar;

        protected override void OnEveryThousandMilliseconds(long millisecondsElapsed)
        {
            Console.WriteLine("Seconds passed: {0}", (int) millisecondsElapsed/1000);
        }

        protected override void OnLargestPrimeFound(long largestPrime)
        {
            _primesSoFar++;
            if (_primesSoFar == 10000)
            {
                _primesSoFar = 0;
                Console.WriteLine($"Largest Prime Found So Far: {largestPrime}");
            }
        }

        protected override void OnFinishedCalculation(long largestPrime, uint timelimitInSeconds)
        {
            Console.WriteLine("Calculation Complete!\nLargest Prime found in {0} seconds was {1}", timelimitInSeconds, largestPrime);
        }
    }
}