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
using System.Xml.Serialization;

namespace FSIncome.Windows.Pages.MainPagePages
{
    public partial class HistoryPage : Page
    {
        //possibility to change this 
        //this is helpfull class for adding currency to amounts
        public class ListClass
        {
            public int id { get; set; }
            public string description { get; set; }
            public string amount { get; set; }
            public string category { get; set; }
        }
        public List<ListClass> transactionsItems { get; set; } = new List<ListClass>();
        //

        public HistoryPage()
        {
            InitializeComponent();
        }
        public void LoadData(int profileNumber, int farmProfileNumber)
        {
            transactionsItems.Clear();  
            var file = FileClass.ReadProfilesDataFile();
            var settings = FileClass.ReadSettingsFile();
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsTag.transactions)
            {
                ListClass transaction = new ListClass();
                transaction.id = i.id;
                transaction.description = i.description;
                transaction.amount = i.amount.ToString() + " " + settings.currency.ToUpper();
                transaction.category = i.category;
                transactionsItems.Add(transaction);
            }

            dataGrid.ItemsSource = transactionsItems;
        }
    }
}
