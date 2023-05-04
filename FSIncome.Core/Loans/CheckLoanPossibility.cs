using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FSIncome.Core.ResourcesClass;

namespace FSIncome.Core.Loans
{
    /*the idea between taking loan is:
     * there are 3 banks that offers loans
     * user can take max 3 loans, 3 standars or for expample 2 standars 1 hypothetical for the biggest farms
     * every bank has a unique offer and loan cost
     * unique conditions 
     */
    public class CheckLoanPossibility
    {
        //ending values from checkLoanPossibility
        private double _amountOfInterest { get; set; }
        public double AmountOfInterest
        {
            get
            {
                return _amountOfInterest;
            }
            set
            {
                _amountOfInterest = value;
            }
        }
        private string _endingCode { get; set; }
        public string EndingCode
        {
            get
            {
                return _endingCode;
            }
            set
            {
                _endingCode = value;
            }
        }
        //

        private int _profileNumber { get; set; }
        private int _farmProfileNumber { get; set; }
        private string _bankType { get; set; }
        private string _loanType { get; set; }
        private double _loanAmount { get; set; }
        private string _hypoLoanType { get; set; }
        private double _fieldPrice { get; set; }
        private double _fertiSize { get; set; }
        private double _machinesValue { get; set; }
        private double _landSize { get; set; }
        private double _landSizeLow { get; set; } //from the settings 
        private double _landSizeBig { get; set; } //from the settings 
        private double _customerLoansAmount { get; set; }
        private double _machinesValueLow { get; set; } //from the settings
        private double _machinesValueBig { get; set; } //from the settings
        private string _farmSize { get; set; }
        private int _loanNumber { get; set; }

        public CheckLoanPossibility(int profileNumber, int farmProfileNumber, string bankType, string loanType, double loanAmount = 0,
            string hypoLoanType = "", double fieldPrice = 0, double fertiSize = 0)
        {
            this._profileNumber = profileNumber;
            this._farmProfileNumber = farmProfileNumber;
            this._bankType = bankType;
            this._loanType = loanType;
            this._loanAmount = loanAmount;
            this._hypoLoanType = hypoLoanType;
            this._fieldPrice = fieldPrice;
            this._fertiSize = fertiSize;

            ReadFiles();

        }
        private void ReadFiles()
        {
            //init settings
            var settingsFile = FileClass.ReadSettingsFile();
            _machinesValueLow = settingsFile.machinesValueLow;
            _machinesValueBig = settingsFile.machinesValueBig;
            _landSizeLow = settingsFile.landSizeLow;
            _landSizeBig = settingsFile.landSizeBig;

            //init profile data
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            _machinesValue = profilesDataFile.profiles[_profileNumber].farmProfiles.farmProfiles[_farmProfileNumber].machinesTotalPrice;
            _landSize = profilesDataFile.profiles[_profileNumber].farmProfiles.farmProfiles[_farmProfileNumber].totalLandSize;
            _loanNumber = profilesDataFile.profiles[_profileNumber].farmProfiles.farmProfiles[_farmProfileNumber].loansTag.standardLoanTag.loanItems.Count +
               profilesDataFile.profiles[_profileNumber].farmProfiles.farmProfiles[_farmProfileNumber].loansTag.hypotheticalLoanTag.loanItems.Count;
            _customerLoansAmount = 0;
            foreach (var i in profilesDataFile.profiles[_profileNumber].farmProfiles.farmProfiles[_farmProfileNumber].loansTag.standardLoanTag.loanItems)
            {
                _customerLoansAmount += i.loanTotalAmount;
            }
            _customerLoansAmount += _loanAmount;
        }
        private void CheckFarmSize()
        {
            if (_machinesValue >= _machinesValueLow && _machinesValue < _machinesValueBig &&
                _landSize < _landSizeBig && _landSize >= _landSizeLow)//qualified to med farm
            {
                _farmSize = ResourcesClass.FarmSize.Medium.ToString();
            }
            else if (_machinesValue > _machinesValueBig && _landSize > _landSizeBig)//qualified to big farm
            {
                _farmSize = ResourcesClass.FarmSize.Large.ToString();
            }
            else _farmSize = ResourcesClass.FarmSize.Small.ToString();
        }

