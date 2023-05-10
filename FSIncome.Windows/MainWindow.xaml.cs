using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using FSIncome.Windows.Pages;

namespace FSIncome.Windows
{
    public partial class MainWindow : Window
    {
        private Init init;

        private AppImages appImages;

        private ProfilePage profilePage;
        private OptionsPage optionsPage;
        private bool ProfileClassCreated { get; set; }

        private DispatcherTimer PageTimer;

        public MainWindow()
        {
            init = new Init();

            //load images
            appImages = new AppImages();
            DataContext = appImages.teksturesNames;

            optionsPage = new OptionsPage(appImages.teksturesNames);
            PageTimer = new DispatcherTimer();
            PageTimer.Tick += new EventHandler(PageTimer_Tick);
            PageTimer.IsEnabled = true;

            //overloading files after code change
            //var file = new NotificationsFile();
            //FileClass.SaveNotificationsFile(file);
            //var file = new InitFile();
            //FileClass.SaveInitFile(file);
            //var file = new SystemFile();
            //FileClass.SaveSystemFile(file);
            //var settingsFile = new SettingsFile();
            //FileClass.SaveSettingsFile(settingsFile);

        }
        private void PageTimer_Tick(object sender, EventArgs e)
        {
            if (optionsPage.goBack)
            {
                optionsPage.goBack = false;
                PageFrame.Navigate(null);
            }
            if (ProfileClassCreated)
            {
                if (profilePage.goBack)
                {
                    profilePage.goBack = false;
                    PageFrame.Navigate(null);
                }
            }
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            profilePage = new ProfilePage(appImages.teksturesNames);
            ProfileClassCreated = true;
            PageFrame.Navigate(profilePage);
            profilePage.LoadProfiles();
        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            optionsPage.SetValues();
            optionsPage.SetStartingSettings();
            PageFrame.Navigate(optionsPage);
        }
    }

}
