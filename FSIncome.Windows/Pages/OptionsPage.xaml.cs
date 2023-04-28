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
        private string currencyDefault { get; }
        private string landUnitDefault { get; }
        private int daysDefault { get; }
        private double machinesValueLowDefault { get; }
        private double machinesValueBigDefault { get; }
        private double landSizeLowDefault { get; }
        private double landSizeBigDefault { get; }

        // variables for checking changes
        private string currencyCurrent;
        private string landUnitCurrent;
        private int daysCurrent;
        private double machinesValueLowDefaultCurrent;
        private double machinesValueBigDefaultCurrent;
        private double landSizeLowDefaultCurrent;
        private double landSizeBigDefaultCurrent;
        

        public bool goBack { get; set; } = false;

        public OptionsPage(Dictionary<string, string> appImages)
        {
            InitializeComponent();
            //setting default values
            currencyDefault = ResourcesClass.Currency.PLN.ToString();
            landUnitDefault = ResourcesClass.LandUnits.Ha.ToString();
            daysDefault = 12;
            machinesValueLowDefault = 100000;
            machinesValueBigDefault = 250000;
            landSizeLowDefault = 25000;
            landSizeBigDefault = 50000;

            DataContext = appImages;
        }

        public void SetStartingSettings()
        {
            //setting values while entering to this page
            currencyCurrent = ExpanderCurrency.Header.ToString();
            landUnitCurrent = ExpanderLandUnit.Header.ToString();
            daysCurrent = int.Parse(ExpanderDays.Header.ToString());
            machinesValueLowDefaultCurrent = double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueLow.Header.ToString()));
            machinesValueBigDefaultCurrent = double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueBig.Header.ToString()));
            landSizeLowDefaultCurrent = double.Parse(ResourcesMethods.ClearString(ExpanderLandValueLow.Header.ToString()));
            landSizeBigDefaultCurrent = double.Parse(ResourcesMethods.ClearString(ExpanderLandValueBig.Header.ToString()));
        }

        private void CurrencyItemClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == CurrencyPln)
            {
                //setting expander header and value options depending on the currency
                ExpanderCurrency.Header = ResourcesClass.Currency.PLN.ToString();

                machValLow1.Content = 50000 + " " + ResourcesClass.Currency.PLN.ToString();
                machValLow2.Content = 100000 + " " + ResourcesClass.Currency.PLN.ToString();
                machValLow3.Content = 150000 + " " + ResourcesClass.Currency.PLN.ToString();
                ExpanderMachinesValueLow.Header = machValLow2.Content.ToString();

                machValHigh1.Content = 200000 + " " + ResourcesClass.Currency.PLN.ToString();
                machValHigh2.Content = 250000 + " " + ResourcesClass.Currency.PLN.ToString();
                machValHigh3.Content = 300000 + " " + ResourcesClass.Currency.PLN.ToString();
                //setting middle value
                ExpanderMachinesValueBig.Header = machValHigh2.Content.ToString();
            }
            else if (sender == CurrencyEuro)
            {
                ExpanderCurrency.Header = ResourcesClass.Currency.EUR.ToString();

                machValLow1.Content = 10500 + " " + ResourcesClass.Currency.EUR.ToString();
                machValLow2.Content = 21000 + " " + ResourcesClass.Currency.EUR.ToString();
                machValLow3.Content = 32000 + " " + ResourcesClass.Currency.EUR.ToString();
                ExpanderMachinesValueLow.Header = machValLow2.Content.ToString();

                machValHigh1.Content = 42000 + " " + ResourcesClass.Currency.EUR.ToString();
                machValHigh2.Content = 53000 + " " + ResourcesClass.Currency.EUR.ToString();
                machValHigh3.Content = 64000 + " " + ResourcesClass.Currency.EUR.ToString();
                ExpanderMachinesValueBig.Header = machValHigh2.Content.ToString();
            }
            else //GBP
            {
                ExpanderCurrency.Header = ResourcesClass.Currency.GBP.ToString();

                machValLow1.Content = 9500 + " " + ResourcesClass.Currency.GBP.ToString();
                machValLow2.Content = 20000 + " " + ResourcesClass.Currency.GBP.ToString();
                machValLow3.Content = 28000 + " " + ResourcesClass.Currency.GBP.ToString();
                ExpanderMachinesValueLow.Header = machValLow2.Content.ToString();

                machValHigh1.Content = 38000 + " " + ResourcesClass.Currency.GBP.ToString();
                machValHigh2.Content = 48000 + " " + ResourcesClass.Currency.GBP.ToString();
                machValHigh3.Content = 58000 + " " + ResourcesClass.Currency.GBP.ToString();
                ExpanderMachinesValueBig.Header = machValHigh2.Content.ToString();
            }
            ExpanderCurrency.IsExpanded = false;
        }
        
        private void LandUnitClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == landUnitHa) ExpanderLandUnit.Header = landUnitHa.Content.ToString();

            ExpanderLandUnit.IsExpanded = false;
        }
        private void MachinesValueLowClick(object sender, MouseButtonEventArgs e)
        {
            if(sender == machValLow1) ExpanderMachinesValueLow.Header = machValLow1.Content.ToString();
            else if(sender== machValLow2) ExpanderMachinesValueLow.Header = machValLow2.Content.ToString();
            else ExpanderMachinesValueLow.Header = machValLow3.Content.ToString();
            

            ExpanderMachinesValueLow.IsExpanded = false;
        }
        private void MachinesValueBigClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == machValHigh1) ExpanderMachinesValueBig.Header = machValHigh1.Content.ToString();
            else if (sender == machValHigh2) ExpanderMachinesValueBig.Header = machValHigh2.Content.ToString();
            else ExpanderMachinesValueBig.Header = machValHigh3.Content.ToString();

            ExpanderMachinesValueBig.IsExpanded = false;
        }

        private void LandValueLowClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == landValLow1) ExpanderLandValueLow.Header = landValLow1.Content.ToString();
            else if (sender == landValLow2) ExpanderLandValueLow.Header = landValLow2.Content.ToString();
            else ExpanderLandValueLow.Header = landValLow3.Content.ToString();


            ExpanderLandValueLow.IsExpanded = false;
        }
        private void LandValueBigClick(object sender, MouseButtonEventArgs e)
        {
            if (sender == landValHigh1) ExpanderLandValueBig.Header = landValHigh1.Content.ToString();
            else if (sender == landValHigh2) ExpanderLandValueBig.Header = landValHigh2.Content.ToString();
            else ExpanderLandValueBig.Header = landValHigh3.Content.ToString();

            ExpanderLandValueBig.IsExpanded = false;
        }

        private void DaysItemClick(object sender, MouseButtonEventArgs e)
        {
            //setting header 
            if(sender==Days9) ExpanderDays.Header = "9";
            else if(sender==Days12) ExpanderDays.Header = "12";
            else if(sender==Days18) ExpanderDays.Header = "18";
            else if(sender==Days24) ExpanderDays.Header = "24";
            else ExpanderDays.Header = "36";

            ExpanderDays.IsExpanded = false;
        }

        private void AcceptValues()
        {
            var settingsFile = FileClass.ReadSettingsFile();
            settingsFile.currency = ExpanderCurrency.Header.ToString().ToLower();
            settingsFile.landUnit = ExpanderLandUnit.Header.ToString().ToLower();
            settingsFile.seasonDays = int.Parse(ExpanderDays.Header.ToString());
            settingsFile.machinesValueLow = double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueLow.Header.ToString()));
            settingsFile.machinesValueBig = double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueBig.Header.ToString()));
            settingsFile.landSizeLow = double.Parse(ResourcesMethods.ClearString(ExpanderLandValueLow.Header.ToString()));
            settingsFile.landSizeBig = double.Parse(ResourcesMethods.ClearString(ExpanderLandValueBig.Header.ToString()));

            FileClass.SaveSettingsFile(settingsFile);
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            if (currencyCurrent != ExpanderCurrency.Header.ToString() ||
                landUnitCurrent != ExpanderLandUnit.Header.ToString() ||
                daysCurrent != int.Parse(ExpanderDays.Header.ToString()) ||
                machinesValueLowDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueLow.Header.ToString())) ||
                machinesValueBigDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueBig.Header.ToString())) ||
                landSizeLowDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderLandValueLow.Header.ToString())) ||
                landSizeBigDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderLandValueBig.Header.ToString())))
            {
                MessageBoxResult result = MessageBox.Show("You have changed settings, that may cause errors in the profiles that you have created." +
                    " It is recommended to set settings before creating any profiles. Do you want to save the changes?", "Atention", 
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    AcceptValues();
                    goBack = true;
                }
                else goBack = true;
            }
            else goBack = true;

        }
        public void SetValues()
        {
            var settingsFile = FileClass.ReadSettingsFile();
            ExpanderCurrency.Header = settingsFile.currency.ToUpper();
            ExpanderLandUnit.Header = settingsFile.landUnit.ToUpper();
            ExpanderDays.Header = settingsFile.seasonDays;
            ExpanderMachinesValueLow.Header = settingsFile.machinesValueLow + " " + ExpanderCurrency.Header.ToString();
            ExpanderMachinesValueBig.Header = settingsFile.machinesValueBig + " " + ExpanderCurrency.Header.ToString();

            ExpanderLandValueLow.Header = settingsFile.landSizeLow + " " + settingsFile.landUnit;
            ExpanderLandValueBig.Header = settingsFile.landSizeBig + " " + settingsFile.landUnit;
        }
        private void DefaultButtonClick(object sender, RoutedEventArgs e)
        {
            var settingsFile = FileClass.ReadSettingsFile();
            ExpanderCurrency.Header = currencyDefault;
            ExpanderLandUnit.Header = landUnitDefault;
            ExpanderDays.Header = daysDefault;
            ExpanderMachinesValueLow.Header = machinesValueLowDefault + " " + ExpanderCurrency.Header.ToString();
            ExpanderMachinesValueBig.Header = machinesValueBigDefault + " " + ExpanderCurrency.Header.ToString();

            ExpanderLandValueLow.Header = landSizeLowDefault + " " + settingsFile.landUnit;
            ExpanderLandValueBig.Header = landSizeBigDefault + " " + settingsFile.landUnit;
        }
        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            if (currencyCurrent != ExpanderCurrency.Header.ToString() ||
                landUnitCurrent != ExpanderLandUnit.Header.ToString() ||
                daysCurrent != int.Parse(ExpanderDays.Header.ToString()) ||
                machinesValueLowDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueLow.Header.ToString())) ||
                machinesValueBigDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderMachinesValueBig.Header.ToString())) ||
                landSizeLowDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderLandValueLow.Header.ToString())) ||
                landSizeBigDefaultCurrent != double.Parse(ResourcesMethods.ClearString(ExpanderLandValueBig.Header.ToString())))
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

        
    }
}
