using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    //file structure
    //season property
    //market items

    [XmlRoot("System")]
    public class SystemFile
    {
        public void AddSeasonDataProfile(string name)
        {
            SeasonProfileItem seasonProfileItem = new SeasonProfileItem();
            seasonProfileItem.name = name;
            seasonsTag.seasonProfiles.Add(seasonProfileItem);   
        }

        [XmlElement("Seasons")]
        public SeasonsTag seasonsTag { get; set; } = new SeasonsTag();
        public BankData bankData { get; set; } = new BankData();
    }

    [XmlRoot("Seasons")]
    public class SeasonsTag
    {
        [XmlElement("Profile")]
        public List<SeasonProfileItem> seasonProfiles { get; set; } = new List<SeasonProfileItem>();
    }
    [XmlRoot("")]
    public class SeasonProfileItem
    {
        [XmlAttribute]
        public string name { get; set; }    

        public int seasonDay { get; set; } = 0;
        public int seasonName { get; set; } = 0;
        public int seasonStage { get; set; } = 0;
    }

    public class BankData
    {
        [XmlElement("Bank1")]
        public Bank1Item bank1Item = new Bank1Item();  
        [XmlElement("Bank2")]
        public Bank2Item bank2Item = new Bank2Item();  
        [XmlElement("Bank3")]
        public Bank3Item bank3Item = new Bank3Item();  
    }
    [XmlRoot("")]
    public class Bank1Item
    {
        public string bankName { get; set; } = "Bank1Name";
        public double bankMaxLoanAmount { get; set; } = 60000;
        public double singleLoanMaxAmount { get; set; } = 20000;
        //percentage
        public double loan1Cost { get; set; } = 3.6;
        public double loan2Cost { get; set; } = 7.9;
        public double loan3Cost { get; set; } = 15.3;
    }
    public class Bank2Item
    {
        public string bankName { get; set; } = "Bank2Name";
        public double bankMaxLoanAmount { get; set; } = 60000;
        public double singleLoanMaxAmount { get; set; } = 20000;
        //percentage
        public double loan1Cost { get; set; } = 8.9;
        public double loan2Cost { get; set; } = 8.9;
        public double loan3Cost { get; set; } = 8.9; //3rd loan 0% in system file "CheckLoanPossibility"
    }
    public class Bank3Item
    {
        public string bankName { get; set; } = "Bank3Name";
        public double bankMaxLoanAmount { get; set; } = 100000;
        public double singleLoanMaxAmount { get; set; } = 50000;
        //percentage
        public double loanCost { get; set; } = 6;
    }

}
