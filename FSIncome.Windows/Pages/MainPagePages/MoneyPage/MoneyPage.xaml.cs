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

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class MoneyPage : Page
    {
        public bool takeLoan { get; set; }
        public bool payLoan { get; set; }
        public bool seeLoans { get; set; }
        public MoneyPage()
        {
            InitializeComponent();

        }
        
        public void UpdateBankAccountTB(int profileNr, int farmProfileNr) 
        {
            //updates text box 
            var file = FileClass.ReadProfilesDataFile();
            var settingsFile = FileClass.ReadSettingsFile();
            MoneyTextBlock.Text = ResourcesClass.SetTwoDecimalNumbers(file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount.ToString()) +
                " " + settingsFile.currency.ToUpper();
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            takeLoan = true;
        }

        private void PayLoanLoanButton_Click(object sender, RoutedEventArgs e)
        {
            payLoan = true;
        }

        private void LoanButton_Click(object sender, RoutedEventArgs e)
        {
            seeLoans= true;
        }
    }
}
