using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Loans
{
    public class LoanMessage
    {
        private string standardMessageLoanApproved = string.Empty;
        private string standardMessageLoanDeny = string.Empty;
        private string hypotheticalMessageLoanApprovedField = string.Empty;
        private string hypotheticalMessageLoanApprovedFertilizer = string.Empty;
        private string amountNotEnoughtFertilizerDeny = string.Empty;
        private string hypotheticalMessageLoanDeny = string.Empty;
        private string hypotheticalFieldNotEnoughtMoneyDeny = string.Empty;
        private string hypotheticalFarmTooSmallDeny = string.Empty;

        public void PrepareMessagesDeny()
        {
            //preparing messages that dont require variables
            standardMessageLoanDeny = "We are sorry, but We can't give You this loan due to the following issue:\nYou already have a loans and " +
                "your creditworthiness is insufficient.";
            hypotheticalFieldNotEnoughtMoneyDeny = "You dont have enought money to pay the self deposit!";
            hypotheticalMessageLoanDeny = "We are sorry but the bank has rejected your application. It is because you already have loans and " +
                       "your creditworthiness is insufficient";
            hypotheticalFarmTooSmallDeny = "We are sorry but we only give loans to big farms, your farm is too small.";
            amountNotEnoughtFertilizerDeny = "We are sorry but we only give loans for over 2 tone of the fertilizer. Your amount is not enought";
        }
        public void PrepareStandardMessage(double loanAmount, int loanMonths, double loanInstallment, string currency, double loanCost)
        {
            //preparing message
            standardMessageLoanApproved = "The bank has approved your loan. The loan will be sent immediately. Your loan cost: " + loanCost + "%" + " \nYour loan: \nAmount: " +
                loanAmount.ToString() + currency + "\nTime: " + loanMonths.ToString() + " months" + "\nFinal monthly installment: " + loanInstallment.ToString() +
                currency.ToUpper() + "\nBilling period is a one season stage. Thank you for using our services.";

        }
        public void PrepareHypotheticalMessage(string loanType, double amountCovered, double loanInterestRate, double loanInstallment,
           double itemTotalPrice, double percentCovered = 0, double fertiSize = 0)
        {
            //preparing message
            
            var file = FileClass.ReadSettingsFile();
            string currency = file.currency;

            if (loanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
            {
                hypotheticalMessageLoanApprovedField = "The bank has approved your loan. The bank will cover " + percentCovered +
                    "% of the field price which is " + amountCovered.ToString() + currency +
                    ". You have to pay " + (itemTotalPrice - amountCovered).ToString() + currency + ". The loan interest is " + loanInterestRate.ToString() +
                    "%, and the loan installment is" + loanInstallment.ToString() + currency + "." + "\nThank you for using our services.";
            }
            if (loanType == ResourcesClass.HypotheticalLoanTypes.machine.ToString())
            {

            }
            else
            {
                hypotheticalMessageLoanApprovedFertilizer = "The bank has approved your loan. " +
                    "\nFertilizer:\nFertilizer amount: " + fertiSize.ToString() + "kg" +
                    "\nTotal price: " + itemTotalPrice.ToString() + currency.ToUpper() +
                    " \nLoan:\n Loan interest rate: " + loanInterestRate.ToString() +
                    "%\nLoan installment: " + loanInstallment.ToString() + currency + "\nThank you for using our services.";
            }
        }
        public string SetMessage(string code, string loanType)
        {
            if (loanType == ResourcesClass.LoanType.Standard.ToString())
            {
                if (code == ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString())
                {
                    return standardMessageLoanApproved;
                }
                else return standardMessageLoanDeny;
            }
            else
            {
                if (code == ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString())
                {
                    return hypotheticalMessageLoanApprovedField;
                }
                else if (code == ResourcesClass.LoanCheckMessageCode.NotEnoughtMoneyField.ToString())
                {
                    return hypotheticalFieldNotEnoughtMoneyDeny;
                }else if (code == ResourcesClass.LoanCheckMessageCode.amountNotEnoughtFertilizerDeny.ToString())
                {
                    return amountNotEnoughtFertilizerDeny;
                }
                else if (code == ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString())
                {
                    return hypotheticalFarmTooSmallDeny;
                }
                else if (code == ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString())
                {
                    return hypotheticalMessageLoanApprovedFertilizer;
                }
                else return hypotheticalMessageLoanDeny;
            }

        }
    }
}