        public void CheckLoan()
        {
            var systemFile = FileClass.ReadSystemFile();

            CheckFarmSize();

            if (_bankType == ResourcesClass.BankType.Bank1.ToString())
            {
                if (_loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    if (_loanNumber == 1 && _customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        _amountOfInterest = systemFile.bankData.bank1Item.loan1Cost;
                        _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                    }
                    else if (_loanNumber == 2 && _customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        _amountOfInterest = systemFile.bankData.bank1Item.loan2Cost;
                        _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                    }
                    else if (_loanNumber == 3 && _customerLoansAmount < systemFile.bankData.bank1Item.bankMaxLoanAmount)
                    {
                        _amountOfInterest = systemFile.bankData.bank1Item.loan3Cost;
                        _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                    }
                    else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                }
                else if (_loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (_farmSize != ResourcesClass.FarmSize.Large.ToString())
                    {
                        _endingCode = ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString();
                    }
                    else
                    {
                        if (_loanNumber < 3)
                        {
                            if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
                            {
                                if (_fieldPrice < systemFile.bankData.bank1Item.maxFieldCost)
                                {
                                    _amountOfInterest = systemFile.bankData.bank1Item.bigLoanCost;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedField.ToString();
                            }
                            else if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.machine.ToString())
                            {
                                _amountOfInterest = systemFile.bankData.bank1Item.bigLoanCost;
                                _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedMachine.ToString();
                            }
                            else
                            {
                                if (_fertiSize > 2000)
                                {
                                    _amountOfInterest = systemFile.bankData.bank1Item.bigLoanCost;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.amountNotEnoughtFertilizerDeny.ToString();
                            }
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedHypothetical.ToString();
                    }
                }
            }
            else if (_bankType == ResourcesClass.BankType.Bank2.ToString())
            {
                if (_loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    if (_farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        if (_loanNumber == 1)
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 2 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount)//max 60k for small farms
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 3 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount)//max 60k for small farms
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan3Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                    else if (_farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        if (_loanNumber == 1)
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 2 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)//max 100k for medium
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 3 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)
                        {
                            _amountOfInterest = 0; //0% 3rd loan
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                    else if (_farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        if (_loanNumber == 1)
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan1Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 2 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)//max 100k for medium
                        {
                            _amountOfInterest = systemFile.bankData.bank2Item.loan2Cost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else if (_loanNumber == 3 && _customerLoansAmount < systemFile.bankData.bank2Item.bankMaxLoanAmount + 40000)
                        {
                            _amountOfInterest = 0; //0% 3rd loan
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                }
                else if (_loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (_farmSize != ResourcesClass.FarmSize.Large.ToString())
                    {
                        _endingCode = ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString();
                    }
                    else
                    {
                        if (_loanNumber < 3)
                        {
                            if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
                            {
                                if (_fieldPrice < systemFile.bankData.bank2Item.maxFieldCost)
                                {
                                    _amountOfInterest = systemFile.bankData.bank2Item.bigLoanCostField;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedField.ToString();
                            }
                            else if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.machine.ToString())
                            {
                                _amountOfInterest = systemFile.bankData.bank2Item.bigLoanCostMach;
                                _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedMachine.ToString();
                            }
                            else
                            {
                                if (_fertiSize > 2000)
                                {
                                    _amountOfInterest = systemFile.bankData.bank2Item.bigLoanCostFerti;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedFertilizer.ToString();
                            }
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedHypothetical.ToString();
                    }

                }
            }
            else if (_bankType == ResourcesClass.BankType.Bank3.ToString())
            {
                if (_loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    if (_farmSize == ResourcesClass.FarmSize.Small.ToString())
                    {
                        if (_loanNumber <= 3 && _customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            _amountOfInterest = systemFile.bankData.bank3Item.loanCost + 5.0;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                    else if (_farmSize == ResourcesClass.FarmSize.Medium.ToString())
                    {
                        if (_loanNumber <= 3 && _customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            _amountOfInterest = systemFile.bankData.bank3Item.loanCost;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                    else if (_farmSize == ResourcesClass.FarmSize.Large.ToString())
                    {
                        if (_loanNumber <= 3 && _customerLoansAmount < systemFile.bankData.bank3Item.bankMaxLoanAmount)
                        {
                            _amountOfInterest = systemFile.bankData.bank3Item.loanCost - 5.0;
                            _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString();
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString();
                    }
                }
                else if (_loanType == ResourcesClass.LoanType.Hypothetical.ToString())
                {
                    if (_farmSize != ResourcesClass.FarmSize.Large.ToString())
                    {
                        _endingCode = ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString();
                    }
                    else
                    {
                        if (_loanNumber < 3)
                        {
                            if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
                            {
                                if (_fieldPrice < systemFile.bankData.bank3Item.maxFieldCost)
                                {
                                    _amountOfInterest = systemFile.bankData.bank3Item.bigLoanCost;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedField.ToString();
                            }
                            else if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.machine.ToString())
                            {
                                _amountOfInterest = systemFile.bankData.bank3Item.bigLoanCost;
                                _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedMachine.ToString();
                            }
                            else
                            {
                                if (_fertiSize > 2000)
                                {
                                    _amountOfInterest = systemFile.bankData.bank3Item.bigLoanCost;
                                    _endingCode = ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString();
                                }
                                else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedFertilizer.ToString();
                            }
                        }
                        else _endingCode = ResourcesClass.LoanCheckMessageCode.NotAcceptedHypothetical.ToString();
                    }
                }
            }
        }
    }
}
