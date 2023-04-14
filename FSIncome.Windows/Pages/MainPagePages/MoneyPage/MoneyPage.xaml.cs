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
        public bool takeLoan { get; set; } = false;
        public bool payLoan { get; set; } = false;
        public bool seeLoans { get; set; } = false;
        public MoneyPage()
        {
            InitializeComponent();

        }
        public void AddMoneyToProfile(double moneyAdded, int profileNr, int farmProfileNr)
        {
            var file = FileClass.ReadProfilesDataFile();
            double money = file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount + moneyAdded;
            file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount = money;
            FileClass.SaveProfilesDataFile(file);
        }
        public void UpdateBankAccountTB(int profileNr, int farmProfileNr, string currency) 
        {
            //updates text box 
            var file = FileClass.ReadProfilesDataFile();

            var val = file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount.ToString();
            var endVal = "";
            int decNumbers = 0;
            bool countDecNumb = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == ',')
                {
                    countDecNumb = true;
                    endVal += '.';
                }
                else
                {
                    if (countDecNumb) decNumbers++;
                    endVal += val[i];
                    if (decNumbers == 2) break;
                }

            }

            MoneyTextBlock.Text = endVal + " " + currency.ToUpper();
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
