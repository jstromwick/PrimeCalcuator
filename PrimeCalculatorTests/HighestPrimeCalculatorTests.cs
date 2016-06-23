using System;
using NUnit.Framework;
using PrimeCalculator;

namespace PrimeCalculatorTests
{
    [TestFixture]
    public class HighestPrimeCalculatorTests
    {
        [Test]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(3, ExpectedResult = true)]
        [TestCase(4, ExpectedResult = false)]
        [TestCase(16, ExpectedResult = false)]
        [TestCase(17, ExpectedResult = true)]
        [TestCase(8831, ExpectedResult = true)]
        [TestCase(1301070, ExpectedResult = false)]
        [TestCase(1301081, ExpectedResult = true)]
        public bool CalculateIsPrime(long number)
        {
            var calculator = new HighestPrimeCalculator();
            return calculator.CalculateIsPrime(number);
        }

        [Test, Explicit]
        [TestCase(2u)]
        [TestCase(5u)]
        [TestCase(10u)]
        [TestCase(30u)]
        [TestCase(60u)]
        public void GetHighestPrime(uint runTimeInSeconds)
        {
            var primeCalculator = new HighestPrimeCalculator();
            var highestPrime = primeCalculator.CalculateHighestPrime(runTimeInSeconds);
            Console.WriteLine("Highest Prime Calculated was: {0}", highestPrime);
        }

        [Test]
        public void SmokeTest()
        {
            var calculator = new HighestPrimeCalculator();
            Assert.IsTrue(true);
        }
    }
}