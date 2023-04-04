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
using System.Windows.Threading;
using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Core.Interfaces;
using FSIncome.Windows.Pages.CreateFarmProfile;

namespace FSIncome.Windows.Pages
{
    public partial class CreateFarmProfilePage : Page
    {
        //interface members
        IAddData addMachinesPage = new AddMachinesPage();
        IAddData addAnimalsPage = new AddAnimalsPage();
        IAddData addFieldsPage = new AddFieldsPage();

        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; } = false;

        DispatcherTimer pageTimer = new DispatcherTimer();
        public CreateFarmProfilePage()
        {
            InitializeComponent();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;

            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            CurrencyLabel.Content = settingsFile.currency.ToUpper();
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage.goBack)
            {
                CreateFarmProfilePageFrame.Content = null;
                addMachinesPage.goBack = false;
            }
            if (addAnimalsPage.goBack)
            {
                CreateFarmProfilePageFrame.Content = null;
                addAnimalsPage.goBack = false;
            }
            if (addFieldsPage.goBack)
            {
                CreateFarmProfilePageFrame.Content = null;
                addFieldsPage.goBack = false;
            }

        }
        private void MachinesButton_Click(object sender, RoutedEventArgs e)
        {
            addMachinesPage.profileNumber = profileNumber;
            addMachinesPage.farmProfileNumber = farmProfileNumber;
            CreateFarmProfilePageFrame.Content = addMachinesPage;
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            addAnimalsPage.profileNumber = profileNumber;
            addAnimalsPage.farmProfileNumber = farmProfileNumber;
            CreateFarmProfilePageFrame.Content = addAnimalsPage;
        }

        private void FieldsButton_Click(object sender, RoutedEventArgs e)
        {
            addFieldsPage.profileNumber = profileNumber;
            addFieldsPage.farmProfileNumber = farmProfileNumber;
            CreateFarmProfilePageFrame.Content = addFieldsPage;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;  
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();

            var var1 = BankAccTextBox.Text;
            var var2 = "";
            for (int i = 0; i < var1.Length; i++)
            {
                if (var1[i] == '.') var2 += ',';
                else var2 += var1[i];
            }
            profilesDataFile.AddFarmProfile(NameTextBox.Text, LocalisationTextBox.Text, double.Parse(var2), profileNumber - 1);
            FileClass.SaveProfilesDataFile(profilesDataFile);   
            addMachinesPage.SaveToFile();
            addAnimalsPage.SaveToFile();
            addFieldsPage.SaveToFile();
        }
    }
}
