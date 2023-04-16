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
using FSIncome.Windows.Pages.CreateFarmProfile;

namespace FSIncome.Windows.Pages
{
    public partial class CreateFarmProfilePage : Page
    {
        //interface members
        private IAddData addMachinesPage = new AddMachinesPage();
        private IAddData addAnimalsPage = new AddAnimalsPage();
        private IAddData addFieldsPage = new AddFieldsPage();

        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; } = false;

        private DispatcherTimer pageTimer;
        public CreateFarmProfilePage()
        {
            InitializeComponent();
            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;

            var settingsFile = FileClass.ReadSettingsFile();
            CurrencyLabel.Content = settingsFile.currency.ToUpper();
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage.goBack)
            {
                addMachinesPage.goBack = false;
                pageFrame.Content = addAnimalsPage;
                addAnimalsPage.profileNumber = profileNumber;
                addAnimalsPage.farmProfileNumber = farmProfileNumber;
                addAnimalsPage.LoadData();
            }

            if (addAnimalsPage.goBack)
            {
                addAnimalsPage.goBack = false;
                pageFrame.Content = addFieldsPage;
                addFieldsPage.profileNumber = profileNumber;
                addFieldsPage.farmProfileNumber = farmProfileNumber;
                addFieldsPage.LoadData();
            }
            if (addFieldsPage.goBack)
            {
                addFieldsPage.goBack = false;
                pageFrame.Content = null;
                goBack = true;

                double totalLandSize = 0;
                double totalMachinesPrice = 0;
                var profilesDataFile1 = FileClass.ReadProfilesDataFile();
                for (int i = 0; i < profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].fieldsTag.fields.Count; i++)
                {
                    totalLandSize += profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].fieldsTag.fields[i].size;
                }
                for (int i = 0; i < profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.Count; i++)
                {
                    totalMachinesPrice += profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines[i].price;
                }

                profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].totalLandSize = totalLandSize;
                profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice = totalMachinesPrice;

                FileClass.SaveProfilesDataFile(profilesDataFile1);
            }

        }
        public void ClearControls()
        {
            NameTextBox.Text = "";
            LocalisationTextBox.Text = "";
            BankAccTextBox.Text = "";
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;  
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text.Length!=0 && LocalisationTextBox.Text.Length!=0 && BankAccTextBox.Text.Length!=0)
            {
                if (double.TryParse(ResourcesClass.ChangeSeperator(BankAccTextBox.Text), out double result))
                {
                    var profilesDataFile = FileClass.ReadProfilesDataFile();
                    
                    profilesDataFile.AddFarmProfile(NameTextBox.Text, LocalisationTextBox.Text, 
                        double.Parse(ResourcesClass.ChangeSeperator(BankAccTextBox.Text)), 
                        profileNumber);
                    FileClass.SaveProfilesDataFile(profilesDataFile);

                    pageFrame.Content = addMachinesPage;
                    addMachinesPage.profileNumber = profileNumber;
                    addMachinesPage.farmProfileNumber = farmProfileNumber;
                    addMachinesPage.LoadData();
                }
                else MessageBox.Show("Inappropriate value");
            }
            else MessageBox.Show("Enter all required data");
        }
    }
}
