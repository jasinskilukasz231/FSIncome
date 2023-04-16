using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public static class ResourcesClass
    {
        public enum LoanCheckMessageCode
        {
            Accepted,
            NotAccepted
        }
        public enum BankType
        {
            Bank1,
            Bank2,
            Bank3 
        }
        public enum LoanType
        {
            Standard,
            Hypothetical
        }
        public enum FarmSize
        {
            Small,
            Medium,
            Large
        }
        public enum Season
        {
            Spring,
            Summer,
            Autumn,
            Winter
        }
        public enum SeasonStage
        {
            Early,
            Mid,
            Late
        }
        public enum TransactionsCategoriesIncome
        {
            SELLING_CROPS,
            SELLING_MACHINES,
            SELLING_FIELDS,
            ANIMALS_INCOME,
            SERVICES,
            PASSIVE_INCOME,
            OTHERS
        }
        public enum TransactionsCategoriesExpenditure
        {
            FARM_UTILITIES,
            SERVICES,
            ANIMALS_OUTGOES,
            FUEL,
            BUYING_MACHINES,
            BUYING_FIELDS,
            OTHERS
        }
        public static string SetCategoryIncomeString(TransactionsCategoriesIncome categoryName)
        {
            //swaping _ to space sign
            string endValue = "";
            for (int i = 0; i < categoryName.ToString().Length; i++)
            {
                if (categoryName.ToString()[i] == '_') endValue += " ";
                else endValue += categoryName.ToString()[i];   
            }
            return endValue;
        }
        public static string SetCategoryExpenditureString(TransactionsCategoriesExpenditure categoryName)
        {
            //swaping _ to space sign
            string endValue = "";
            for (int i = 0; i < categoryName.ToString().Length; i++)
            {
                if (categoryName.ToString()[i] == '_') endValue += " ";
                else endValue += categoryName.ToString()[i];
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
