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
        public bool pageCreated { get; set; } = false;
        public string currency { get; set; } = "PLN";
        public bool takeLoanButtonPressed { get; set; } = false;
        public double loanAmount { get; set; }
        public int loanMonths { get; set; }
        public double loanInstallment { get; set; }


        public TakeNormalLoanPage()
        {
            InitializeComponent();
        }
        public void InitComponents(int bankNumber)
        {
            var file = FileClass.ReadSystemFile();

            if(bankNumber==1)
            {
                LoanTextBlock.Text = "500 " + currency.ToUpper();
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
                LoanTextBlock.Text = "500 " + currency.ToUpper();
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
                LoanTextBlock.Text = "1000 " + currency.ToUpper();
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
                var val = (LoanSlider.Value / MonthsSlider.Value).ToString();
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

                LoanTextBlock.Text = LoanSlider.Value.ToString() + " " + currency.ToUpper();
                InstallmentTextBlock.Text = endVal + " " + currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void MonthsSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (pageCreated)
            {
                var val = (LoanSlider.Value / MonthsSlider.Value).ToString();
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

                MonthsTextBlock.Text = MonthsSlider.Value.ToString() + " MONTHS";
                InstallmentTextBlock.Text = endVal + " " + currency.ToUpper() + " INSTALLMENT";
            }
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageCreated)
            {
                takeLoanButtonPressed = true;
                var val = (LoanSlider.Value / MonthsSlider.Value).ToString();
                var endVal = "";
                int decNumbers = 0;
                bool countDecNumb = false;
                for (int i = 0; i < val.Length; i++)
                {
                    if (val[i] == ',')
                    {
                        countDecNumb = true;
                        endVal += ',';
                    }
                    else
                    {
                        if (countDecNumb) decNumbers++;
                        endVal += val[i];
                        if (decNumbers == 2) break;
                    }

                }

                loanAmount = LoanSlider.Value;
                loanMonths = (int)MonthsSlider.Value;
                loanInstallment = double.Parse(endVal);
            }
        }
    }
}
