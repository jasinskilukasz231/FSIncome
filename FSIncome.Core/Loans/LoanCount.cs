using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Loans
{
    public class LoanCount
    {
        public double CountLoanTotalAmount(double loanAmount, double loanCost)
        {
            var val = ((loanAmount * (100 + loanCost)) / 100).ToString();
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
            return double.Parse(endVal);
        }
        public double CountLoanTotalInstallment(double loanTotalAmount, int loanMonths)
        {
            var val = (loanTotalAmount / loanMonths).ToString();
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
            return double.Parse(endVal);
        }
        public double CheckBankCoveringAmount(string bankType)
        {
            var file = FileClass.ReadSystemFile();
            if (bankType == ResourcesClass.BankType.Bank1.ToString()) return file.bankData.bank1Item.fieldPercentCoverage;
            else if (bankType == ResourcesClass.BankType.Bank2.ToString()) return file.bankData.bank2Item.fieldPercentCoverage;
            else return file.bankData.bank3Item.fieldPercentCoverage;
        }
    }
}
