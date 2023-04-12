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
        private string messageLoanApproved { get; set; } = string.Empty;
        private string messageLoanDeny { get; set; } = string.Empty;
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
        public void SetMessage(string code)
        {
            if (code == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
            {
                resultTextBox.Text = messageLoanApproved;
            }
            else resultTextBox.Text = messageLoanDeny;
        }
        public void SetLoanParams(double loanAmount, int loanMonths, double loanInstallment, string currency, double loanCost)
        {
            messageLoanApproved = "The bank has approved your loan. The loan will be sent immediately. Your loan cost: " + loanCost + "%" + " \nYour loan: \nAmount: " +
                loanAmount.ToString() + currency + "\nTime: " + loanMonths.ToString() + " months" + "\nFinal monthly installment: " + loanInstallment.ToString() +
                currency.ToUpper() + "\nBilling period is a one season stage. Thank you for using our services.";
            messageLoanDeny = "We are sorry, but We can't give You this loan due to the following issue:\nYou already have a loans and " +
                "your creditworthiness is insufficient.";
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            finishButtonPressed = true;
        }
    }
}
