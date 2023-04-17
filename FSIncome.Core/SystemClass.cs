using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static FSIncome.Core.ResourcesClass;

namespace FSIncome.Core
{
    public class SystemClass
    {
        //settings property
        private string currency { get; set; }
        public string Currency
        {
            get { return currency; }
            set { currency = value; }
        }
        private int seasonDays { get; set; }
        public int SeasonDays
        {
            get { return seasonDays; }
        }

        //callendar
        private int day { get; set; } = 0;
        public int Day
        {
            get { return day; }
            set { day = value; }
        }
        private int currentSeason { get; set; }
        private int currentSeasonStage { get; set; }
        public int CurrentSeason
        {
            get { return currentSeason; }
            set { currentSeason = value; }
        }
        public int CurrentSeasonStage
        {
            get { return currentSeasonStage; }
            set { currentSeasonStage = value; }
        }
        //loans
        /*loan rules:
             *SMALL FARM
             *machines value < 100k && land < 20 ha
             *
             *MEDIUM FARM
             *100k < machines value < 250k && 20ha < land < 50ha
             *
             *BIG FARM
             *machines value > 250k && land > 50ha
             *
             * standard loan:
             * user can take more than 1 loan but in the same bank, (possible to develop in the future)
             * possibility to repay the loan faster
             * interest rate is determined by certain bank:
             * 
             * Bank 1 1st low 2nd med 3rd high but for everyone 3rd
             * In this facility the interest rate is determined by the loan amount loaned
             * max loan size 60k or 3 loans
             * 
             * Bank 2 const rate but a little bit high, 3rd 0% for medium and high farms
             * max loan size 60k
             * 
             * Bank 3 rate inversely proportional to the farm size, low for big farms, high for small farms
             * this bank remembers old customers and gives discount for future loans
             * max loan size 100k,
             * 
             * 12 months in the year its seasonDays variable * 4 in game days
             * 3*4 = 12 
             * 24 months loan its for 2 years in game also
             * loan installment is charged every one season stage
             * 
             * hypothethical loans for the biggests
             * loan types:
             * for land - loan for 90% of the land, 10% farmer pays by himself
             * for machines - new and less than 20 years old machines 
             * for fertilizers - over than 2tones of the fertilizer 
             */
        private double machinesValue { get; set; }
        private double landSize { get; set; }
        private double landSizeLow { get; set; } //from the settings 
        private double landSizeBig { get; set; } //from the settings 
        private double customerLoansAmount { get; set; }
        private double machinesValueLow { get; set; } //from the settings
        private double machinesValueBig { get; set; } //from the settings
        private string farmSize { get; set; }
        private int loanNumber { get; set; } //
        public double amountOfInterest { get; set; }
        public string endingCode { get; set; }

        //variables
        int stageIndex = 1; //beg 1 for skipping 0 
        List<int> stagePoints = new List<int>();

