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
using FSIncome.Core.Files;

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class ResultPage : Page
    {
        public bool finishButtonPressed { get; set; }
        public bool backButtonPressed { get; set; }

        public ResultPage()
        {
            InitializeComponent();
        }
        public void SetMessage(string message)
        {
            resultTextBox.Text = message;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            backButtonPressed = true;
        }

        private void finishButton_Click(object sender, RoutedEventArgs e)
        {
            finishButtonPressed = true;
        }
    }
}
