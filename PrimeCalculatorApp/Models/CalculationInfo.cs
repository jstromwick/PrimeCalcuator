using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace PrimeCalculatorApp.Models
{
    public class CalculationInfo : NotifyPropertyChangedBase
    {
        private ObservableCollection<long> _largestPrimes;
        private uint _timeElapsedInSeconds;

        public CalculationInfo()
        {
            LargestPrimes = new ObservableCollection<long>();
            LargestPrimes.CollectionChanged += LargestPrimes_CollectionChanged;
        }

        public uint TimeElapsedInSeconds
        {
            get { return _timeElapsedInSeconds; }
            set
            {
                _timeElapsedInSeconds = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<long> LargestPrimes
        {
            get { return _largestPrimes; }
            private set
            {
                _largestPrimes = value;
                OnPropertyChanged();
            }
        }

        public long LargestPrime => LargestPrimes.LastOrDefault();

        private void LargestPrimes_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(LargestPrime));
        }
    }
}