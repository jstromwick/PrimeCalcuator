using System.Threading.Tasks;
using System.Windows;
using PrimeCalculatorApp.ViewModels;

namespace PrimeCalculatorApp
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var calculatorViewModel = DataContext as CalculatorViewModel;
            await calculatorViewModel.StartCalculation();
        }

    }
}