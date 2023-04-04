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

namespace FSIncome.Windows.Pages
{
    public partial class CreateProfilePage : Page
    {
        public bool goBack { get; set; } = false;
        public int profileNumber { get; set; }


        public CreateProfilePage()
        {
            InitializeComponent();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Length > 0)
            {
                ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
                profilesDataFile.AddProfile(NameTextBox.Text);
                FileClass.SaveProfilesDataFile(profilesDataFile);
                goBack = true;
            }
        }
        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
