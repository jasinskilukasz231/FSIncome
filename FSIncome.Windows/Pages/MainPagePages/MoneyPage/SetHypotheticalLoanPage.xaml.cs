using FSIncome.Core.Files;
using FSIncome.Core;
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
using System.Diagnostics.Eventing.Reader;
using static FSIncome.Core.ResourcesClass;

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class SetHypotheticalLoanPage : Page
    {
        public bool pageCreated { get; set; } = false;
        public string currency { get; set; }
        public bool takeLoanButtonPressed { get; set; } = false;
        public double itemValue { get; set; }
        public int loanMonths { get; set; }
        public double loanInstallment { get; set; }
        public double percentageCovered { get; set; }
        public int monthsMax { get; set; }
        public double amountCovered { get; set; }


        public SetHypotheticalLoanPage()
        {
            InitializeComponent();
        }
        public void InitComponents(string bankType)
        {
            var file = FileClass.ReadSystemFile();
            if (bankType == ResourcesClass.BankType.Bank1.ToString())
            {
                percentageCovered = file.bankData.bank1Item.fieldPercentCoverage;
                monthsMax = file.bankData.bank1Item.hypotheticalLoanMonthsMax;
            }
            else if (bankType == ResourcesClass.BankType.Bank2.ToString())
            {
                percentageCovered = file.bankData.bank2Item.fieldPercentCoverage;
                monthsMax = file.bankData.bank2Item.hypotheticalLoanMonthsMax;
            }
            else
            {
                percentageCovered = file.bankData.bank3Item.fieldPercentCoverage;
                monthsMax = file.bankData.bank3Item.hypotheticalLoanMonthsMax;
            }

            amountCovered = (itemValue * percentageCovered) / 100;
            LoanTextBlock.Text = "Total field price: " + itemValue + currency +
                "\nBank coverage: " + amountCovered + currency +
                "\nSelf deposit: " + ResourcesClass.SetTwoDecimalNumbers((itemValue - amountCovered).ToString()) + currency;

            MonthsTextBlock.Text = "0 MONTHS";
            InstallmentTextBlock.Text = "0 INSTALLMENT";

            MonthsSlider.TickFrequency = 2;
            MonthsSlider.Value = 0;
            MonthsSlider.Maximum = monthsMax;
        }

        private void MonthsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pageCreated)
            {
                MonthsTextBlock.Text = MonthsSlider.Value.ToString() + " MONTHS";
                InstallmentTextBlock.Text = ResourcesClass.SetTwoDecimalNumbers((amountCovered / MonthsSlider.Value).ToString()) +
                    " " + currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageCreated)
            {
                takeLoanButtonPressed = true;

                loanMonths = (int)MonthsSlider.Value;
                loanInstallment = double.Parse(ResourcesClass.SetTwoDecimalNumbers(ResourcesClass.ChangeSeperator(
                    (amountCovered / MonthsSlider.Value).ToString())));
            }
        }

    }
}
