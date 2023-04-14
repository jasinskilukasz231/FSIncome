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
    public partial class AddFieldsPage : Page, IAddData
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; }

        AddFieldsPage2 addFieldsPage2;
        DispatcherTimer pageTimer;

        public AddFieldsPage()
        {
            InitializeComponent();
            addFieldsPage2 = new AddFieldsPage2();
            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addFieldsPage2.goBack)
            {
                pageFrame.Content = null;
                addFieldsPage2.goBack = false;
                SaveToFile();
                LoadData();
            }
        }
        public void SaveToFile()
        {
            var file = FileClass.ReadProfilesDataFile();
            string[] data = addFieldsPage2.ReturnData();
            file.AddField(profileNumber, farmProfileNumber, int.Parse(data[0]), double.Parse(data[1]), data[2], data[3], double.Parse(data[4]));     
            FileClass.SaveProfilesDataFile(file);
        }
        public void LoadData()
        {
            var file = FileClass.ReadProfilesDataFile();
            dataGrid.ItemsSource = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].fieldsTag.fields;
        }
        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            pageFrame.Content = addFieldsPage2;
        }
    }
}
