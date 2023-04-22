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

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class BankInfoPage : Page
    {
        public int bankNumber { get; set; }
        public bool backButtonPressed { get; set; }
        public bool nextButtonPressed { get; set; }
        private string bank1DescriptionNorm { get; set; }
        private string bank2DescriptionNorm { get; set; }
        private string bank3DescriptionNorm { get; set; }
        private string bank1DescriptionHypo { get; set; }
        private string bank2DescriptionHypo { get; set; }
        private string bank3DescriptionHypo { get; set; }
        public string loanType { get; set; }
        public BankInfoPage()
        {
            InitializeComponent();

            //add variables here

            bank1DescriptionNorm = "In our bank the interest rate is determined by the total amount of money you have loaned from us." +
                " It means that the first loan is the cheapest and the next ones are a little bit more expensive" +
                " But we can ensure You that the first loan in our bank is the cheapest on the market!" +
                "\nMax loan in our bank is 20k";
            bank2DescriptionNorm = "Our bank can ensure You that the prices of our loans are constant. If you are a farmer and your farm is medium or large" +
                " You can get a 0% 3rd loan!" + "\nMax loan amount is 35k";
            bank3DescriptionNorm = "We offer loans for everything! If you are a farmer, You can get an extra discount depending on your farm size!" +
                " Loans even for 48 months! Our bank re" +
                "members our customers! We will give You discounts for Your future loans!";
            bank1DescriptionHypo = "We offer big loans for the biggest farms. You can take the loan for: \nLand - we pay 90% of the land price\n" +
                "New or less than 20 year's old machines - we pay 80% of the machine price\nFertilizers - if you want to buy over 2 tones of it.\n" +
                "You can have only one hypothethical loan in our bank, but you can have also a standard loans. The interest rate of our loan is 5.98%";
            bank2DescriptionHypo = "Hypothethical loan offer\nIf you need a loan for buying a new field, buying new machine, or for the fertilizers, you" +
                " are in the right place! We offer a loan:\n-Loan for machine, 4.29%, new or less than 20 years old machines\n" +
                "-Loan for fertilizers, 6.69%, must be more than 2 tones\n-Field loan, covering 90% of the land price";
            bank3DescriptionHypo = "If you need money you are in the good hands!\nIn our facility you can take the loan for everything that big farmer needs." +
                "We offer a 4.29% loan";
        }
        public void SetBankDescription(int bankNumber)
        {
            if(loanType==ResourcesClass.LoanType.Standard.ToString())
            {
                if (bankNumber == 1) { bankDescriptionTB.Text = bank1DescriptionNorm; this.bankNumber = bankNumber; }
                if (bankNumber == 2) { bankDescriptionTB.Text = bank2DescriptionNorm; this.bankNumber = bankNumber; }
                if (bankNumber == 3) { bankDescriptionTB.Text = bank3DescriptionNorm; this.bankNumber = bankNumber; }
            }
            else
            {
                if (bankNumber == 1) { bankDescriptionTB.Text = bank1DescriptionHypo; this.bankNumber = bankNumber; }
                if (bankNumber == 2) { bankDescriptionTB.Text = bank2DescriptionHypo; this.bankNumber = bankNumber; }
                if (bankNumber == 3) { bankDescriptionTB.Text = bank3DescriptionHypo; this.bankNumber = bankNumber; }
            }
            
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            backButtonPressed = true;
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            nextButtonPressed = true;
        }
    }
}
