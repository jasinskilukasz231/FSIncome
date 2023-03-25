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
using System.Windows.Threading;

namespace FSIncome.Windows.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private Button[] profileButtons { get; set; } = new Button[5];
        private Dictionary <int, bool> profileExists = new Dictionary<int, bool>();

        DispatcherTimer ProfilePageTimer { get; set; } = new DispatcherTimer();

        CreateProfilePage profilePage { get; set; } = new CreateProfilePage();

        FarmProfilesPage farmProfilesPage { get; set; } = new FarmProfilesPage();   


        public ProfilePage()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            profileButtons[0] = ButtonProfile1;   
            profileButtons[1] = ButtonProfile2;   
            profileButtons[2] = ButtonProfile3;   
            profileButtons[3] = ButtonProfile4;   
            profileButtons[4] = ButtonProfile5;

            profileExists[0] = false;
            profileExists[1] = false;
            profileExists[2] = false;
            profileExists[3] = false;
            profileExists[4] = false;

            ProfilePageTimer.Tick += new EventHandler(ProfilePageTimerTick);
            ProfilePageTimer.IsEnabled = true;

        }
        public void LoadProfiles()
        {
            for (int i = 1; i < 6; i++)
            {
                string code = "profile" + i.ToString();
                if (ResourcesClass.ReadData(ResourcesClass.configFilePath, code) != "noValue")
                {
                    profileButtons[i - 1].Content = ResourcesClass.ReadData(ResourcesClass.configFilePath, code);
                    profileExists[i - 1] = true;
                }
            } 

        }

        private void ProfilePageTimerTick(object sender, EventArgs e)
        {
            if (profilePage.goBack == true) 
            { 
                ProfilePageFrame.Content = null; 
                profilePage.goBack = false; 
            };
        }

        private void ButtonProfile1Click(object sender, RoutedEventArgs e)
        {
            if (profileExists[0] == false) 
            {
                profilePage.profileNumber = 1;
                ProfilePageFrame.Content = profilePage;
            }
            else
            {
                //read profile data

                farmProfilesPage.SetPageHeader(ButtonProfile1);
                ProfilePageFrame.Content = farmProfilesPage;
            }
        }
        private void ButtonProfile2Click(object sender, RoutedEventArgs e)
        {
            if (profileExists[1] == false)
            {
                profilePage.profileNumber = 2;
                ProfilePageFrame.Content = profilePage;
            }
            else
            {
                //read profile data
                farmProfilesPage.SetPageHeader(ButtonProfile2);
                ProfilePageFrame.Content = farmProfilesPage;
            }
        }
        private void ButtonProfile3Click(object sender, RoutedEventArgs e)
        {
            if (profileExists[2] == false)
            {
                profilePage.profileNumber = 3;
                ProfilePageFrame.Content = profilePage;
            }
            else
            {
                //read profile data
                farmProfilesPage.SetPageHeader(ButtonProfile3);
                ProfilePageFrame.Content = farmProfilesPage;
            }
        }
        private void ButtonProfile4Click(object sender, RoutedEventArgs e)
        {
            if (profileExists[3] == false)
            {
                profilePage.profileNumber = 4;
                ProfilePageFrame.Content = profilePage;
            }
            else
            {
                //read profile data
                farmProfilesPage.SetPageHeader(ButtonProfile4);
                ProfilePageFrame.Content = farmProfilesPage;
            }
        }
        private void ButtonProfile5Click(object sender, RoutedEventArgs e)
        {
            if (profileExists[4] == false)
            {
                profilePage.profileNumber = 5;
                ProfilePageFrame.Content = profilePage;
            }
            else
            {
                //read profile data
                farmProfilesPage.SetPageHeader(ButtonProfile5);
                ProfilePageFrame.Content = farmProfilesPage;
            }
        }
    }
}