        public SystemClass()
        {
            InitComponents();
        }
        public void InitComponents()
        {
            LoadSettings();
        }
        public void LoadSettings()
        {
            //init settings
            SettingsFile settingsFile = FileClass.ReadSettingsFile();
            currency = settingsFile.currency;
            seasonDays = settingsFile.seasonDays;
            machinesValueLow = settingsFile.machinesValueLow;
            machinesValueBig = settingsFile.machinesValueBig;
            landSizeLow = settingsFile.landSizeLow;
            landSizeBig = settingsFile.landSizeBig;

            for (int i = 0; i < seasonDays; i++)
            {
                if (i % (seasonDays / 3) == 0)
                {
                    stagePoints.Add(i);
                }
            }
            stagePoints.Add(seasonDays + 1);
        }
        public double CountLoanTotalAmount(double loanAmount, double loanInstallment)
        {
            var val = ((loanAmount * (100 + loanInstallment)) / 100).ToString();
            var endVal = "";
            int decNumbers = 0;
            bool countDecNumb = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == ',')
                {
                    countDecNumb = true;
                    endVal += ',';
                }
                else
                {
                    if (countDecNumb) decNumbers++;
                    endVal += val[i];
                    if (decNumbers == 2) break;
                }

            }
            return double.Parse(endVal);
        }
        public double CountLoanTotalInstallment(double loanTotalAmount, int loanMonths)
        {
            var val = (loanTotalAmount / loanMonths).ToString();
            var endVal = "";
            int decNumbers = 0;
            bool countDecNumb = false;
            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == ',')
                {
                    countDecNumb = true;
                    endVal += ',';
                }
                else
                {
                    if (countDecNumb) decNumbers++;
                    endVal += val[i];
                    if (decNumbers == 2) break;
                }

            }
            return double.Parse(endVal);
        }
        public void CheckLoanPossibility(int profileNumber, int farmProfileNumber, string bankType, string loanType, double loanAmount)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            machinesValue = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice;
            landSize = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].totalLandSize;
            loanNumber = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.loanItems.Count + 1;
            customerLoansAmount = 0;
            foreach (var i in profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].loansTag.loanItems)
            {
                customerLoansAmount += i.loanTotalAmount;
            }
            customerLoansAmount += loanAmount;
            
            var systemFile=FileClass.ReadSystemFile();

            if (machinesValue >= machinesValueLow && machinesValue < machinesValueBig && 
                landSize < landSizeBig && landSize >= landSizeLow)//qualified to med farm
            {
                farmSize = ResourcesClass.FarmSize.Medium.ToString();
            }
            else if (machinesValue > machinesValueBig && landSize > landSizeBig)//qualified to big farm
            {
                farmSize = ResourcesClass.FarmSize.Large.ToString();
            }
            else
            {
                farmSize = ResourcesClass.FarmSize.Small.ToString();
            }


            if (bankType==ResourcesClass.BankType.Bank1.ToString())
            {
                if(loanType==ResourcesClass.LoanType.Standard.ToString())
                {
                    if (loanNumber == 1 && customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        amountOfInterest = systemFile.bankData.bank1Item.loan1Cost;
                        endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                    }
                    else if (loanNumber == 2 && customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        amountOfInterest = systemFile.bankData.bank1Item.loan2Cost;
                        endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                    }
                    else if (loanNumber == 3 && customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        amountOfInterest = systemFile.bankData.bank1Item.loan3Cost;
                        endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                    }
                    else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                }
                else if(loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                }
            }
            else if (bankType == ResourcesClass.BankType.Bank2.ToString())
            {
                if (loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    if (farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        if (loanNumber == 1)
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 2 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount)//max 60k for small farms
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 3 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount)//max 60k for small farms
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan3Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        if (loanNumber == 1)
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 2 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)//max 100k for medium
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 3 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)
                        {
                            amountOfInterest = 0; //0% 3rd loan
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        if (loanNumber == 1)
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 2 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)//max 100k for medium
                        {
                            amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else if (loanNumber == 3 && customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)
                        {
                            amountOfInterest = 0; //0% 3rd loan
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                }
                else if (loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                }
            }
            else if (bankType == ResourcesClass.BankType.Bank3.ToString())
            {
                if (loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    if (farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        if (loanNumber <= 3 && customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            amountOfInterest = systemFile.bankData.bank3Item.loanCost + 5.0;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        if (loanNumber <= 3 && customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            amountOfInterest = systemFile.bankData.bank3Item.loanCost;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        if (loanNumber <= 3 && customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            amountOfInterest = systemFile.bankData.bank3Item.loanCost - 5.0;
                            endingCode = ResourcesClass.LoanCheckMessageCode.Accepted.ToString();
                        }
                        else endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                }
                else if (loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                    else if (farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        endingCode = ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString();
                    }
                }
            }
            
        }
        public void LoadSeasonsData(int profileNumber)
        {
            var systemFile = FileClass.ReadSystemFile();
            day = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonDay;
            CurrentSeason = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonName;
            CurrentSeasonStage = systemFile.seasonsTag.seasonProfiles[profileNumber].seasonStage;
        }
        public void NextDayClick(int profileNr)
        {
            if (day == seasonDays && currentSeason == 3)
            {
                day = 0;
                currentSeason = 0;
                stageIndex = 1;
                currentSeasonStage = 0;
            }
            else if (day == seasonDays)
            {
                day = 0;
                stageIndex = 1;
                currentSeason++;
                currentSeasonStage = 0;
            }
            else if (stagePoints[stageIndex]==day)
            {
                stageIndex++;
                currentSeasonStage++;
                day++;
            }
            else
            {
                day++;
            }

            var systemFile = FileClass.ReadSystemFile();
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonDay = day;
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonName = CurrentSeason;
            systemFile.seasonsTag.seasonProfiles[profileNr].seasonStage = CurrentSeasonStage;
            FileClass.SaveSystemFile(systemFile);
        }
    }
}
