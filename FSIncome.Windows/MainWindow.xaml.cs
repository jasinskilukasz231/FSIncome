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
using FSIncome.Core;
using FSIncome.Windows.Pages;

namespace FSIncome.Windows
{
    public partial class MainWindow : Window
    {
        //objects
        SystemClass system { get; set; } = new SystemClass();

        public MainWindow()
        {
            system.InitComponents();
        }

        private void StartButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonStart.Visibility = Visibility.Collapsed;
            ButtonOptions.Visibility = Visibility.Collapsed;
            StartingPageFrame.Content = new ProfilePage();
        }
        
        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            ButtonStart.Visibility = Visibility.Collapsed;  
            ButtonOptions.Visibility = Visibility.Collapsed;
            StartingPageFrame.Content = new OptionsPage();
        }
    }

}
