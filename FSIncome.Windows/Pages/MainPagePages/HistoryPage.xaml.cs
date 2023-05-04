using FSIncome.Core;
using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Transaction> transactionsItems = new ObservableCollection<Transaction>();

        public HistoryPage()
        {
            InitializeComponent();
            
        }
        public void LoadData(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            var settings = FileClass.ReadSettingsFile();
            transactionsItems.Clear();  

            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsTag.transactions)
            {
                Transaction transaction = new Transaction();
                transaction.Id = i.id;
                transaction.Description = i.description;
                transaction.Amount = i.amount.ToString() + " " + settings.currency.ToUpper();
                transaction.Category = i.category;
                transactionsItems.Add(transaction);
            }

            dataGrid.ItemsSource = transactionsItems;
        }
    }
}
