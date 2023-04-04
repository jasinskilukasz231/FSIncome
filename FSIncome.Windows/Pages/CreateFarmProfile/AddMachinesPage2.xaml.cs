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
    public partial class AddMachinesPage2 : Page
    {
        public bool goBack { get; set; } = false;

        public AddMachinesPage2()
        {
            InitializeComponent();
        }

        private void TractorCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.Header = "TRACTOR";
            CategoryExpander.IsExpanded = false;
        }
        public string[] ReturnData()
        {
            string[] dataLine = new string[4];
            dataLine[0]=NameTextBox.Text;

            var var1 = PriceTextBox.Text;
            var var2 = "";
            for (int i = 0; i < var1.Length; i++)
            {
                if (var1[i] == '.') var2 += ',';
                else var2 += var1[i];
            }
            dataLine[1] = var2;

            dataLine[2]=BrandTextBox.Text;
            dataLine[3] = CategoryExpander.Header.ToString();

            NameTextBox.Text = string.Empty;
            PriceTextBox.Text = string.Empty;
            BrandTextBox.Text = string.Empty;

            return dataLine;
        }

        private void CombineCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.Header = "COMBINE";
            CategoryExpander.IsExpanded = false;
        }

        private void MachineCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.Header = "MACHINE";
            CategoryExpander.IsExpanded = false;
        }

        private void TrailerCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.Header = "TRAILER";
            CategoryExpander.IsExpanded = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text!= string.Empty &&
                PriceTextBox.Text != string.Empty &&
                BrandTextBox.Text != string.Empty)
            {
                goBack = true;
            }
            else
            {
                MessageBox.Show("Enter all required data");
            }
        }

        private void OtherCategoryButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CategoryExpander.Header = "OTHER";
            CategoryExpander.IsExpanded = false;
        }
    }
}
