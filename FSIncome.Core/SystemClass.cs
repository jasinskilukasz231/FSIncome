using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class SystemClass
    {
        Options options { get; set; } = new Options();

        public void InitComponents()
        {
            options.ReadConfigs(ResourcesClass.configFilePath);


        }

    }
}
