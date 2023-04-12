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
        private string bank1Description { get; set; }
        private string bank2Description { get; set; }
        private string bank3Description { get; set; }
        public BankInfoPage()
        {
            InitializeComponent();

            bank1Description = "In our bank the interest rate is determined by the total amount of money you have loaned from us." +
                " It means that the first loan is the cheapest and the next ones are a little bit more expensive" +
                " But we can ensure You that the first loan in our bank is the cheapest on the market!" +
                "\nMax loan in our bank is 20k";
            bank2Description = "Our bank can ensure You that the prices of our loans are constant. If you are a farmer and your farm is medium or large" +
                " You can get a 0% 3rd loan!" + "\nMax loan amount is 35k";
            bank3Description = "We offer loans for everything! If you are a farmer, You can get an extra discount depending on your farm size!" +
                " Loans even for 48 months! Our bank re" +
                "members our customers! We will give You discounts for Your future loans!";
        }
        public void SetBankDescription(int bankNumber)
        {
            if(bankNumber==1){ bankDescriptionTB.Text = bank1Description; this.bankNumber=bankNumber; }
            if(bankNumber==2){ bankDescriptionTB.Text = bank2Description; this.bankNumber=bankNumber; }
            if(bankNumber==3){ bankDescriptionTB.Text = bank3Description; this.bankNumber=bankNumber; }
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
