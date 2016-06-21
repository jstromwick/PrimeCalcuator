using System;
using System.Windows.Input;
using PrimeCalculatorApp.Commands;
using PrimeCalculatorApp.Models;

namespace PrimeCalculatorApp.ViewModels
{
    internal class CalculatorViewModel : NotifyPropertyChangedBase
    {
        private CalculationInfo _calculationInfo;

        public CalculatorViewModel()
        {
            StartCalculationCommand = new Command(o => StartCalculation(), o => !CalculationInProgress);
            CalculationInfo = new CalculationInfo();
        }

        public CalculationInfo CalculationInfo
        {
            get { return _calculationInfo; }
            set
            {
                _calculationInfo = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCalculationCommand { get; private set; }

        public bool CalculationInProgress { get; set; }

        private void StartCalculation()
        {
            if (CalculationInProgress)
            {
                return;
            }

            CalculationInProgress = true;
            CalculationInfo = new CalculationInfo();

            CalculationInfo.LargestPrime = new Random().Next();
        }
    }
}