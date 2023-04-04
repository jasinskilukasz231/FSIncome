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
using FSIncome.Windows.Pages;

namespace FSIncome.Windows
{
    public partial class MainWindow : Window
    {
        //objects
        //private SystemClass system; 
        private ProfilePage profilePage;
        private OptionsPage optionsPage;

        private DispatcherTimer PageTimer;

        public MainWindow()
        {
            //system = new SystemClass();
            //system.InitComponents();
            profilePage = new ProfilePage();
            optionsPage = new OptionsPage();
            PageTimer = new DispatcherTimer();
            PageTimer.Tick += new EventHandler(PageTimer_Tick);
            PageTimer.IsEnabled = true;
        }
        private void PageTimer_Tick(object sender, EventArgs e)
        {
            if(optionsPage.goBack)
            {
                optionsPage.goBack = false;
                PageFrame.Content = null;
            }
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = profilePage;
            profilePage.LoadProfiles();
        }
        
        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            optionsPage.SetValues();
            PageFrame.Content = optionsPage;
        }
    }

}
