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

namespace FSIncome.Windows.Pages.CreateFarmProfile
{
    public partial class AddAnimalsPage : Page, IAddData
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; }

        private AddAnimalsPage2 addAnimalsPage2;
        private DispatcherTimer pageTimer;

        public AddAnimalsPage()
        {
            InitializeComponent();
            addAnimalsPage2 = new AddAnimalsPage2();
            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addAnimalsPage2.goBack)
            {
                pageFrame.Content = null;
                addAnimalsPage2.goBack = false;
                SaveToFile();
                LoadData();
            }
        }
        public void SaveToFile()
        {
            var file = FileClass.ReadProfilesDataFile();
            string[] data = addAnimalsPage2.ReturnData();
            file.AddAnimals(profileNumber, farmProfileNumber, data[0], int.Parse(data[1]));
            FileClass.SaveProfilesDataFile(file);
        }
        public void LoadData()
        {
            var file = FileClass.ReadProfilesDataFile();
            dataGrid.ItemsSource = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].animalsTag.animals;
        }
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = addAnimalsPage2;
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(deleteTextBox.Text, out int result) == true)
            {
                var file = FileClass.ReadProfilesDataFile();
                if (result >= 0 && result <= file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].animalsTag.animals.Count - 1)
                {
                    file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].animalsTag.animals.RemoveAt(result);

                    //changing the ids 
                    int id = 0;
                    foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].animalsTag.animals)
                    {
                        i.id = id;
                        id++;
                    }

                    FileClass.SaveProfilesDataFile(file);
                    LoadData();
                }
                else MessageBox.Show("Enter proper value");
            }
            else MessageBox.Show("Enter proper value");
        }
    }
}
