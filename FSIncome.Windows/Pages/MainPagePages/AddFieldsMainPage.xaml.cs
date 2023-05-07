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

namespace FSIncome.Windows.Pages.MainPagePages
{

    public partial class AddFieldsMainPage : Page
    {
        public bool goBack { get; set; }
        public AddFieldsMainPage()
        {
            InitializeComponent();
        }
        public string[] ReturnData()
        {
            string[] dataLine = new string[5];
            dataLine[0] = NumberTextBox.Text;
            dataLine[1] = ResourcesMethods.ChangeSeperator(SizeTextBox.Text);
            dataLine[2] = CropsTextBox.Text;
            dataLine[3] = GroundTextBox.Text;
            dataLine[4] = ResourcesMethods.ChangeSeperator(PriceTextBox.Text);

            NumberTextBox.Text = string.Empty;
            SizeTextBox.Text = string.Empty;
            CropsTextBox.Text = string.Empty;
            GroundTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;

            return dataLine;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
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
                        if (double.TryParse(ResourcesMethods.ChangeSeperator(SizeTextBox.Text), out double size))
                        {
                            if (size > 0)
                            {
                                if (double.TryParse(ResourcesMethods.ChangeSeperator(PriceTextBox.Text), out double price))
                                {
                                    if (price > 0) goBack = true;
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
