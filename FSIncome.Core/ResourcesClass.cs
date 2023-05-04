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
            AcceptedNormal,
            NotAcceptedHypothetical,
            NotAcceptedNormal,
            AcceptedField,
            AcceptedFertilizer,
            AcceptedMachine,
            NotAcceptedField,
            NotAcceptedFertilizer,
            amountNotEnoughtFertilizerDeny,
            NotAcceptedMachine,
            NotEnoughtMoneyField, //not enought money to pay the self deposit in hypo loan
            FarmTooSmall,
        }
        public enum HypotheticalLoanTypes
        {
            machine,
            field,
            fertilizer
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
        //settings
        public enum Currency
        {
            PLN,
            EUR,
            GBP
        }
        public enum LandUnits
        {
            Ha
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

        
    }
}
