using System.Threading.Tasks;
using System.Windows.Input;
using PrimeCalculatorApp.Calculators;
using PrimeCalculatorApp.Commands;
using PrimeCalculatorApp.Models;

namespace PrimeCalculatorApp.ViewModels
{
    internal class CalculatorViewModel : NotifyPropertyChangedBase
    {
        private const uint CalculationTime = 10;
        private bool _calculationComplete;
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

        public bool CalculationComplete
        {
            get { return _calculationComplete; }
            set
            {
                _calculationComplete = value;
                OnPropertyChanged();
            }
        }


        public ICommand StartCalculationCommand { get; private set; }

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