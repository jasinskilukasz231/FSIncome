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
    }
}
