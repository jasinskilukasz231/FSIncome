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
    public partial class TakeHypotheticalLoanPage : Page
    {
        public bool goBack { get; set; }
        public bool fieldButtonPressed { get; set; }
        public bool machineButtonPressed { get; set; }
        public bool fertiButtonPressed { get; set; }

        public string HypotheticalLoanType
        {
            get { return _hypotheticalLoanType; }
        }
        private string _hypotheticalLoanType { get; set; }

        public TakeHypotheticalLoanPage()
        {
            InitializeComponent();
        }

        private void fieldButon_Click(object sender, RoutedEventArgs e)
        {
            fieldButtonPressed = true;
            _hypotheticalLoanType = ResourcesClass.HypotheticalLoanTypes.field.ToString();
        }
        private void machineButon_Click(object sender, RoutedEventArgs e)
        {
            machineButtonPressed = true;
            _hypotheticalLoanType = ResourcesClass.HypotheticalLoanTypes.machine.ToString();
        }
        private void fertiButon_Click(object sender, RoutedEventArgs e)
        {
            fertiButtonPressed = true;
            _hypotheticalLoanType = ResourcesClass.HypotheticalLoanTypes.fertilizer.ToString();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
