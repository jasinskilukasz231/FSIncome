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

namespace FSIncome.Windows.Pages.CreateFarmProfile
{
    public partial class AddMachinesPage : Page, IAddData
    {
        AddMachinesPage2 addMachinesPage2 = new AddMachinesPage2();
        DispatcherTimer pageTimer = new DispatcherTimer();
        public List<string> dataList { get; set; } = new List<string>();
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
                CreateListItem(addMachinesPage2.ReturnData());
            }
        }
        private void CreateListItem(string[] dataLine)
        {
            string labelText = MachinesList.Items.Count.ToString() + ". " + dataLine[0] + "     " +
                dataLine[1] + "     " + dataLine[2] + "     " + dataLine[3] + "     ";

            Label label = new Label();
            label.Content = labelText;
            MachinesList.Items.Add(label);
        }
        public void SaveToFile(List<string> dataList)
        {
            foreach (var i in dataList) ResourcesClass.SaveToConfigFile(ResourcesClass.configFilePath, "#profile1Machines", i);
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
