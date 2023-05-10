using FSIncome.Core;
using FSIncome.Core.Files;
using ScottPlot;
using ScottPlot.Renderable;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class MoneyPage : Page
    {
        public bool takeLoan { get; set; }
        public bool payLoan { get; set; }
        public bool seeLoans { get; set; }

        private PlotClass plotExpenditure;
        private PlotClass plotIncome;

        public MoneyPage()
        {
            InitializeComponent();

            plotExpenditure = new PlotClass(moneyPlotExpenditure);
            plotIncome = new PlotClass(moneyPlotIncome);
        }
        public void SetPlots(int profileNumber, int farmProfileNumber)
        {
            var settingsFile = FileClass.ReadSettingsFile();

            plotExpenditure.InitPlotValues(moneyPlotExpenditure, ResourcesClass.PlotType.moneyExpenditure.ToString(), profileNumber, farmProfileNumber);
            plotLegendExpenditureTextBlock.Text = "";
            foreach (var i in plotExpenditure.LegendLabels)
            {
                plotLegendExpenditureTextBlock.Text += i + "\n";
            }

            plotIncome.InitPlotValues(moneyPlotIncome, ResourcesClass.PlotType.moneyIncome.ToString(), profileNumber, farmProfileNumber);
            plotLegendIncomeTextBlock.Text = "";
            foreach (var i in plotIncome.LegendLabels)
            {
                plotLegendIncomeTextBlock.Text += i + "\n";
            }
            currencyTextBlock1.Text = settingsFile.currency.ToUpper();
            currencyTextBlock2.Text = settingsFile.currency.ToUpper();
            totalExpenditureTextBlock.Text = plotExpenditure.TotalExpenditureAmount.ToString();
            totalIncomeTextBlock.Text = plotIncome.TotalIncomeAmount.ToString();
        }
        
        public void UpdateBankAccountTB(int profileNr, int farmProfileNr) 
        {
            //updates text box 
            var file = FileClass.ReadProfilesDataFile();
            var settingsFile = FileClass.ReadSettingsFile();
            MoneyTextBlock.Text = "BANK ACCOUNT: " + ResourcesMethods.SetTwoDecimalNumbers(file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount.ToString()) +
                " " + settingsFile.currency.ToUpper();
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            takeLoan = true;
        }

        private void PayLoanLoanButton_Click(object sender, RoutedEventArgs e)
        {
            payLoan = true;
        }

        private void LoanButton_Click(object sender, RoutedEventArgs e)
        {
            seeLoans= true;
        }
    }
}
