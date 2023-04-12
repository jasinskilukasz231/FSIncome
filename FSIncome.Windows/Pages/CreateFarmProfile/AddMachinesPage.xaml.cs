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
using FSIncome.Core.Files;
using FSIncome.Core.Interfaces;

namespace FSIncome.Windows.Pages.CreateFarmProfile
{
    public partial class AddMachinesPage : Page, IAddData
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        AddMachinesPage2 addMachinesPage2 = new AddMachinesPage2();
        DispatcherTimer pageTimer = new DispatcherTimer();
        //data lists
        List<string> nameList = new List<string>(); 
        List<double> priceList = new List<double>();    
        List<string> brandList = new List<string>();
        List<string> categoryList= new List<string>();  
        //
        public bool goBack { get; set; } = false;

        public AddMachinesPage()
        {
            InitializeComponent();

            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage2.goBack)
            {
                PageFrame.Content = null;
                addMachinesPage2.goBack = false;
                CreateListItem(addMachinesPage2.ReturnData());
            }
        }
        private void CreateListItem(string[] dataLine)
        {
            Label label = new Label();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();

            LpListBox.Items.Add(LpListBox.Items.Count);

            label.Content = dataLine[0];
            nameList.Add(dataLine[0]);
            NameListBox.Items.Add(label);

            label1.Content = dataLine[1];
            priceList.Add(double.Parse(dataLine[1]));
            PriceListBox.Items.Add(label1);

            label2.Content = dataLine[2];
            brandList.Add(dataLine[2]);
            BrandListBox.Items.Add(label2);

            label3.Content = dataLine[3];
            categoryList.Add(dataLine[3]);
            CategoryListBox.Items.Add(label3);

        }
        public void SaveToFile()
        {
            //creating the object and reading from file
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            //adding data
            for (int i = 0; i < nameList.Count; i++)
            {
                profilesDataFile.AddMachine(this.profileNumber, this.farmProfileNumber, nameList[i], priceList[i], brandList[i], categoryList[i]);
            }
            //saving changes to file
            FileClass.SaveProfilesDataFile(profilesDataFile);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = addMachinesPage2;
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
