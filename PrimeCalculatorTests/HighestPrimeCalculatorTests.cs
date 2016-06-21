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
        public bool IsPrime(long number)
        {
            var calculator = new HighestPrimeCalculator();
            return calculator.IsPrime(number);
        }

        [Test]
        public void SmokeTest()
        {
            var calculator = new HighestPrimeCalculator();
            Assert.IsTrue(true);
        }
    }
}