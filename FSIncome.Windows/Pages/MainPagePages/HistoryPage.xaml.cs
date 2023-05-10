using FSIncome.Core;
using FSIncome.Core.Files;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
        public ObservableCollection<TransationListItem> transactionsItems = new ObservableCollection<TransationListItem>();

        public HistoryPage()
        {
            InitializeComponent();
        }
        public void LoadData(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            var settings = FileClass.ReadSettingsFile();
            transactionsItems.Clear();

            //adding all transactions to one list
            List<TransationListItem> transationListItems = new List<TransationListItem>();
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsExpenditureTag.transactions)
            {
                transationListItems.Add(new TransationListItem(i.id, i.description, i.amount.ToString() + " " + settings.currency.ToUpper(), i.date, i.category));
            }
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].transactionsIncomeTag.transactions)
            {
                transationListItems.Add(new TransationListItem(i.id, i.description, i.amount.ToString() + " " + settings.currency.ToUpper(), i.date, i.category));
            }

            //sorting the list
            transationListItems.Sort((x, y) => DateTime.Compare(x.date, y.date));
            transationListItems.Reverse();

            //adding to the final list and modifying the id
            for (int i = 0; i < transationListItems.Count; i++)
            {
                transationListItems[i].id = i;
                transactionsItems.Add(transationListItems[i]);
            }

            dataGrid.ItemsSource = transactionsItems;
        }
    }
}
