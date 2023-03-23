using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FSIncome.Core
{
    public class Options
    {
        //with default values
        public string currency { get; set; }
        public int seasonDays { get; set; }

        public void ReadConfigs(string filePath)
        {
            string file = File.ReadAllText(filePath);

            if(file.Contains("currency")==true)
            {
                currency = "currency";
            }


        }



    }
}
