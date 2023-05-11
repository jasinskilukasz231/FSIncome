using FSIncome.Core.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core.Loans
{
    public class Loan
    {
        private int _profileNumber { get; set; }
        private int _farmProfileNumber { get; set; }
        private string _bankType { get; set; }
        private string _loanType { get; set; }
        private double _loanAmount { get; set; }
        private int _loanMonths { get; set; }
        private string _hypoLoanType { get; set; }
        private double _fieldPrice { get; set; }
        private double _fertiSize { get; set; }
        private double _fertiPrice { get; set; }

        private string _endingMessage { get; set; }
        public string EndingMessage
        {
            get
            {
                return _endingMessage;
            }
            set
            {
                _endingMessage = value;
            }
        }
        public Loan(int profileNumber, int farmProfileNumber, string bankType, string loanType, double loanAmount=0, int loanMonths=0, string hypoLoanType = "",
            double fieldPrice = 0, double fertiSize = 0, double fertiPrice = 0) 
        {
            this._profileNumber = profileNumber;
            this._farmProfileNumber = farmProfileNumber;
            this._bankType = bankType;
            this._loanType = loanType;
            this._loanAmount = loanAmount;
            this._loanMonths = loanMonths;
            this._hypoLoanType = hypoLoanType;
            this._fieldPrice = fieldPrice;
            this._fertiSize = fertiSize;
            this._fertiPrice = fertiPrice;

            if (loanType == ResourcesClass.LoanType.Standard.ToString()) TakeStandardLoan();
            else TakeBigLoan();


        }
        private void TakeBigLoan()
        {
            if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
            {
                //checking possibility
                var checkLoan = new CheckLoanPossibility(_profileNumber, _farmProfileNumber, _bankType, _loanType, hypoLoanType: _hypoLoanType,
                    fieldPrice: _fieldPrice);
                checkLoan.CheckLoan(); //after this method ending codes can be checked

                var loanCount = new LoanCount();

                //counting
                double amountCovered = (_fieldPrice * loanCount.CheckBankCoveringAmount(_bankType)) / 100;
                double loanTotalAmount = loanCount.CountLoanTotalAmount(amountCovered, checkLoan.AmountOfInterest);
                double loanTotalInstallment = loanCount.CountLoanTotalInstallment(loanTotalAmount, _loanMonths);

                //just preparing result messages
                var loanMessages = new LoanMessage();

                if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString())
                {
                    //if hypo loan is accepted this method check if there is enought money on the profile to pay the self coverage
                    if (CheckAndSubstractMoney(_fieldPrice - amountCovered, _profileNumber, _farmProfileNumber))
                    {
                        FinishLoanTaking(loanTotalAmount, loanTotalInstallment, ResourcesClass.HypotheticalLoanTypes.field.ToString());

                        loanMessages.PrepareHypotheticalMessage(_hypoLoanType, amountCovered, checkLoan.AmountOfInterest, loanTotalInstallment, _fieldPrice,
                            loanCount.CheckBankCoveringAmount(_bankType));

                        _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString(), _loanType);
                    }
                    else
                    {
                        loanMessages.PrepareMessagesDeny();
                        _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotEnoughtMoneyField.ToString(), _loanType);
                    }
                }
                else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.NotAcceptedField.ToString())
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAcceptedField.ToString(), _loanType);
                }
                else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString())
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString(), _loanType);
                }
                else //not accepted hypo
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAcceptedHypothetical.ToString(), _loanType);
                }
            }
            else if (_hypoLoanType == ResourcesClass.HypotheticalLoanTypes.fertilizer.ToString())
            {
                //checking possibility
                var checkLoan = new CheckLoanPossibility(_profileNumber, _farmProfileNumber, _bankType, _loanType, hypoLoanType: _hypoLoanType,
                    fertiSize: _fertiSize);
                checkLoan.CheckLoan(); //after this method ending codes can be checked

                var loanCount = new LoanCount();
                double loanTotalAmount = loanCount.CountLoanTotalAmount(_fertiPrice, checkLoan.AmountOfInterest);
                double loanTotalInstallment = loanCount.CountLoanTotalInstallment(loanTotalAmount, _loanMonths);

                //just preparing result messages
                var loanMessages = new LoanMessage();

                if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString())
                {
                    loanMessages.PrepareHypotheticalMessage(_hypoLoanType, _fertiPrice, checkLoan.AmountOfInterest, loanTotalInstallment, _fertiPrice,
                    fertiSize: _fertiSize);

                    FinishLoanTaking(loanTotalAmount, loanTotalInstallment, ResourcesClass.HypotheticalLoanTypes.fertilizer.ToString());
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.AcceptedFertilizer.ToString(), _loanType);
                }
                else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.NotAcceptedFertilizer.ToString())
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAcceptedFertilizer.ToString(), _loanType);
                }
                else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString())
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString(), _loanType);
                }
                else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.amountNotEnoughtFertilizerDeny.ToString())
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.amountNotEnoughtFertilizerDeny.ToString(), _loanType);
                }
                else //not accepted hypo
                {
                    loanMessages.PrepareMessagesDeny();
                    _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAcceptedHypothetical.ToString(), _loanType);
                }
            }

        }
        private void TakeStandardLoan()
        {
            //checking possibility
            var checkLoan = new CheckLoanPossibility(_profileNumber, _farmProfileNumber, _bankType, _loanType, _loanAmount);
            checkLoan.CheckLoan(); //after this method ending codes can be checked

            var loanCount = new LoanCount();
            var settingsFile = FileClass.ReadSettingsFile();

            //counting
            double loanTotalAmount = loanCount.CountLoanTotalAmount(_loanAmount, checkLoan.AmountOfInterest);
            double loanTotalInstallment = loanCount.CountLoanTotalInstallment(loanTotalAmount, _loanMonths);

            //just preparing result messages
            var loanMessages = new LoanMessage();
            

            //checkiing ending code, checking if the loan has been approved
            if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString())
            {
                loanMessages.PrepareStandardMessage(_loanAmount, _loanMonths, loanTotalInstallment, settingsFile.currency, checkLoan.AmountOfInterest);
                //assigning proper message to text block
                _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.AcceptedNormal.ToString(), _loanType);

                var profilesDataFile = FileClass.ReadProfilesDataFile();
                profilesDataFile.AddLoanItem(_profileNumber, _farmProfileNumber, _loanType, loanTotalAmount, _bankType, _loanMonths, 0, loanTotalInstallment);

                //adding money to profile
                AddMoneyToProfile(_loanAmount, _profileNumber, _farmProfileNumber, profilesDataFile);

                FileClass.SaveProfilesDataFile(profilesDataFile);
            }
            else if (checkLoan.EndingCode == ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString())
            {
                loanMessages.PrepareMessagesDeny();
                _endingMessage = loanMessages.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAcceptedNormal.ToString(), _loanType);
            }
        }
        private void FinishLoanTaking(double loanTotalAmount, double loanTotalInstallment, string loanType)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();

            profilesDataFile.AddLoanItem(_profileNumber, _farmProfileNumber, _loanType, loanTotalAmount, _bankType, _loanMonths, 0, loanTotalInstallment, _hypoLoanType);

            //update transactions
            if (loanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
            {
                profilesDataFile.AddTransactionExpenditureItem(_profileNumber, _farmProfileNumber, "Buying a field on loan", _fieldPrice,
                    ResourcesMethods.SetCategoryString(ResourcesClass.TransactionsCategoriesExpenditure.BUYING_FIELDS.ToString()));
            }
            else if (loanType == ResourcesClass.HypotheticalLoanTypes.fertilizer.ToString())
            {
                profilesDataFile.AddTransactionExpenditureItem(_profileNumber, _farmProfileNumber, "Buying a fertlizer on loan", _fertiPrice,
                   ResourcesMethods.SetCategoryString(ResourcesClass.TransactionsCategoriesExpenditure.FARM_UTILITIES.ToString()));
            }
            else
            {
                profilesDataFile.AddTransactionExpenditureItem(_profileNumber, _farmProfileNumber, "Buying a machine on loan", _fertiPrice,
                   ResourcesMethods.SetCategoryString(ResourcesClass.TransactionsCategoriesExpenditure.BUYING_MACHINES.ToString()));
            }


            FileClass.SaveProfilesDataFile(profilesDataFile);
        }

        private bool CheckAndSubstractMoney(double moneySubstr, int profileNr, int farmProfileNr)
        {
            var file = FileClass.ReadProfilesDataFile();
            double money = file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount;
            if (moneySubstr > money) return false;
            else
            {
                file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount -= moneySubstr;
                FileClass.SaveProfilesDataFile(file);
                return true;
            }
        }

        public void AddMoneyToProfile(double moneyAdded, int profileNr, int farmProfileNr, ProfilesDataFile file)
        {
            double money = file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount + moneyAdded;
            file.profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].bankAccount = money;
        }
    }
}
