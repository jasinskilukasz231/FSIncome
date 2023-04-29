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
    public partial class TakeNormalLoanPage : Page
    {
        public bool pageCreated { get; set; }
        public bool takeLoanButtonPressed { get; set; }

        private string _currency { get; set; }
        private double _loanAmount { get; set; }
        public double LoanAmount
        {
            get
            {
                return _loanAmount;
            }
            set
            {
                _loanAmount = value;
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


        public TakeNormalLoanPage()
        {
            InitializeComponent();
        }
        public void InitComponents(int bankNumber)
        {
            var settingsFile = FileClass.ReadSettingsFile();
            _currency = settingsFile.currency;

            var file = FileClass.ReadSystemFile();

            if(bankNumber==1)
            {
                LoanTextBlock.Text = "500 " + _currency.ToUpper();
                MonthsTextBlock.Text = "1 MONTHS";
                InstallmentTextBlock.Text = "500 INSTALLMENT";
                LoanSlider.Value = 500;
                MonthsSlider.Maximum = 36;
                MonthsSlider.Value = 1;

                LoanSlider.Maximum = file.bankData.bank1Item.singleLoanMaxAmount;
                LoanSlider.TickFrequency = 500;
            }
            if (bankNumber == 2)
            {
                LoanTextBlock.Text = "500 " + _currency.ToUpper();
                MonthsTextBlock.Text = "1 MONTHS";
                InstallmentTextBlock.Text = "500 INSTALLMENT";
                LoanSlider.Value = 500;
                MonthsSlider.Maximum = 36;
                MonthsSlider.Value = 1;

                LoanSlider.Maximum = file.bankData.bank2Item.singleLoanMaxAmount;
                LoanSlider.TickFrequency = 500;
            }
            else if(bankNumber==3)
            {
                LoanTextBlock.Text = "1000 " + _currency.ToUpper();
                MonthsTextBlock.Text = "1 MONTHS";
                InstallmentTextBlock.Text = "1000 INSTALLMENT";
                MonthsSlider.Maximum = 48;
                LoanSlider.Value = 500;
                MonthsSlider.Value = 1;

                LoanSlider.Maximum = file.bankData.bank3Item.singleLoanMaxAmount;
                LoanSlider.TickFrequency = 1000;
            }
        }

        private void LoanSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pageCreated)
            {
                LoanTextBlock.Text = LoanSlider.Value.ToString() + " " + _currency.ToUpper();
                InstallmentTextBlock.Text = ResourcesClass.SetTwoDecimalNumbers((LoanSlider.Value / MonthsSlider.Value).ToString()) + 
                    " " + _currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void MonthsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pageCreated)
            {
                MonthsTextBlock.Text = MonthsSlider.Value.ToString() + " MONTHS";
                InstallmentTextBlock.Text = ResourcesClass.SetTwoDecimalNumbers((LoanSlider.Value / MonthsSlider.Value).ToString()) + 
                    " " + _currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageCreated)
            {
                takeLoanButtonPressed = true;

                _loanAmount = LoanSlider.Value;
                _loanMonths = (int)MonthsSlider.Value;
                _loanInstallment = double.Parse(ResourcesClass.ChangeSeperator(ResourcesClass.SetTwoDecimalNumbers(
                    (LoanSlider.Value / MonthsSlider.Value).ToString())));
            }
        }
    }
}
