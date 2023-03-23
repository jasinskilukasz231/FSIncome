using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FSIncome.Windows.Pages
{
    /// <summary>
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public OptionsPage()
        {
            InitializeComponent();
        }

        private void CurrencyPlnClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "PLN";
            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyEuroClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "EUR";
            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyGbpClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = "GBP";
            ExpanderCurrency.IsExpanded = false;
        }

        private void Days6Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "6";
            ExpanderDays.IsExpanded = false;
        }
        private void Days9Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "9";
            ExpanderDays.IsExpanded = false;
        }
        private void Days12Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "12";
            ExpanderDays.IsExpanded = false;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void DefaultButtonClick(object sender, RoutedEventArgs e)
        {

        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
