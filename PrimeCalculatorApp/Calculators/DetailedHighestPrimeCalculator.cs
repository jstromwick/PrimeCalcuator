using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using PrimeCalculator;
using PrimeCalculatorApp.Models;

namespace PrimeCalculatorApp.Calculators
{
    public class DetailedHighestPrimeCalculator : HighestPrimeCalculator
    {
        private readonly CalculationInfo _calculationInfo;

        public DetailedHighestPrimeCalculator(CalculationInfo calculationInfo)
        {
            _calculationInfo = calculationInfo;
        }

        protected override void OnLargestPrimeFound(long largestPrime)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() => { _calculationInfo.LargestPrimes.Add(largestPrime); }));
        }

        protected override void OnEveryThousandMilliseconds(long millisecondsElapsed)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() => { _calculationInfo.TimeElapsedInSeconds++; }));
            //Give time for the UI to update (this can significantly slow down our processing, but keeps the UI responsive boo)
            Thread.Sleep(100);
        }

        protected override void OnFinishedCalculation(long largestPrime, uint timelimitInSeconds)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => { _calculationInfo.TimeElapsedInSeconds = timelimitInSeconds; }));
            Thread.Sleep(100);
        }
    }
}