using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Loans
{
    //loan item for payLoanPage
    public class LoanItem
    {
        public string loanType { get; set; }
        public double loanTotalAmount { get; set; }
        public string bankType { get; set; }
        public int loanMonthTime { get; set; }
        public double loanPayd { get; set; }
        public double loanInstallment { get; set; }
        public string hypoLoanType { get; set; }
        public LoanItem(string loanType, double loanTotalAmount, string bankType, int loanMonthTime, double loanPayd, double loanInstallment,
            string hypoLoanType = "")
        {
            this.loanType = loanType;
            this.loanTotalAmount= loanTotalAmount;
            this.bankType = bankType;
            this.loanMonthTime= loanMonthTime;
            this.loanPayd= loanPayd;
            this.loanInstallment= loanInstallment;
            this.hypoLoanType = hypoLoanType;
        }
    }
}
