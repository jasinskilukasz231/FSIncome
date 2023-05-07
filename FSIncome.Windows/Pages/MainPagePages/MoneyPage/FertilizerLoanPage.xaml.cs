using FSIncome.Core;
using FSIncome.Core.Files;
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
    public partial class FertilizerLoanPage
    {
        public bool goBack { get; set; }
        public bool takeLoanPressed { get; set; }

        private double _fertilizerSize { get; set; }
        private double _fertiTotalPrice { get; set; }
        public double FertiTotalPrice
        {
            get { return _fertiTotalPrice; }
        }
        public double FertilizerSize
        { 
            get { return _fertilizerSize; } 
        }
        public FertilizerLoanPage()
        {
            InitializeComponent();
        }

        public void ClearControls()
        {
            AmountTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;

            var file = FileClass.ReadSettingsFile();
            currencyLabel.Content = file.currency.ToUpper();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }

        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (AmountTextBox.Text != string.Empty &&
                PriceTextBox.Text != string.Empty)
            {
                if (double.TryParse(AmountTextBox.Text, out double amount))
                {
                    if (amount > 0)
                    {
                        if (double.TryParse(ResourcesMethods.ChangeSeperator(PriceTextBox.Text), out double price))
                        {
                            if (price > 0)
                            {
                                if (price > 0)
                                {
                                    takeLoanPressed = true;
                                    _fertilizerSize = amount;
                                    _fertiTotalPrice = (amount / 1000) * price;
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
