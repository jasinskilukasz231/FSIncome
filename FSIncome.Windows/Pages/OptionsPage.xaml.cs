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
using System.Windows.Threading;

namespace FSIncome.Windows.Pages
{
    public partial class OptionsPage : Page
    {
        //default values
        private string currencyDefault { get; } = "PLN";
        private int daysDefault { get; } = 12;
        public double machinesValueLowDefault { get; set; } = 100000;
        public double machinesValueBigDefault { get; set; } = 250000;
        public double landSizeLowDefault { get; set; } = 25000;
        public double landSizeBigDefault { get; set; } = 50000;

        // variables for checking changes commited
        private string currencyCurrent;
        private int daysCurrent;
        private double machinesValueLowDefaultCurrent;
        private double machinesValueBigDefaultCurrent;
        private double landSizeLowDefaultCurrent;
        private double landSizeBigDefaultCurrent;
        //
        //change this
        public double EUROPRICETOPLN { get; set; } = 4.69;
        public double GBPPRICETOPLN { get; set; } = 5.24;
        //

        public bool goBack { get; set; } = false;

        public OptionsPage()
        {
            InitializeComponent();
        }
        public void SetStartingSettings()
        {
            currencyCurrent = ExpanderCurrency.Header.ToString();
            daysCurrent = int.Parse(ExpanderDays.Header.ToString());
            machinesValueLowDefaultCurrent = double.Parse(ClearString(ExpanderMachinesValueLow.Header.ToString()));
            machinesValueBigDefaultCurrent = double.Parse(ClearString(ExpanderMachinesValueBig.Header.ToString()));
            landSizeLowDefaultCurrent = double.Parse(ClearString(ExpanderLandValueLow.Header.ToString()));
            landSizeBigDefaultCurrent = double.Parse(ClearString(ExpanderLandValueBig.Header.ToString()));
        }
        private string ClearString(string header)
        {
            string endValue = "";
            foreach (var i in header)
            {
                if (i == ' ') break;
                else endValue += i;
            }
            return endValue;
        }

        private void CurrencyPlnClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = ResourcesClass.Currency.PLN.ToString();

            valueLow1.Content = 50000 + " PLN";
            valueLow2.Content = 100000 + " PLN";
            valueLow3.Content = 150000 + " PLN";
            ExpanderMachinesValueLow.Header = valueLow2.Content.ToString();

            valueHigh1.Content = 200000 + " PLN";
            valueHigh2.Content = 250000 + " PLN";
            valueHigh3.Content = 300000 + " PLN";
            ExpanderMachinesValueBig.Header = valueHigh2.Content.ToString();

            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyEuroClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = ResourcesClass.Currency.EUR.ToString();

            valueLow1.Content = 10500 + " EUR";
            valueLow2.Content = 21000 + " EUR";
            valueLow3.Content = 32000 + " EUR";
            ExpanderMachinesValueLow.Header = valueLow2.Content.ToString();

            valueHigh1.Content = 42000 + " EUR";
            valueHigh2.Content = 53000 + " EUR";
            valueHigh3.Content = 64000 + " EUR";
            ExpanderMachinesValueBig.Header = valueHigh2.Content.ToString();

            ExpanderCurrency.IsExpanded = false;
        }
        private void CurrencyGbpClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = ResourcesClass.Currency.GBP.ToString();

            valueLow1.Content = 9500 + " GBP";
            valueLow2.Content = 20000 + " GBP";
            valueLow3.Content = 28000 + " GBP";
            ExpanderMachinesValueLow.Header = valueLow2.Content.ToString();

            valueHigh1.Content = 38000 + " GBP";
            valueHigh2.Content = 48000 + " GBP";
            valueHigh3.Content = 58000 + " GBP";
            ExpanderMachinesValueBig.Header = valueHigh2.Content.ToString();

