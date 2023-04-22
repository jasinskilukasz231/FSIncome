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
    public partial class ResultPage : Page
    {
        private string standardMessageLoanApproved { get; set; } = string.Empty;
        private string standardMessageLoanDeny { get; set; } = string.Empty;
        private string hypotheticalMessageLoanApproved { get; set; } = string.Empty;
        private string hypotheticalMessageLoanDeny { get; set; } = string.Empty;
        private string hypotheticalFieldNotEnoughtMoneyDeny { get; set; } = string.Empty;
        private string hypotheticalFarmTooSmallDeny { get; set; } = string.Empty;
        public bool finishButtonPressed { get; set; } = false;
        public bool backButtonPressed { get; set; } = false;
        public ResultPage()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            backButtonPressed = true;
        }
        public void SetMessage(string code, string loanType="")
        {
            if(loanType==ResourcesClass.LoanType.Standard.ToString())
            {
                if (code == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
                {
                    resultTextBox.Text = standardMessageLoanApproved;
                }
                else resultTextBox.Text = standardMessageLoanDeny;
            }
            else
            {
                if (code == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
                {
                    resultTextBox.Text = hypotheticalMessageLoanApproved;
                }
                else if(code == ResourcesClass.LoanCheckMessageCode.NotEnoughtMoney.ToString())
                {
                    resultTextBox.Text = hypotheticalFieldNotEnoughtMoneyDeny;
                }
                else if(code== ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString())
                {
                    resultTextBox.Text = hypotheticalFarmTooSmallDeny;
                }
                else resultTextBox.Text = hypotheticalMessageLoanDeny;
            }
            
        }
        public void SetNormalLoanParams(double loanAmount, int loanMonths, double loanInstallment, string currency, double loanCost)
        {
            standardMessageLoanApproved = "The bank has approved your loan. The loan will be sent immediately. Your loan cost: " + loanCost + "%" + " \nYour loan: \nAmount: " +
                loanAmount.ToString() + currency + "\nTime: " + loanMonths.ToString() + " months" + "\nFinal monthly installment: " + loanInstallment.ToString() +
                currency.ToUpper() + "\nBilling period is a one season stage. Thank you for using our services.";
            standardMessageLoanDeny = "We are sorry, but We can't give You this loan due to the following issue:\nYou already have a loans and " +
                "your creditworthiness is insufficient.";
        }
        public void SetHypotheticalLoanParams(string loanType, double percentCovered, double loanInterestRate, double loanInstallment, string currency,
            double itemTotalPrice)
        {
            double loanPaydByBank = (itemTotalPrice * 90) / 100;

            if (loanType==ResourcesClass.HypotheticalLoanTypes.field.ToString())
            {
                hypotheticalMessageLoanApproved = "The bank has approved your loan. The bank will cover " + percentCovered.ToString() +
                    "% of the field price which is " + loanPaydByBank.ToString() + currency +
                    ". You have to pay " + (itemTotalPrice - loanPaydByBank).ToString() + currency + ". The loan interest is " + loanInterestRate.ToString() +
                    "%, and the loan installment is" + loanInstallment.ToString() + currency + "." + "\nThank you for using our services.";

                hypotheticalMessageLoanDeny = "We are sorry but the bank has rejected your application. It is because you already have loans and " +
                    "your creditworthiness is insufficient";

                hypotheticalFieldNotEnoughtMoneyDeny = "You dont have enought money to pay the self deposit!";
            }
            if (loanType == ResourcesClass.HypotheticalLoanTypes.machine.ToString())
            {
                hypotheticalMessageLoanApproved = "The bank has approved your loan. The bank will cover " + percentCovered.ToString() +
                    "% of the machine price which is " + loanPaydByBank.ToString() + currency +
                    ". You have to pay " + (itemTotalPrice - loanPaydByBank).ToString() + currency + ". The loan interest is " + loanInterestRate.ToString() +
                    "%, and the loan installment is" + loanInstallment.ToString() + currency + "." + "\nThank you for using our services.";

                hypotheticalMessageLoanDeny = "We are sorry but the bank has rejected your application. It is because you already have loans and " +
                    "your creditworthiness is insufficient";
            }
            else
            {
                hypotheticalMessageLoanApproved = "The bank has approved your loan. \nLoan: Loan interest rate: " + loanInterestRate.ToString() +
                    "%\nLoan installment: " + loanInstallment.ToString() + currency + "\nThank you for using our services.";

                hypotheticalMessageLoanDeny = "We are sorry but the bank has rejected your application. It is because you already have loans and " +
                    "your creditworthiness is insufficient";
            }

            hypotheticalFarmTooSmallDeny = "We are sorry but we only give loans to big farms, your farm is too small.";
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            finishButtonPressed = true;
        }
    }
}
