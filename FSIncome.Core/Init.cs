using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class Init
    {
        //actions before starting the app
        public Init()
        {
            //deleting not used images
            var iniFile = FileClass.ReadInitFile();
            foreach (var i in iniFile.deleteFile)
            {
                if (File.Exists(i.name)) File.Delete(i.name);
            }

            //deleting tags from init file
            iniFile.deleteFile.Clear();
            FileClass.SaveInitFile(iniFile);
        }
    }
}
