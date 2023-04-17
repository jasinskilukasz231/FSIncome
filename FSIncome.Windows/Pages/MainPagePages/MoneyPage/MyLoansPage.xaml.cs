using FSIncome.Core.Files;
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
    public partial class MyLoansPage : Page
    {
        public bool goBack { get; set; } = false;
        public MyLoansPage()
        {
            InitializeComponent();
        }
        public void UpdateLoansData(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            dataGrid.ItemsSource = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.loanItems;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
