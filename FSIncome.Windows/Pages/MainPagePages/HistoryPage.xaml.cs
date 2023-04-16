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

namespace FSIncome.Windows.Pages.MainPagePages
{
    public partial class HistoryPage : Page
    {
        public List<string> amounts { get; set; }=new List<string>();
        public HistoryPage()
        {
            InitializeComponent();
        }
        public void LoadData(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            var settings = FileClass.ReadSettingsFile();
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsTag.transactions)
            {
                amounts.Add(i.amount.ToString() + " " + settings.currency.ToUpper());
            }

            dataGrid.ItemsSource = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsTag.transactions;
            //dataGrid.ItemsSource = amounts;
        }
    }
}
