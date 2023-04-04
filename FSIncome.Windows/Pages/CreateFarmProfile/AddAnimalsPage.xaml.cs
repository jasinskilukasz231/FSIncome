using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Core.Interfaces;
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
        AddAnimalsPage2 addAnimalsPage2 = new AddAnimalsPage2();
        DispatcherTimer pageTimer = new DispatcherTimer();

        //data lists
        public List<string> animalTypeList { get; set; } = new List<string>();
        public List<int> amountList { get; set; } = new List<int>();
        //
        public bool goBack { get; set; } = false;
        public AddAnimalsPage()
        {
            InitializeComponent();

            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addAnimalsPage2.goBack)
            {
                PageFrame.Content = null;
                addAnimalsPage2.goBack = false;
                CreateListItem(addAnimalsPage2.ReturnData());
            }
        }
        private void CreateListItem(string[] dataLine)
        {
            Label label1 = new Label();
            Label label2 = new Label();

            LpListBox.Items.Add(LpListBox.Items.Count);

            label1.Content = dataLine[0];
            animalTypeList.Add(dataLine[0]);
            AnimalTypeListBox.Items.Add(label1);

            label2.Content = dataLine[1];
            amountList.Add(int.Parse(dataLine[1]));
            AmountListBox.Items.Add(label2);
        }
        public void SaveToFile()
        {
            //creating the object and reading from file
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //adding data
            for (int i = 0; i < animalTypeList.Count; i++)
            {
                profilesDataFile.AddAnimals(this.profileNumber - 1, this.farmProfileNumber - 1, animalTypeList[i], amountList[i]);
            }
            //saving changes to file
            FileClass.SaveProfilesDataFile(profilesDataFile);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = addAnimalsPage2;
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FinishButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
