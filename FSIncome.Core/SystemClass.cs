using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class SystemClass
    {
        //file property
        //settings property
        private SettingsFile settingsFile;
        private string currency { get; set; }
        private int seasonDays { get; set; }

        public void InitComponents()
        {
            //init settings
            settingsFile = FileClass.ReadSettingsFile();
            currency = settingsFile.currency;
            seasonDays = settingsFile.seasonDays;
        }

        
    }
}
