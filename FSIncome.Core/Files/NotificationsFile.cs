using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    public class NotificationsFile
    {
        [XmlElement("Item")]
        public List<NotificationItem> notifications { get; set; } = new List<NotificationItem>();   

        public void AddNotification(int profileNumber, int farmProfileNumber, string notifiType)
        {
            var item = new NotificationItem();
            item.profileNumber = profileNumber;
            item.farmProfileNumber = farmProfileNumber;
            item.notificationType = notifiType;
            notifications.Add(item);   
        }
    }

    [XmlRoot("")]
    public class NotificationItem
    {
        [XmlAttribute("profileNumber")]
        public int profileNumber { get; set; }
        [XmlAttribute("farmProfileNumber")]
        public int farmProfileNumber { get; set; }
        [XmlAttribute("type")]
        public string notificationType { get; set; }
    }
}


