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
using System.Windows.Threading;

namespace FSIncome.Windows.Pages
{
    public partial class ProfilePage : Page
    {
        public bool goBack { get; set; }
        private Button[] profileButtons;
        private DispatcherTimer pageTimer;
        private CreateProfilePage createProfilePage;
        private FarmProfilesPage farmProfilesPage;

        private Dictionary<string, string> appImages;   

        public ProfilePage(Dictionary<string, string> appImages)
        {
            this.appImages = appImages; 
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            DataContext = appImages;

            profileButtons = new Button[5];

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true; 

            profileButtons[0] = button1;
            profileButtons[1] = button2;
            profileButtons[2] = button3;
            profileButtons[3] = button4;
            profileButtons[4] = button5;

        }
        public void LoadProfiles()
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            //making all button not visible
            foreach (var i in profileButtons)
            {
                i.Visibility = Visibility.Hidden;
            }
            //making visible profiles.count + 1
            if (profilesDataFile.profiles.Count < 5)
            {
                for (int i = 0; i < profilesDataFile.profiles.Count + 1; i++)
                {
                    profileButtons[i].Visibility = Visibility.Visible;
                    if (i < profilesDataFile.profiles.Count) profileButtons[i].Content = profilesDataFile.profiles[i].name;
                    else profileButtons[i].Content = "Create new profile";
                }
            }
            else
            {
                for (int i = 0; i < profilesDataFile.profiles.Count; i++)
                {
                    profileButtons[i].Visibility = Visibility.Visible;
                    profileButtons[i].Content = profilesDataFile.profiles[i].name;
                }
            }

        }

        private void PageTimer_Tick(object sender, EventArgs e)
        {
            if(createProfilePage!= null)
            {
                if (createProfilePage.goBack == true)
                {
                    PageFrame.Navigate(null);
                    createProfilePage.goBack = false;
                    LoadProfiles();

                    //remove this
                    BackButton.Visibility = Visibility.Visible;
                }
            }
            
            if(farmProfilesPage!= null)
            {
                if (farmProfilesPage.goBack == true)
                {
                    PageFrame.Navigate(null);
                    farmProfilesPage.goBack = false;
                    LoadProfiles();

                    //remove this
                    BackButton.Visibility = Visibility.Visible;
                }
            }
        }
        
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();

            if ((sender as Button).Content == "Create new profile")
            {
                createProfilePage = new CreateProfilePage(appImages);

                if (sender == button1) createProfilePage.profileNumber = 0;
                else if (sender == button2) createProfilePage.profileNumber = 1;
                else if (sender == button3) createProfilePage.profileNumber = 2;
                else if (sender == button4) createProfilePage.profileNumber = 3;
                else createProfilePage.profileNumber = 4;

                PageFrame.Navigate(createProfilePage);
                createProfilePage.ClearTextBox();

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage = new FarmProfilesPage(appImages);

                //setting header name
                if (sender == button1) { farmProfilesPage.SetPageHeader(profilesDataFile.profiles[0].name); farmProfilesPage.profileNumber = 0; }
                else if (sender == button2) { farmProfilesPage.SetPageHeader(profilesDataFile.profiles[1].name); farmProfilesPage.profileNumber = 1; }
                else if (sender == button3) { farmProfilesPage.SetPageHeader(profilesDataFile.profiles[2].name); farmProfilesPage.profileNumber = 2; }
                else if (sender == button4) { farmProfilesPage.SetPageHeader(profilesDataFile.profiles[3].name); farmProfilesPage.profileNumber = 3; }
                else { farmProfilesPage.SetPageHeader(profilesDataFile.profiles[4].name); farmProfilesPage.profileNumber = 4; }
                
                farmProfilesPage.UpdateProfiles();
                PageFrame.Navigate(farmProfilesPage);

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
