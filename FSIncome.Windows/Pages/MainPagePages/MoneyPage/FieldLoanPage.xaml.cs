using FSIncome.Core;
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
    public partial class FieldLoanPage : Page
    {
        public bool goBack { get; set; }
        public bool takeLoanPressed { get; set; }

        public double FieldPrice
        {
            get { return _fieldPrice; }
        }
        private double _fieldPrice { get; set; }
        private int fieldNumber { get; set; }
        public double FieldSize
        {
            get { return _fieldSize; }
        }
        private double _fieldSize { get; set; }

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
        public void SaveToFile(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            file.AddField(profileNumber, farmProfileNumber, fieldNumber, _fieldSize, CropsTextBox.Text, GroundTextBox.Text, _fieldPrice);

            //updating total amounts in the file
            double totalLandSize = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].totalLandSize;
            file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].totalLandSize = totalLandSize + _fieldSize;
            FileClass.SaveProfilesDataFile(file);
        }
        private void TakeLoanButton_Click(object sender, RoutedEventArgs e)
        {
            if (NumberTextBox.Text != string.Empty &&
                SizeTextBox.Text != string.Empty &&
                GroundTextBox.Text != string.Empty &&
                PriceTextBox.Text != string.Empty &&
                CropsTextBox.Text != string.Empty)
            {
                if (int.TryParse(NumberTextBox.Text, out int number))
                {
                    if (number > 0)
                    {
                        if (double.TryParse(ResourcesMethods.ChangeSeperator(SizeTextBox.Text), out double size))
                        {
                            if (size > 0)
                            {
                                if (double.TryParse(ResourcesMethods.ChangeSeperator(PriceTextBox.Text), out double price))
                                {
                                    if (price > 0)
                                    {
                                        takeLoanPressed = true;
                                        fieldNumber = number;
                                        _fieldSize = size;
                                        _fieldPrice = price;
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
