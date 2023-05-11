using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Core.Loans;
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

namespace FSIncome.Windows.Pages.MainPagePages.MoneyPage
{
    public partial class PayLoanPage : Page
    {
        public bool goBack { get; set; }
        public bool doActions { get; set; }
        private double totalInstallment { get; set; }

        public PayLoanPage()
        {
            InitializeComponent();
        }

        public void SetLoansLabel(int profileNumber, int farmProfileNumber)
        {
            var notificationFile = FileClass.ReadNotificationsFile();
            bool notificationFound = false;
            for (int i = 0; i < notificationFile.notifications.Count; i++)
            {
                if (notificationFile.notifications[i].profileNumber == profileNumber &&
                    notificationFile.notifications[i].farmProfileNumber == farmProfileNumber &&
                    notificationFile.notifications[i].notificationType == ResourcesClass.Notifications.payTheLoan.ToString())
                {
                    notificationFound = true;
                }
            }
            if(notificationFound==false)
            {
                loanNameLabel.Text = "No loans to pay";
                totalAmountLabel.Text = "0";
                doActions = false;
            }
            else
            {
                loanNameLabel.Text = "";

                var file = FileClass.ReadProfilesDataFile();
                var settingsFIle = FileClass.ReadSettingsFile();

                List<string> loans = new List<string>();

                totalInstallment = 0;

                foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.standardLoanTag.loanItems)
                {
                    loans.Add(i.loanType.ToString() + ", Installment: " + i.loanInstallment);
                    totalInstallment += i.loanInstallment;
                }
                foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.hypotheticalLoanTag.loanItems)
                {
                    loans.Add(i.loanType.ToString() + ", Installment: " + i.loanInstallment);
                    totalInstallment += i.loanInstallment;
                }

                foreach (var i in loans)
                {
                    loanNameLabel.Text += i + settingsFIle.currency.ToUpper() + "\n";
                }

                totalAmountLabel.Text = "Amount to pay: " + totalInstallment + settingsFIle.currency.ToUpper();

                doActions = true;
            }
            
        }
        public void SubstractMoney(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadProfilesDataFile();
            if (file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount >= totalInstallment)
            {
                double bankAcc = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount;
                file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount = bankAcc - totalInstallment;

                PayLoans(profileNumber, farmProfileNumber, file);

                FileClass.SaveProfilesDataFile(file);

                DeleteNotification(profileNumber, farmProfileNumber);
            }
            else MessageBox.Show("You dont have enought money to pay");
        }
        private void PayLoans(int profileNumber, int farmProfileNumber, ProfilesDataFile file)
        {
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.standardLoanTag.loanItems)
            {
                i.loanPayd += i.loanInstallment;
            }
            foreach (var i in file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.hypotheticalLoanTag.loanItems)
            {
                i.loanPayd += i.loanInstallment;
            }
        }
        private void DeleteNotification(int profileNumber, int farmProfileNumber)
        {
            var file = FileClass.ReadNotificationsFile();
            for (int i = 0; i < file.notifications.Count; i++)
            {
                if (file.notifications[i].profileNumber==profileNumber &&
                    file.notifications[i].farmProfileNumber==farmProfileNumber&&
                    file.notifications[i].notificationType==ResourcesClass.Notifications.payTheLoan.ToString())
                {
                    file.notifications.RemoveAt(i);
                }
            }
            FileClass.SaveNotificationsFile(file);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
        
    }
}
