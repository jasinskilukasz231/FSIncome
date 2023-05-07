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

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class TakeLoanPage : Page
    {
        public bool normalLoan { get; set; }
        public bool hypothethicLoan { get; set; }

        private string _loanType { get; set; }
        public string LoanType
        {
            get { return _loanType; }
        }


        public TakeLoanPage()
        {
            InitializeComponent();
        }

        private void NormalLoanButton_Click(object sender, RoutedEventArgs e)
        {
            normalLoan = true;
            _loanType = ResourcesClass.LoanType.Standard.ToString();
        }

        private void HypotheticLoanButton_Click(object sender, RoutedEventArgs e)
        {
            hypothethicLoan = true;
            _loanType = ResourcesClass.LoanType.Hypothetical.ToString();
        }
    }
}
