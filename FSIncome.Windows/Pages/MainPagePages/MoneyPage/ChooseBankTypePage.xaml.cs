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
using FSIncome.Core;
using FSIncome.Core.Files;

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class ChooseBankTypePage : Page
    {
        public bool bank1Click { get; set; }
        public bool bank2Click { get; set; }
        public bool bank3Click { get; set; }
        public string BankType
        {
            get { return _bankType; }
            set { _bankType = value; }
        }
        private string _bankType { get; set; }
        public ChooseBankTypePage()
        {
            InitializeComponent();
        }
        public void SetEnabledBankButtons(int profileNr, int farmProfileNr)
        {
            Bank1Button.IsEnabled = true;
            Bank2Button.IsEnabled = true;
            Bank3Button.IsEnabled = true;

            //checking 1st bank type and setting buttons properties
            var file = FileClass.ReadProfilesDataFile();
            foreach (var i in file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].loansTag.standardLoanTag.loanItems)
            {
                if (i.bankType==ResourcesClass.BankType.Bank1.ToString())
                {
                    Bank2Button.IsEnabled = false;
                    Bank3Button.IsEnabled = false;
                    break;
                }
                else if (i.bankType == ResourcesClass.BankType.Bank2.ToString())
                {
                    Bank1Button.IsEnabled = false;
                    Bank3Button.IsEnabled = false;
                    break;
                }
                else if (i.bankType == ResourcesClass.BankType.Bank3.ToString())
                {
                    Bank1Button.IsEnabled = false;
                    Bank2Button.IsEnabled = false;
                    break;
                }

            }

            foreach (var i in file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].loansTag.hypotheticalLoanTag.loanItems)
            {
                if (i.bankType == ResourcesClass.BankType.Bank1.ToString())
                {
                    Bank2Button.IsEnabled = false;
                    Bank3Button.IsEnabled = false;
                    break;
                }
                else if (i.bankType == ResourcesClass.BankType.Bank2.ToString())
                {
                    Bank1Button.IsEnabled = false;
                    Bank3Button.IsEnabled = false;
                    break;
                }
                else if (i.bankType == ResourcesClass.BankType.Bank3.ToString())
                {
                    Bank1Button.IsEnabled = false;
                    Bank2Button.IsEnabled = false;
                    break;
                }
            }

        }
        private void Bank1Button_Click(object sender, RoutedEventArgs e)
        {
            bank1Click = true;
            _bankType = ResourcesClass.BankType.Bank1.ToString();
        }

        private void Bank2Button_Click(object sender, RoutedEventArgs e)
        {
            bank2Click = true;
            _bankType = ResourcesClass.BankType.Bank2.ToString();
        }

        private void Bank3Button_Click(object sender, RoutedEventArgs e)
        {
            bank3Click = true;
            _bankType = ResourcesClass.BankType.Bank3.ToString();
        }
    }
}