            ExpanderCurrency.IsExpanded = false;
        }

        private void valueLow1_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueLow.Header = valueLow1.Content.ToString();
            ExpanderMachinesValueLow.IsExpanded = false;
        }
        private void valueLow2_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueLow.Header = valueLow2.Content.ToString();
            ExpanderMachinesValueLow.IsExpanded = false;
        }
        private void valueLow3_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueLow.Header = valueLow3.Content.ToString();
            ExpanderMachinesValueLow.IsExpanded = false;
        }
        private void valueHigh1_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueBig.Header = valueHigh1.Content.ToString();
            ExpanderMachinesValueBig.IsExpanded = false;
        }
        private void valueHigh2_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueBig.Header = valueHigh2.Content.ToString();
            ExpanderMachinesValueBig.IsExpanded = false;
        }
        private void valueHigh3_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderMachinesValueBig.Header = valueHigh3.Content.ToString();
            ExpanderMachinesValueBig.IsExpanded = false;
        }

        private void LandValueLow1_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueLow.Header = LandValueLow1.Content.ToString();
            ExpanderLandValueLow.IsExpanded = false;
        }
        private void LandValueLow2_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueLow.Header = LandValueLow2.Content.ToString();
            ExpanderLandValueLow.IsExpanded = false;
        }
        private void LandValueLow3_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueLow.Header = LandValueLow3.Content.ToString();
            ExpanderLandValueLow.IsExpanded = false;
        }
        private void LandValueHigh1_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueBig.Header = LandValueHigh1.Content.ToString();
            ExpanderLandValueBig.IsExpanded = false;
        }
        private void LandValueHigh2_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueBig.Header = LandValueHigh2.Content.ToString();
            ExpanderLandValueBig.IsExpanded = false;
        }
        private void LandValueHigh3_MouseLeftButtonUp(object sender, RoutedEventArgs e)
        {
            ExpanderLandValueBig.Header = LandValueHigh3.Content.ToString();
            ExpanderLandValueBig.IsExpanded = false;
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
        private void Days18Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "18";
            ExpanderDays.IsExpanded = false;
        }
        private void Days24Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "24";
            ExpanderDays.IsExpanded = false;
        }
        private void Days36Click(object sender, RoutedEventArgs e)
        {
            ExpanderDays.Header = "36";
            ExpanderDays.IsExpanded = false;
        }
        private void AcceptValues()
        {
            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            settingsFile.currency = ExpanderCurrency.Header.ToString().ToLower();
            settingsFile.seasonDays = int.Parse(ExpanderDays.Header.ToString());

            settingsFile.machinesValueLow = double.Parse(ClearString(ExpanderMachinesValueLow.Header.ToString()));
            settingsFile.machinesValueBig = double.Parse(ClearString(ExpanderMachinesValueBig.Header.ToString()));
            settingsFile.landSizeLow = double.Parse(ClearString(ExpanderLandValueLow.Header.ToString()));
            settingsFile.landSizeBig = double.Parse(ClearString(ExpanderLandValueBig.Header.ToString()));

            FileClass.SaveSettingsFile(settingsFile);
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (currencyCurrent != ExpanderCurrency.Header.ToString() ||
                daysCurrent != int.Parse(ExpanderDays.Header.ToString()) ||
                machinesValueLowDefaultCurrent != double.Parse(ClearString(ExpanderMachinesValueLow.Header.ToString())) ||
                machinesValueBigDefaultCurrent != double.Parse(ClearString(ExpanderMachinesValueBig.Header.ToString())) ||
                landSizeLowDefaultCurrent != double.Parse(ClearString(ExpanderLandValueLow.Header.ToString())) ||
                landSizeBigDefaultCurrent != double.Parse(ClearString(ExpanderLandValueBig.Header.ToString())))
            {
                MessageBoxResult result = MessageBox.Show("You have changed settings, that may cause errors in the profiles that you have created." +
                    " It is recommended to set settings before creating any profiles. Do you want to save the changes?", "Atention", 
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    AcceptValues();
                    goBack = true;
                }
                if (result == MessageBoxResult.No)
                {
                    goBack = true;
                }
            }
            else goBack = true;

        }
        public void SetValues()
        {
            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            ExpanderCurrency.Header = settingsFile.currency.ToUpper();
            ExpanderDays.Header = settingsFile.seasonDays;
            ExpanderMachinesValueLow.Header = settingsFile.machinesValueLow + " " + ExpanderCurrency.Header.ToString();
            ExpanderMachinesValueBig.Header = settingsFile.machinesValueBig + " " + ExpanderCurrency.Header.ToString();

            ExpanderLandValueLow.Header = settingsFile.landSizeLow + " Ha";
            ExpanderLandValueBig.Header = settingsFile.landSizeBig + " Ha";
        }
        private void DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            ExpanderCurrency.Header = currencyDefault;
            ExpanderDays.Header = daysDefault;
            ExpanderMachinesValueLow.Header = machinesValueLowDefault + " " + ExpanderCurrency.Header.ToString();
            ExpanderMachinesValueBig.Header = machinesValueBigDefault + " " + ExpanderCurrency.Header.ToString();

            ExpanderLandValueLow.Header = landSizeLowDefault + " Ha";
            ExpanderLandValueBig.Header = landSizeBigDefault + " Ha";
        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            if (currencyCurrent != ExpanderCurrency.Header.ToString() ||
                daysCurrent != int.Parse(ExpanderDays.Header.ToString()) ||
                machinesValueLowDefaultCurrent != double.Parse(ClearString(ExpanderMachinesValueLow.Header.ToString())) ||
                machinesValueBigDefaultCurrent != double.Parse(ClearString(ExpanderMachinesValueBig.Header.ToString())) ||
                landSizeLowDefaultCurrent != double.Parse(ClearString(ExpanderLandValueLow.Header.ToString())) ||
                landSizeBigDefaultCurrent != double.Parse(ClearString(ExpanderLandValueBig.Header.ToString())))
            {
                MessageBoxResult result = MessageBox.Show("You have changed settings, that may cause errors in the profiles that you created." +
                    " It is recommended to set settings before creating any profiles. Do you want to save the changes?", "Atention",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    AcceptValues();
                    goBack = true;
                }
                if (result == MessageBoxResult.No)
                {
                    goBack = true;
                }
            }
            else goBack = true;
        }
    }
}
