using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class Notifications
    {
        public Notifications() 
        {
            
        }  

        public void CheckLoansToPay(int profileNumber, int farmProfileNumber)
        {
            //checking if user has loans and adding the notification
            var file = FileClass.ReadProfilesDataFile();
            if (file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.standardLoanTag.loanItems.Count != 0 ||
               file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.hypotheticalLoanTag.loanItems.Count != 0)
            {
                var notifiFile = FileClass.ReadNotificationsFile();
                notifiFile.AddNotification(profileNumber, farmProfileNumber, ResourcesClass.Notifications.payTheLoan.ToString());
                FileClass.SaveNotificationsFile(notifiFile);
            }
        }
        public bool CheckLoanNotifications(int profileNr, int farmProfileNr = -1)
        {
            var file = FileClass.ReadNotificationsFile();
            bool found = false;

            foreach (var i in file.notifications)
            {
                if (i.profileNumber == profileNr && i.farmProfileNumber == farmProfileNr &&
                    i.notificationType == ResourcesClass.Notifications.payTheLoan.ToString())
                {
                    found = true;
                }
            }

            return found;
        }
    }
}
