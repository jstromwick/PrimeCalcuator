using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PrimeCalculator
{
    public class HighestPrimeCalculator
    {
        public long CalculateHighestPrime(int timelimitInSeconds)
        {
            long largestPrime = 0;
            long currentCanditate = 2;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var primes = new List<long>();
            var limitInMillis = timelimitInSeconds*1000;
            while (stopwatch.ElapsedMilliseconds < limitInMillis)
            {
                if (IsPrime(currentCanditate, primes))
                {
                    largestPrime = currentCanditate;
                }

                currentCanditate++;
            }

            return largestPrime;
        }

        /// <summary>
        ///     Useful for testing
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        internal bool CalculateIsPrime(long number)
        {
           var primes = new List<long>();
            for (var i = 2; i <= number; i++)
            {
                IsPrime(i, primes);
            }

            return primes.Last() == number;
        }

        private bool IsPrime(long number, List<long> primes)
        {
            if (number < 2)
            {
                return false;
            }

            if (number == 2)
            {
                primes.Add(number);
                return true;
            }

            var sqrtOfNumber = Math.Sqrt(number);
            foreach (var prime in primes)
            {
                //Only have to test up to the square root of the number
                if (prime > sqrtOfNumber)
                {
                    break;
                }

                var remainder = number%prime;

                if (remainder == 0)
                {
                    return false;
                }
            }

            primes.Add(number);
            return true;
        }
    }
}