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
using FSIncome.Core.Loans;

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
        public void InitComponents(string bankType, bool pageCreated, double itemValue, string hypoLoanType, double fertilizerSize=0)
        {
            this._pageCreated = pageCreated;
            this._itemValue = itemValue;
            var settingsFile = FileClass.ReadSettingsFile();
            _currency = settingsFile.currency;

            if (hypoLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
            {
                var file = FileClass.ReadSystemFile();

                //checking max months 
                if (bankType == ResourcesClass.BankType.Bank1.ToString()) _monthsMax = file.bankData.bank1Item.hypotheticalLoanMonthsMax;
                else if (bankType == ResourcesClass.BankType.Bank2.ToString()) _monthsMax = file.bankData.bank2Item.hypotheticalLoanMonthsMax;
                else _monthsMax = file.bankData.bank3Item.hypotheticalLoanMonthsMax;

                //checking percent coverage 
                var counting = new LoanCount();
                _percentageCovered = counting.CheckBankCoveringAmount(bankType);

                _amountCovered = (itemValue * _percentageCovered) / 100;
                LoanTextBlock.Text = "Total field price: " + itemValue + _currency.ToUpper() +
                    "\nBank coverage: " + _amountCovered + _currency.ToUpper() +
                    "\nSelf deposit: " + ResourcesMethods.SetTwoDecimalNumbers((itemValue - _amountCovered).ToString()) + _currency.ToUpper();
                MonthsSlider.TickFrequency = 2;
            }
            else if (hypoLoanType == ResourcesClass.HypotheticalLoanTypes.fertilizer.ToString())
            {
                MonthsSlider.TickFrequency = 1;
                _amountCovered = itemValue;
                _monthsMax = 36;
                LoanTextBlock.Text = "Total fertilizer price: " + itemValue + _currency.ToUpper() +
                    "\nFertilizer size " + fertilizerSize + "t";
            }
            else
            {


            }


                MonthsTextBlock.Text = "0 MONTHS";
            InstallmentTextBlock.Text = "0 INSTALLMENT";

            
            MonthsSlider.Value = 0;
            MonthsSlider.Maximum = _monthsMax;
        }

        private void MonthsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_pageCreated)
            {
                MonthsTextBlock.Text = MonthsSlider.Value.ToString() + " MONTHS";
                InstallmentTextBlock.Text = ResourcesMethods.SetTwoDecimalNumbers((_amountCovered / MonthsSlider.Value).ToString()) +
                    " " + _currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (_pageCreated)
            {
                takeLoanButtonPressed = true;

                _loanMonths = (int)MonthsSlider.Value;
                _loanInstallment = double.Parse(ResourcesMethods.ChangeSeperator(ResourcesMethods.SetTwoDecimalNumbers(
                    (_amountCovered / MonthsSlider.Value).ToString())));
            }
        }

    }
}
