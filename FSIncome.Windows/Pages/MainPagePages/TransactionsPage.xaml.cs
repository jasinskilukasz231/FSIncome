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

namespace FSIncome.Windows.Pages.MainPagePages
{
    public partial class TransactionsPage : Page
    {
        public bool goBack { get; set; }
        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public TransactionsPage()
        {
            InitializeComponent();
        }

        public void ClearControls()
        {
            descriptionTBExp.Text = string.Empty;
            descriptionTBInc.Text = string.Empty;
            amountTBExp.Text = string.Empty;
            amountTBInc.Text = string.Empty;
            categoryExpanderExp.Header = "CATEGORY";
            categoryExpanderInc.Header = "CATEGORY";
        }
        private void sellingCropsCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.SELLING_CROPS);
            categoryExpanderInc.IsExpanded = false;
        }

        private void sellingMachinesCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.SELLING_MACHINES);
            categoryExpanderInc.IsExpanded = false;
        }

        private void sellingFieldsCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.SELLING_FIELDS);
            categoryExpanderInc.IsExpanded = false;
        }

        private void animalsIncCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.ANIMALS_INCOME);
            categoryExpanderInc.IsExpanded = false;
        }

        private void servicesCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.SERVICES);
            categoryExpanderInc.IsExpanded = false;
        }

        private void passiveIncCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderInc.Header = ResourcesClass.SetCategoryIncomeString(ResourcesClass.TransactionsCategoriesIncome.PASSIVE_INCOME);
            categoryExpanderInc.IsExpanded = false;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(IncomeTab.IsSelected)
            {
                if (descriptionTBInc.Text.Length != 0 && amountTBInc.Text.Length != 0)
                {
                    if (categoryExpanderInc.Header.ToString() != "CATEGORY")
                    {
                        var file = FileClass.ReadProfilesDataFile();
                        if (double.TryParse(ResourcesMethods.ChangeSeperator(amountTBInc.Text), out double result))
                        {
                            if (result > 0)
                            {
                                file.AddTransactionItem(profileNumber, farmProfileNumber, descriptionTBInc.Text, result, categoryExpanderInc.Header.ToString());
                                file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount += result;
                                FileClass.SaveProfilesDataFile(file);
                                goBack = true;
                            }
                            else MessageBox.Show("inappropriate amount");
                        }
                        else MessageBox.Show("inappropriate amount");

                    }
                    else MessageBox.Show("Choose category");
                }
                else MessageBox.Show("Enter data");
            }
            if(ExpenditureTab.IsSelected)
            {
                if (descriptionTBExp.Text.Length != 0 && amountTBExp.Text.Length != 0)
                {
                    if (categoryExpanderExp.Header.ToString() != "CATEGORY")
                    {
                        var file = FileClass.ReadProfilesDataFile();
                        if (double.TryParse(ResourcesMethods.ChangeSeperator(amountTBExp.Text), out double result))
                        {
                            if (result > 0)
                            {
                                double bankAcc = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount;
                                if (result <= bankAcc)
                                {
                                    file.AddTransactionItem(profileNumber, farmProfileNumber, descriptionTBExp.Text, -result, categoryExpanderExp.Header.ToString());
                                    file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount -= result;
                                    FileClass.SaveProfilesDataFile(file);
                                    goBack = true;
                                }
                                else MessageBox.Show("You dont have enought money");
                            }
                            else MessageBox.Show("inappropriate amount");
                        }
                        else MessageBox.Show("inappropriate amount");

                    }
                    else MessageBox.Show("Choose category");
                }
                else MessageBox.Show("Enter data");
            }
            
        }

        private void farmUtiCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.FARM_UTILITIES);
            categoryExpanderExp.IsExpanded = false;
        }

        private void servicesExpCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.SERVICES);
            categoryExpanderExp.IsExpanded = false;
        }

        private void animalsOutCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.ANIMALS_OUTGOES);
            categoryExpanderExp.IsExpanded = false;
        }

        private void fuelCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.FUEL);
            categoryExpanderExp.IsExpanded = false;
        }

        private void buyingMachinesCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.BUYING_MACHINES);
            categoryExpanderExp.IsExpanded = false;
        }

        private void buyingFieldsCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.BUYING_FIELDS);
            categoryExpanderExp.IsExpanded = false;
        }

        private void otherExpCB_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            categoryExpanderExp.Header = ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.OTHERS);
            categoryExpanderExp.IsExpanded = false;
        }
    }
}
