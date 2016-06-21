using System.Diagnostics;

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


            var limitInMillis = timelimitInSeconds*1000;
            while (stopwatch.ElapsedMilliseconds < limitInMillis)
            {
                if (IsPrime(currentCanditate))
                {
                    largestPrime = currentCanditate;
                }

                currentCanditate++;
            }

            return largestPrime;
        }

        internal bool IsPrime(long number)
        {
            //TODO: Something Genius
            return false;
        }
    }
}