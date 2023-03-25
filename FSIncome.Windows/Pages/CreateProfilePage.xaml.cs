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

namespace FSIncome.Windows.Pages
{
    public partial class CreateProfilePage : Page
    {
        public bool goBack { get; set; } = false;
        private int profileNumber { get; set; }

        public CreateProfilePage()
        {
            InitializeComponent();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Length > 0) ResourcesClass.SaveToConfigFile(ResourcesClass.projectPath, "#profiles", "<profile" + profileNumber + "=" + NameTextBox.Text + ">");
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            goBack = true;
        }
        public void SetProfileNumber(int number)
        {
            profileNumber = number;
        }
    }
}
