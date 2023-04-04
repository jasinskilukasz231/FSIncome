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
    public partial class AddFieldsPage : Page, IAddData
    {
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        AddFieldsPage2 addFieldsPage2 = new AddFieldsPage2();
        DispatcherTimer pageTimer = new DispatcherTimer();

        //data lists
        List<int> fieldNumberList = new List<int>();
        List<double> sizeList = new List<double>();
        List<string> cropTypeList = new List<string>(); 
        List<string> groundTypeList = new List<string>();   
        List<double> priceList = new List<double>();    
        //
        public bool goBack { get; set; } = false;

        public AddFieldsPage()
        {
            InitializeComponent();

            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addFieldsPage2.goBack)
            {
                PageFrame.Content = null;
                addFieldsPage2.goBack = false;
                CreateListItem(addFieldsPage2.ReturnData());
            }
        }
        private void CreateListItem(string[] dataLine)
        {
            Label label = new Label();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();

            LpListBox.Items.Add(LpListBox.Items.Count);

            label.Content = dataLine[0];
            fieldNumberList.Add(int.Parse(dataLine[0]));
            NumberListBox.Items.Add(label);

            label1.Content = dataLine[1];
            sizeList.Add(double.Parse(dataLine[1]));
            SizeListBox.Items.Add(label1);

            label2.Content = dataLine[2];
            cropTypeList.Add(dataLine[2]);
            CropsListBox.Items.Add(label2);

            label3.Content = dataLine[3];
            groundTypeList.Add(dataLine[3]);
            GroundTypeListBox.Items.Add(label3);

            label4.Content = dataLine[4];
            priceList.Add(double.Parse(dataLine[4]));
            PriceListBox.Items.Add(label4);
        }
        public void SaveToFile()
        {
            //creating the object and reading from file
            ProfilesDataFile profilesDataFile = FileClass.ReadProfilesDataFile();
            //adding data
            for (int i = 0; i < fieldNumberList.Count; i++)
            {
                profilesDataFile.AddField(this.profileNumber - 1, this.farmProfileNumber - 1, fieldNumberList[i], sizeList[i], cropTypeList[i], groundTypeList[i], priceList[i]);
            }
            //saving changes to file
            FileClass.SaveProfilesDataFile(profilesDataFile);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = addFieldsPage2;
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
