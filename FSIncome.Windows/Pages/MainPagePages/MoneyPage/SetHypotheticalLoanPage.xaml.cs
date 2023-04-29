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
        public bool takeLoanButtonPressed { get; set; }

        private bool _pageCreated { get; set; }

        private double _itemValue { get; set; }
        public double ItemValue
        {
            get
            {
                return _itemValue;
            }
            set
            {
                _itemValue = value;
            }
        }
        private int _loanMonths { get; set; }
        public int LoanMonths
        {
            get
            {
                return _loanMonths;
            }
            set
            {
                _loanMonths = value;
            }
        }
        private double _loanInstallment { get; set; }
        public double LoanInstallment
        {
            get
            {
                return _loanInstallment;
            }
            set
            {
                _loanInstallment = value;
            }
        }
        private double _percentageCovered { get; set; }
        private int _monthsMax { get; set; }
        private double _amountCovered { get; set; }
        private string _currency { get; set; }


        public SetHypotheticalLoanPage()
        {
            InitializeComponent();
        }
        public void InitComponents(string bankType, bool pageCreated, double itemValue)
        {
            this._pageCreated = pageCreated;
            this._itemValue = itemValue;
            var settingsFile = FileClass.ReadSettingsFile();
            _currency = settingsFile.currency;

            var file = FileClass.ReadSystemFile();
            if (bankType == ResourcesClass.BankType.Bank1.ToString())
            {
                _percentageCovered = file.bankData.bank1Item.fieldPercentCoverage;
                _monthsMax = file.bankData.bank1Item.hypotheticalLoanMonthsMax;
            }
            else if (bankType == ResourcesClass.BankType.Bank2.ToString())
            {
                _percentageCovered = file.bankData.bank2Item.fieldPercentCoverage;
                _monthsMax = file.bankData.bank2Item.hypotheticalLoanMonthsMax;
            }
            else
            {
                _percentageCovered = file.bankData.bank3Item.fieldPercentCoverage;
                _monthsMax = file.bankData.bank3Item.hypotheticalLoanMonthsMax;
            }

            _amountCovered = (itemValue * _percentageCovered) / 100;
            LoanTextBlock.Text = "Total field price: " + itemValue + _currency +
                "\nBank coverage: " + _amountCovered + _currency +
                "\nSelf deposit: " + ResourcesClass.SetTwoDecimalNumbers((itemValue - _amountCovered).ToString()) + _currency;

            MonthsTextBlock.Text = "0 MONTHS";
            InstallmentTextBlock.Text = "0 INSTALLMENT";

            MonthsSlider.TickFrequency = 2;
            MonthsSlider.Value = 0;
            MonthsSlider.Maximum = _monthsMax;
        }

        private void MonthsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_pageCreated)
            {
                MonthsTextBlock.Text = MonthsSlider.Value.ToString() + " MONTHS";
                InstallmentTextBlock.Text = ResourcesClass.SetTwoDecimalNumbers((_amountCovered / MonthsSlider.Value).ToString()) +
                    " " + _currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageCreated)
            {
                takeLoanButtonPressed = true;

                _loanMonths = (int)MonthsSlider.Value;
                _loanInstallment = double.Parse(ResourcesClass.SetTwoDecimalNumbers(ResourcesClass.ChangeSeperator(
                    (_amountCovered / MonthsSlider.Value).ToString())));
            }
        }

    }
}
