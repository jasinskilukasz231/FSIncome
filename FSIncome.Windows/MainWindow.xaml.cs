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
        SystemClass system { get; set; } = new SystemClass();
        ProfilePage profilePage { get; set; }
        OptionsPage optionsPage { get; set; }

        DispatcherTimer appWorking { get; set; }

        public MainWindow()
        {

            system.InitComponents();
            profilePage = new ProfilePage(system.profiles);
            optionsPage = new OptionsPage();
            appWorking = new DispatcherTimer();
            appWorking.Tick += new EventHandler(AppWorking);
            appWorking.IsEnabled = true;
        }


        public void SetVisible()
        {
            StartingPageFrame.Content = null;
            ButtonStart.Visibility = Visibility.Visible;
            ButtonOptions.Visibility = Visibility.Visible;
        }
        private void AppWorking(object sender, EventArgs e)
        {
            if(optionsPage.goBack == true)
            {
                SetVisible();
                optionsPage.goBack = false;
            }
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonStart.Visibility = Visibility.Collapsed;
            ButtonOptions.Visibility = Visibility.Collapsed;
            StartingPageFrame.Content = profilePage;
        }
        
        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonStart.Visibility = Visibility.Collapsed;  
            ButtonOptions.Visibility = Visibility.Collapsed;
            StartingPageFrame.Content = optionsPage;
        }
    }

}
