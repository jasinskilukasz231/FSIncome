using FSIncome.Core.Files;
using FSIncome.Windows.Pages.CreateFarmProfile;
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

namespace FSIncome.Windows.Pages.MainPagePages
{
    public partial class MachinesMainPage : Page
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; } = false;

        private AddMachinesMainPage addMachinesMainPage;
        private DispatcherTimer pageTimer;

        public MachinesMainPage()
        {
            InitializeComponent();
            addMachinesMainPage = new AddMachinesMainPage();
            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesMainPage.goBack)
            {
                pageFrame.Content = null;
                addMachinesMainPage.goBack = false;
                SaveToFile();
                LoadData();
            }

        }
        public void SaveToFile()
        {
            var file = FileClass.ReadProfilesDataFile();
            string[] data = addMachinesMainPage.ReturnData();
            file.AddMachine(profileNumber, farmProfileNumber, data[0], double.Parse(data[1]), data[2], data[3]);

            //updating total amounts in the file
            double totalMachineSize = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice;
            file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice = totalMachineSize + double.Parse(data[1]);
            FileClass.SaveProfilesDataFile(file);
        }
        public void LoadData()
        {
            var file = FileClass.ReadProfilesDataFile();
            dataGrid.ItemsSource = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines;
        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = addMachinesMainPage;
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(deleteTextBox.Text, out int result) == true)
            {
                var file = FileClass.ReadProfilesDataFile();
                if (result >= 0 && result <= file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.Count - 1)
                {
                    //changing the ids 
                    int id = 0;
                    foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines)
                    {
                        i.id = id;
                        id++;
                    }

                    //updating total amounts in the file
                    double totalMachineSize = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice;
                    double machinePrice = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines[result].price;

                    file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice = totalMachineSize -
                        machinePrice;

                    file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.RemoveAt(result);

                    FileClass.SaveProfilesDataFile(file);
                    LoadData();
                }
                else MessageBox.Show("Enter proper value");
            }
            else MessageBox.Show("Enter proper value");
        }
    }
}
