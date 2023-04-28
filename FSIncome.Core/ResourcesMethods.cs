using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public static class ResourcesMethods
    {
        public static string ClearString(string header)
        {
            //clearing the string from "123 PLN" to "123"
            string endValue = "";
            foreach (var i in header)
            {
                if (i == ' ') break;
                else endValue += i;
            }
            return endValue;
        }
    }
}
