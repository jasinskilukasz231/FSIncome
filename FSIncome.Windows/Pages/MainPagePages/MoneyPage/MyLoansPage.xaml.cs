using FSIncome.Core.Files;
using System;
using System.Collections;
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
    public partial class MyLoansPage : Page
    {
        public bool goBack { get; set; }

        private ArrayList loans = new ArrayList();
        public MyLoansPage()
        {
            InitializeComponent();
        }
        public void UpdateLoansData(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.standardLoanTag.loanItems)
            {
                loans.Add(i);
            }
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.hypotheticalLoanTag.loanItems)
            {
                loans.Add(i);
            }

            dataGrid.ItemsSource = loans;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
