using System.Threading.Tasks;
using PrimeCalculatorApp.Calculators;
using PrimeCalculatorApp.Models;

namespace PrimeCalculatorApp.ViewModels
{
    internal class CalculatorViewModel : NotifyPropertyChangedBase
    {
        private const uint CalculationTime = 60;
        private bool _calculationComplete;
        private CalculationInfo _calculationInfo;

        public CalculatorViewModel()
        {
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

        public bool CalculationComplete
        {
            get { return _calculationComplete; }
            set
            {
                _calculationComplete = value;
                OnPropertyChanged();
            }
        }

        public bool CalculationInProgress { get; set; }

        public async Task<long> StartCalculation()
        {
            if (CalculationInProgress)
            {
                return 0;
            }

            CalculationInProgress = true;
            CalculationComplete = false;
            try
            {
                CalculationInfo = new CalculationInfo();
                var calculator = new DetailedHighestPrimeCalculator(CalculationInfo);
                return await Task.Run(() => calculator.CalculateHighestPrime(CalculationTime));
            }
            finally
            {
                CalculationInProgress = false;
                CalculationComplete = true;
            }
        }
    }
}