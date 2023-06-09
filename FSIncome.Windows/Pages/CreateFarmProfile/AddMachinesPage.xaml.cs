﻿using System;
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
using FSIncome.Core.Files;

namespace FSIncome.Windows.Pages.CreateFarmProfile
{
    public partial class AddMachinesPage : Page, IAddData
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; }

        private AddMachinesPage2 addMachinesPage2;
        private DispatcherTimer pageTimer;

        public AddMachinesPage(Dictionary <string, string> appImages)
        {
            DataContext = appImages;
            InitializeComponent();
            addMachinesPage2 = new AddMachinesPage2();
            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage2.goBack)
            {
                pageFrame.Content = null;
                addMachinesPage2.goBack = false;
                SaveToFile();
                LoadData();
            }

        }
        public void SaveToFile()
        {
            var file = FileClass.ReadProfilesDataFile();
            string[] data = addMachinesPage2.ReturnData();
            file.AddMachine(profileNumber, farmProfileNumber, data[0], double.Parse(data[1]), data[2], data[3]);
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
            //simple popup
            if (pageFrame.Content != null) { pageFrame.Navigate(null); addMachinesPage2.ClearTextBoxes(); }
            else pageFrame.Navigate(addMachinesPage2);
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(deleteTextBox.Text, out int result) == true)
            {
                var file = FileClass.ReadProfilesDataFile();
                if (result >= 0 && result <= file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.Count - 1)
                {
                    file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.RemoveAt(result);

                    //changing the ids 
                    int id = 0;
                    foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines)
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
