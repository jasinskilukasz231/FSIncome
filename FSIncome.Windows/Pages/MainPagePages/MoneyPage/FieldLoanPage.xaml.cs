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
    public partial class FieldLoanPage : Page
    {
        public bool goBack { get; set; }
        public bool takeLoanPressed { get; set; }
        public double fieldPrice { get; set; }
        public double fieldSize { get; set; }
        public FieldLoanPage()
        {
            InitializeComponent();
        }
        public void ClearControls()
        {
            NumberTextBox.Text = string.Empty;
            SizeTextBox.Text = string.Empty;
            GroundTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;
            CropsTextBox.Text = string.Empty;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumberTextBox.Text != string.Empty &&
                SizeTextBox.Text != string.Empty &&
                GroundTextBox.Text != string.Empty &&
                PriceTextBox.Text != string.Empty &&
                CropsTextBox.Text != string.Empty)
            {
                if (int.TryParse(NumberTextBox.Text, out int value))
                {
                    if (value > 0)
                    {
                        if (double.TryParse(ResourcesClass.ChangeSeperator(SizeTextBox.Text), out double value1))
                        {
                            if (value1 > 0)
                            {
                                if (double.TryParse(ResourcesClass.ChangeSeperator(PriceTextBox.Text), out double value2))
                                {
                                    if (value2 > 0)
                                    {
                                        takeLoanPressed = true;
                                        fieldSize = value1;
                                        fieldPrice = value2;
                                    }
                                    else MessageBox.Show("Inappropriate value");
                                }
                                else MessageBox.Show("Inappropriate value");
                            }
                            else MessageBox.Show("Inappropriate value");
                        }
                        else MessageBox.Show("Inappropriate value");
                    }
                    else MessageBox.Show("Inappropriate value");
                }
                else MessageBox.Show("Inappropriate value");
            }
            else MessageBox.Show("Enter all required data");
        }
    }
}
