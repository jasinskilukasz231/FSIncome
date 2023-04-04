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

namespace FSIncome.Windows.Pages.CreateFarmProfile
{
    /// <summary>
    /// Interaction logic for AddFieldsPage2.xaml
    /// </summary>
    public partial class AddFieldsPage2 : Page
    {
        public bool goBack { get; set; } = false;
        public AddFieldsPage2()
        {
            InitializeComponent();
        }
        public string[] ReturnData()
        {
            string[] dataLine = new string[5];
            dataLine[0] = NumberTextBox.Text;

            var var1 = SizeTextBox.Text;
            var var2 = "";
            for (int i = 0; i < var1.Length; i++)
            {
                if (var1[i] == '.') var2 += ',';
                else var2 += var1[i];
            }
            dataLine[1] = var2;

            dataLine[2] = CropsTextBox.Text;
            dataLine[3] = GroundTextBox.Text;

            var1 = PriceTextBox.Text;
            var2 = "";
            for (int i = 0; i < var1.Length; i++)
            {
                if (var1[i] == '.') var2 += ',';
                else var2 += var1[i];
            }
            dataLine[4] = var2;

            NumberTextBox.Text=string.Empty;
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
                goBack = true;
            }
            else
            {
                MessageBox.Show("Enter all required data");
            }
        }
    }
}
