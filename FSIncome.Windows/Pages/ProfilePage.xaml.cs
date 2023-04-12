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
        public bool goBack { get; set; } = false;
        private Button[] profileButtons;

        private DispatcherTimer pageTimer;

        private CreateProfilePage createProfilePage;

        private FarmProfilesPage farmProfilesPage;


        public ProfilePage()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            profileButtons = new Button[5];
            pageTimer = new DispatcherTimer();
            createProfilePage = new CreateProfilePage();
            farmProfilesPage = new FarmProfilesPage();

            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true;

            profileButtons[0] = ButtonProfile1;
            profileButtons[1] = ButtonProfile2;
            profileButtons[2] = ButtonProfile3;
            profileButtons[3] = ButtonProfile4;
            profileButtons[4] = ButtonProfile5;

        }
        public void LoadProfiles()
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            foreach (var i in profileButtons)
            {
                i.Visibility = Visibility.Hidden;
            }
            if(profilesDataFile.profiles.Count < 5)
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
            if (createProfilePage.goBack == true) 
            {
                PageFrame.Content = null;
                createProfilePage.goBack = false;
                LoadProfiles();

                //remove this
                BackButton.Visibility = Visibility.Visible;
            }
            if (farmProfilesPage.goBack == true)
            {
                PageFrame.Content = null;
                farmProfilesPage.goBack = false;
                LoadProfiles();

                //remove this
                BackButton.Visibility = Visibility.Visible;
            }
        }

        private void ButtonProfile1Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            //setting header name
            if (profilesDataFile.profiles.Count <= 0) 
            {
                createProfilePage.profileNumber = 0;
                PageFrame.Content = createProfilePage;
                createProfilePage.NameTextBox.Text = "";

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage.SetPageHeader(profilesDataFile.profiles[0].name);
                farmProfilesPage.profileNumber = 0;
                farmProfilesPage.UpdateProfiles();
                PageFrame.Content = farmProfilesPage;

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonProfile2Click(object sender, RoutedEventArgs e)
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //setting header name
            if (profilesDataFile.profiles.Count <= 1)
            {
                createProfilePage.profileNumber = 1;
                PageFrame.Content = createProfilePage;
                createProfilePage.NameTextBox.Text = "";

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage.SetPageHeader(profilesDataFile.profiles[1].name);
                farmProfilesPage.profileNumber = 1;
                farmProfilesPage.UpdateProfiles();
                PageFrame.Content = farmProfilesPage;

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonProfile3Click(object sender, RoutedEventArgs e)
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //setting header name
            if (profilesDataFile.profiles.Count <= 2)
            {
                createProfilePage.profileNumber = 2;
                PageFrame.Content = createProfilePage;
                createProfilePage.NameTextBox.Text = "";

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage.SetPageHeader(profilesDataFile.profiles[2].name);
                farmProfilesPage.profileNumber = 2;
                farmProfilesPage.UpdateProfiles();
                PageFrame.Content = farmProfilesPage;

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonProfile4Click(object sender, RoutedEventArgs e)
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //setting header name
            if (profilesDataFile.profiles.Count <= 3)
            {
                createProfilePage.profileNumber = 3;
                PageFrame.Content = createProfilePage;
                createProfilePage.NameTextBox.Text = "";

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage.SetPageHeader(profilesDataFile.profiles[3].name);
                farmProfilesPage.profileNumber = 3;
                farmProfilesPage.UpdateProfiles();
                PageFrame.Content = farmProfilesPage;

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
        }
        private void ButtonProfile5Click(object sender, RoutedEventArgs e)
        {
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //setting header name
            if (profilesDataFile.profiles.Count <= 4)
            {
                createProfilePage.profileNumber = 4;
                PageFrame.Content = createProfilePage;
                createProfilePage.NameTextBox.Text = "";

                //remove this
                BackButton.Visibility = Visibility.Hidden;
            }
            else
            {
                farmProfilesPage.SetPageHeader(profilesDataFile.profiles[4].name);
                farmProfilesPage.profileNumber = 4;
                farmProfilesPage.UpdateProfiles();
                PageFrame.Content = farmProfilesPage;

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
