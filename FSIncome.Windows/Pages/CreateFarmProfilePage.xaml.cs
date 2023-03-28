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
using FSIncome.Core.Interfaces;
using FSIncome.Windows.Pages.CreateFarmProfile;

namespace FSIncome.Windows.Pages
{
    /// <summary>
    /// Interaction logic for CreateFarmProfilePage.xaml
    /// </summary>
    public partial class CreateFarmProfilePage : Page
    {
        //interface here
        IAddData addMachinesPage = new AddMachinesPage();
        //IAddData addMachines = new AddAnimalsPage();
        //IAddData addMachines = new AddFieldsPage();

        public int profileNumber { get; set; }
        public bool goBack { get; set; } = false;

        DispatcherTimer pageTimer = new DispatcherTimer();
        public CreateFarmProfilePage()
        {
            InitializeComponent();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;

            CurrencyLabel.Content = ResourcesClass.ReadData(ResourcesClass.configFilePath, "currency");
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage.goBack)
            {
                CreateFarmProfilePageFrame.Content = null;
            }

        }
        private void MachinesButton_Click(object sender, RoutedEventArgs e)
        {
            CreateFarmProfilePageFrame.Content = addMachinesPage;
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FieldsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;  
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
