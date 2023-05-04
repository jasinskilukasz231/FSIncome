using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    //creating items of transactions
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Amount { get; set; }
        public string Category { get; set; }
    }
}
