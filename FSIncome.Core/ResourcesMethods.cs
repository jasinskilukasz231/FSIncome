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

        public static string ChangeSeperator(string number)
        {
            //chaning string to double
            //changing double number from 20.23123123 to 20,23
            var result = "";
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '.' || number[i] == ',') result += ',';
                else result += number[i];
            }
            return result;
        }
        public static string ChangeSeperatorToDot(string number)
        {
            //chaning string to double
            //changing double number from 20.23123123 to 20,23
            var result = "";
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == '.' || number[i] == ',') result += '.';
                else result += number[i];
            }
            return result;
        }
        public static string SetTwoDecimalNumbers(string number)
        {
            var endVal = "";
            int decNumbers = 0;
            bool countDecNumb = false;
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == ',' || number[i] == ',')
                {
                    countDecNumb = true;
                    endVal += '.';
                }
                else
                {
                    if (countDecNumb) decNumbers++;
                    endVal += number[i];
                    if (decNumbers == 2) break;
                }
            }
            return endVal;
        }
    }
}
