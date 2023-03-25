using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class SystemClass
    {
        //Options options { get; set; } = new Options(string currency, );

        //file property
        //profile property
        public string[] profiles { get; set; } = new string[5];

        //settings property
        public string currency { get; set; }
        public int seasonDays { get; set; }

        public void InitComponents()
        {
            currency = ResourcesClass.ReadData(ResourcesClass.configFilePath, "currency");
            seasonDays = int.Parse(ResourcesClass.ReadData(ResourcesClass.configFilePath, "seasondays"));

        }

        
    }
}
