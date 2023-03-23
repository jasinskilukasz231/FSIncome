using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public static class ResourcesClass
    {
        private static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static string configFilePath = projectPath + "/FSIncome.Core/config.txt";

    }
}
