using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSIncome.Core
{
    public class TransationListItem
    {
        public int id { get; set; }
        public string description { get; set; }
        public string amount { get; set; }
        public DateTime date { get; set; }
        public string category { get; set; }

        public TransationListItem(int id, string description, string amount, DateTime date, string category)
        {
            this.id= id;
            this.description= description;
            this.amount= amount;
            this.date = date;
            this.category = category;
        }
    }
}
