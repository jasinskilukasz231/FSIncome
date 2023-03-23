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
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private Button[] profileButtons { get; set; } = new Button[5];
        private string[] profileNames { get; set; } = new string[5];

        public ProfilePage(string[] profilesName)
        {
            InitializeComponent();
            profileNames = profilesName;

            Init();
        }
        private void Init()
        {
            profileButtons[0] = ButtonProfile1;   
            profileButtons[1] = ButtonProfile2;   
            profileButtons[2] = ButtonProfile3;   
            profileButtons[3] = ButtonProfile4;   
            profileButtons[4] = ButtonProfile5;

            //setting profiles
            for (int i = 0; i < 5; i++)
            {
                if (profileNames[i] != null) profileButtons[i].Content = profileNames[i];
            }
        }

        private void ButtonProfile1Click(object sender, RoutedEventArgs e)
        {
            if (profileNames[0]!=null)
            {
                ProfilePageFrame.Content = new CreateProfilePage(1);
            }
            else
            {
                //read profile data
                //show profile
            }
        }
        private void ButtonProfile2Click(object sender, RoutedEventArgs e)
        {
            if (profileNames[1] != null)
            {
                ProfilePageFrame.Content = new CreateProfilePage(2);
            }
            else
            {
                //read profile data
            }
        }
        private void ButtonProfile3Click(object sender, RoutedEventArgs e)
        {
            if (profileNames[2] != null)
            {
                ProfilePageFrame.Content = new CreateProfilePage(3);
            }
            else
            {
                //read profile data
            }
        }
        private void ButtonProfile4Click(object sender, RoutedEventArgs e)
        {
            if (profileNames[3] != null)
            {
                ProfilePageFrame.Content = new CreateProfilePage(4);
            }
            else
            {
                //read profile data
            }
        }
        private void ButtonProfile5Click(object sender, RoutedEventArgs e)
        {
            if (profileNames[4] != null)
            {
                ProfilePageFrame.Content = new CreateProfilePage(5);
            }
            else
            {
                //read profile data
            }
        }
    }
}
