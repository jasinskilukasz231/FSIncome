using FSIncome.Core;
using FSIncome.Core.Files;
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
    public partial class OptionsPage : Page
    {
        //default values
        private string currencyDefault { get; } = "PLN";
        private string daysDefault { get; } = "12";

        public bool goBack { get; set; } = false;

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
            MessageBoxResult result = MessageBox.Show("Do you want to save the changes?", "", MessageBoxButton.YesNoCancel);
            
            if(result==MessageBoxResult.Yes)
            {
                SettingsFile settingsFile = FileClass.ReadSettingsFile();
                settingsFile.currency = ExpanderCurrency.Header.ToString().ToLower();
                settingsFile.seasonDays = int.Parse(ExpanderDays.Header.ToString());

                FileClass.SaveSettingsFile(settingsFile);
                goBack = true;
            }
            if (result == MessageBoxResult.No)
            {
                goBack = true;
            }
            
        }
        public void SetValues()
        {
            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            ExpanderCurrency.Header = settingsFile.currency.ToUpper();
            ExpanderDays.Header = settingsFile.seasonDays;
        }
        private void DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = currencyDefault;
            ExpanderDays.Header = daysDefault;
        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            settingsFile.currency = ExpanderCurrency.Header.ToString().ToLower();
            settingsFile.seasonDays = int.Parse(ExpanderDays.Header.ToString());

            FileClass.SaveSettingsFile(settingsFile);
            goBack = true;
        }
    }
}
