namespace PrimeCalculatorApp.Models
{
    internal class CalculationInfo : NotifyPropertyChangedBase
    {
        private long _largestPrime;
        private int _timePassedInSeconds;


        public int TimePassedInSecondsPassedInSeconds
        {
            get { return _timePassedInSeconds; }
            set
            {
                _timePassedInSeconds = value;
                OnPropertyChanged();
            }
        }

        public long LargestPrime
        {
            get { return _largestPrime; }
            set
            {
                if (value == _largestPrime)
                {
                    return;
                }
                _largestPrime = value;
                OnPropertyChanged();
            }
        }
    }
}