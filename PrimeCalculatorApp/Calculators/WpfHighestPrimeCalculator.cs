using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using PrimeCalculator;
using PrimeCalculatorApp.Models;

namespace PrimeCalculatorApp.Calculators
{
    public class WpfHighestPrimeCalculator : HighestPrimeCalculator
    {
        private readonly CalculationInfo _calculationInfo;

        private readonly List<long> _tempPrimeList = new List<long>();
        private int _primesSoFar;

        public WpfHighestPrimeCalculator(CalculationInfo calculationInfo)
        {
            _calculationInfo = calculationInfo;
        }

        protected override void OnLargestPrimeFound(long largestPrime)
        {
            _tempPrimeList.Add(largestPrime);
            _primesSoFar++;

            //Due to the overhead of pummeling the UI with primes, we will only update with the largest prime sporatically
            if (_primesSoFar == 1000)
            {
                _primesSoFar = 0;
                _tempPrimeList.Clear();
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() => { _calculationInfo.LargestPrimes.Add(largestPrime); }));
            }
        }

        protected override void OnEveryThousandMilliseconds(long millisecondsElapsed)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() => { _calculationInfo.TimeElapsedInSeconds++; }));
        }

        protected override void OnFinishedCalculation(long largestPrime, uint timelimitInSeconds)
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Normal, (Action) (() =>
                                                                                          {
                                                                                              //Load all of the highest primes into our object
                                                                                              foreach (var tempPrime in _tempPrimeList)
                                                                                              {
                                                                                                  _calculationInfo.LargestPrimes.Add(tempPrime);
                                                                                              }
                                                                                              _calculationInfo.TimeElapsedInSeconds = timelimitInSeconds;
                                                                                          }));
        }
    }
}