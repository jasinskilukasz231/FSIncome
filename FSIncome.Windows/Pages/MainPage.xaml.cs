using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FSIncome.Windows.Pages.MainPagePages;
using FSIncome.Core;
using FSIncome.Core.Files;
using System.Windows.Threading;
using FSIncome.Windows.Pages.MainPagePages.MoneyPage;
using FSIncome.Windows.Pages.CreateFarmProfile;

namespace FSIncome.Windows.Pages
{
    public partial class MainPage : Page
    {
        public bool goBack { get; set; } = false;

        public SystemClass systemClass;
        private DispatcherTimer pageTimer;

        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        //pages
        private HistoryPage historyPage;
        private MarketPage marketPage;
        
        TransactionsPage transactionsPage;

        //MONEY
        public MoneyPage moneyPage;
        private TakeLoanPage takeLoanPage;
        private PayLoanPage payLoanPage;
        private TakeHypotheticalLoanPage takeHypotheticalLoanPage;
        private TakeNormalLoanPage takeNormalLoanPage;
        private ResultPage resultPage;
        private MyLoansPage myLoansPage;
        private ChooseBankTypePage chooseBankTypePage;
        private BankInfoPage bankInfoPage;
        private FieldLoanPage fieldLoanPage;
        private SetHypotheticalLoanPage setHypotheticalLoanPage;

        //DELETE THIS PAGES IN THE FUTURE
        private AnimalsMainPage animalsMainPage;
        private MachinesMainPage machinesMainPage;
        private FieldsMainPage fieldsMainPage;

        //MACHINES
        private AddMachinesPage addMachinesPage;
        //ANIMALS
        private AddAnimalsPage addAnimalsPage;
        //FIELDS
        private AddFieldsPage addFieldsPage;

        public MainPage()
        {
            InitializeComponent();
            systemClass = new SystemClass();    
            SetSeasonsData();

            historyPage = new HistoryPage();
            marketPage = new MarketPage();  
            
            transactionsPage = new TransactionsPage();

            //MONEY
            moneyPage = new MoneyPage();
            payLoanPage = new PayLoanPage();
            takeLoanPage = new TakeLoanPage();
            takeNormalLoanPage = new TakeNormalLoanPage();
            takeNormalLoanPage.currency = systemClass.Currency.ToUpper();
            takeHypotheticalLoanPage = new TakeHypotheticalLoanPage();
            myLoansPage = new MyLoansPage();
            resultPage = new ResultPage();
            chooseBankTypePage = new ChooseBankTypePage();
            bankInfoPage = new BankInfoPage();
            fieldLoanPage = new FieldLoanPage();
            setHypotheticalLoanPage = new SetHypotheticalLoanPage();

            //MACHINES
            addMachinesPage = new AddMachinesPage();    
            //ANIMALS
            addAnimalsPage = new AddAnimalsPage();
            //FIELDS
            addFieldsPage = new AddFieldsPage();

            //DELETE THIS PAGES IN THE FUTURE
            animalsMainPage = new AnimalsMainPage();
            machinesMainPage = new MachinesMainPage();
            fieldsMainPage = new FieldsMainPage();

            PageFrame.Content = moneyPage;
            systemClass.LoadSeasonsData(profileNumber);

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true;
        }
        private void PageTimer_Tick(object sender, EventArgs e)
        {
            //MONEY
            if (moneyPage.takeLoan)
            {
                moneyPage.takeLoan = false;
                PageFrame.Content = takeLoanPage;
            }
            if (moneyPage.payLoan)
            {
                moneyPage.payLoan = false;
                PageFrame.Content = payLoanPage;
            }
            if (takeLoanPage.normalLoan)
            {
                takeLoanPage.normalLoan = false;
                PageFrame.Content = chooseBankTypePage;
                chooseBankTypePage.SetEnabledBankButtons(profileNumber, farmProfileNumber);
            }
            if (takeLoanPage.hypothethicLoan)
            {
                takeLoanPage.hypothethicLoan = false;
                PageFrame.Content = chooseBankTypePage;
                chooseBankTypePage.SetEnabledBankButtons(profileNumber, farmProfileNumber);
            }
            if (takeNormalLoanPage.takeLoanButtonPressed)
            {
                takeNormalLoanPage.takeLoanButtonPressed = false;

                //checking possibility
                systemClass.CheckLoanPossibility(profileNumber, farmProfileNumber, chooseBankTypePage.bankType, takeLoanPage.loanType,
                    takeNormalLoanPage.loanAmount);

                //just preparing result messages
                resultPage.SetNormalLoanParams(takeNormalLoanPage.loanAmount, takeNormalLoanPage.loanMonths,
                    systemClass.CountLoanTotalInstallment(systemClass.CountLoanTotalAmount(takeNormalLoanPage.loanAmount, systemClass.amountOfInterest),
                    takeNormalLoanPage.loanMonths), systemClass.Currency, systemClass.amountOfInterest);

                if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
                {
                    resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.Accepted.ToString(), takeLoanPage.loanType);

                    var profilesDataFile = FileClass.ReadProfilesDataFile();
                    profilesDataFile.AddLoanItem(profileNumber, farmProfileNumber, takeLoanPage.loanType,
                            systemClass.CountLoanTotalAmount(takeNormalLoanPage.loanAmount, systemClass.amountOfInterest),
                            chooseBankTypePage.bankType, takeNormalLoanPage.loanMonths, 0,
                            systemClass.CountLoanTotalInstallment(systemClass.CountLoanTotalAmount(takeNormalLoanPage.loanAmount, systemClass.amountOfInterest), takeNormalLoanPage.loanMonths));

                    //adding money to profile
                    moneyPage.AddMoneyToProfile(takeNormalLoanPage.loanAmount, profileNumber, farmProfileNumber);
                    moneyPage.UpdateBankAccountTB(profileNumber, farmProfileNumber, systemClass.Currency);

                    FileClass.SaveProfilesDataFile(profilesDataFile);
                }
                else if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString())
                {
                    resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString(), takeLoanPage.loanType);
                }

                PageFrame.Content = resultPage;
            }
            if (chooseBankTypePage.bank1Click)
            {
                chooseBankTypePage.bank1Click = false;
                PageFrame.Content = bankInfoPage;
                bankInfoPage.loanType = takeLoanPage.loanType;
                bankInfoPage.SetBankDescription(1);
            }
            if (chooseBankTypePage.bank2Click)
            {
                chooseBankTypePage.bank2Click = false;
                PageFrame.Content = bankInfoPage;
                bankInfoPage.loanType = takeLoanPage.loanType;
                bankInfoPage.SetBankDescription(2);
            }
            if (chooseBankTypePage.bank3Click)
            {
                chooseBankTypePage.bank3Click = false;
                PageFrame.Content = bankInfoPage;
                bankInfoPage.loanType = takeLoanPage.loanType;
                bankInfoPage.SetBankDescription(3);
            }
            if(takeHypotheticalLoanPage.goBack)
            {
                takeHypotheticalLoanPage.goBack = false;
                PageFrame.Content = bankInfoPage;
            }
            if(takeHypotheticalLoanPage.machineButtonPressed)
            {
                takeHypotheticalLoanPage.machineButtonPressed = false;

            }
            if (takeHypotheticalLoanPage.fieldButtonPressed)
            {
                takeHypotheticalLoanPage.fieldButtonPressed = false;
                PageFrame.Content = fieldLoanPage;
                fieldLoanPage.ClearControls();

            }
            if(fieldLoanPage.takeLoanPressed)
            {
                fieldLoanPage.takeLoanPressed = false;
                setHypotheticalLoanPage.pageCreated = true;
                setHypotheticalLoanPage.itemValue = fieldLoanPage.fieldPrice;
                setHypotheticalLoanPage.currency = systemClass.Currency;
                setHypotheticalLoanPage.InitComponents(chooseBankTypePage.bankType);
                PageFrame.Content = setHypotheticalLoanPage;
            }
            if(setHypotheticalLoanPage.takeLoanButtonPressed)
            {
                setHypotheticalLoanPage.takeLoanButtonPressed = false;

                //checking possibility
                systemClass.CheckLoanPossibility(profileNumber, farmProfileNumber, chooseBankTypePage.bankType, takeLoanPage.loanType,
                    hypoLoanType: takeHypotheticalLoanPage.hypotheticalLoanType, fieldPrice: fieldLoanPage.fieldPrice);


                //just preparing result messages
                resultPage.SetHypotheticalLoanParams(takeHypotheticalLoanPage.hypotheticalLoanType, systemClass.CheckBankCoveringAmount(chooseBankTypePage.bankType),
                    systemClass.amountOfInterest, systemClass.CountLoanTotalInstallment(systemClass.CountLoanTotalAmount(setHypotheticalLoanPage.amountCovered,
                    systemClass.amountOfInterest), setHypotheticalLoanPage.loanMonths), systemClass.Currency, fieldLoanPage.fieldPrice);

                if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
                {
                    resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.Accepted.ToString());
                }
                else if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString())
                {
                    resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.NotAccepted.ToString(), takeLoanPage.loanType);
                }
                else if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString())
                {
                    resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.FarmTooSmall.ToString());
                }

                if (systemClass.endingCode == ResourcesClass.LoanCheckMessageCode.Accepted.ToString())
                {
                    var profilesDataFile = FileClass.ReadProfilesDataFile();

                    if (moneyPage.CheckAndSubstractMoney(setHypotheticalLoanPage.itemValue - setHypotheticalLoanPage.amountCovered, profileNumber,
                        farmProfileNumber))
                    {
                        profilesDataFile.AddLoanItem(profileNumber, farmProfileNumber, takeLoanPage.loanType,
                        systemClass.CountLoanTotalAmount(setHypotheticalLoanPage.amountCovered, systemClass.amountOfInterest),
                        chooseBankTypePage.bankType, setHypotheticalLoanPage.loanMonths, 0,
                        systemClass.CountLoanTotalInstallment(systemClass.CountLoanTotalAmount(setHypotheticalLoanPage.amountCovered, systemClass.amountOfInterest),
                        setHypotheticalLoanPage.loanMonths), takeHypotheticalLoanPage.hypotheticalLoanType);

                        //update transactions
                        profilesDataFile.AddTransactionItem(profileNumber, farmProfileNumber, "Buying a field on loan", fieldLoanPage.fieldPrice,
                            ResourcesClass.SetCategoryExpenditureString(ResourcesClass.TransactionsCategoriesExpenditure.BUYING_FIELDS));

                        moneyPage.UpdateBankAccountTB(profileNumber, farmProfileNumber, systemClass.Currency);

                        FileClass.SaveProfilesDataFile(profilesDataFile);
                    }
                    else resultPage.SetMessage(ResourcesClass.LoanCheckMessageCode.NotEnoughtMoney.ToString());
                }

                PageFrame.Content = resultPage;
            }
            if (takeHypotheticalLoanPage.fertiButtonPressed)
            {
                takeHypotheticalLoanPage.fertiButtonPressed = false;

            }
            if (bankInfoPage.backButtonPressed)
            {
                bankInfoPage.backButtonPressed = false;
                PageFrame.Content = chooseBankTypePage;
            }
            if (bankInfoPage.nextButtonPressed)
            {
                bankInfoPage.nextButtonPressed = false;
                if (takeLoanPage.loanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    PageFrame.Content = takeNormalLoanPage;
                    takeNormalLoanPage.pageCreated = true;
                    takeNormalLoanPage.InitComponents(bankInfoPage.bankNumber);
                }
                else if (takeLoanPage.loanType == ResourcesClass.LoanType.Hypothetical.ToString()) PageFrame.Content = takeHypotheticalLoanPage;

            }
            if(resultPage.finishButtonPressed)
            {
                resultPage.finishButtonPressed = false;
                PageFrame.Content = moneyPage;

            }
            if (resultPage.backButtonPressed)
            {
                resultPage.backButtonPressed = false;
                if (takeLoanPage.loanType == ResourcesClass.LoanType.Standard.ToString()) PageFrame.Content = takeNormalLoanPage;
                else if (takeLoanPage.loanType == ResourcesClass.LoanType.Hypothetical.ToString()) PageFrame.Content = setHypotheticalLoanPage;

            }
            if(fieldLoanPage.goBack)
            {
                fieldLoanPage.goBack = false;
                PageFrame.Content = takeHypotheticalLoanPage;
            }
            if(myLoansPage.goBack)
            {
                myLoansPage.goBack = false;
                PageFrame.Content = moneyPage;
            }
            if(moneyPage.seeLoans)
            {
                moneyPage.seeLoans = false;
                PageFrame.Content = myLoansPage;
                myLoansPage.UpdateLoansData(profileNumber, farmProfileNumber);
            }
            //TRANSACTION
            if(transactionsPage.goBack)
            {
                transactionsPage.goBack = false;
                PageFrame.Content = moneyPage;
                moneyPage.UpdateBankAccountTB(profileNumber, farmProfileNumber, systemClass.Currency);
            }
            //ANIMALS
            //MACHINES
            //FIELDS
        }
        public void SetSeasonsData()
        {
            ResourcesClass.SeasonStage stage = (ResourcesClass.SeasonStage)systemClass.CurrentSeasonStage;
            ResourcesClass.Season season = (ResourcesClass.Season)systemClass.CurrentSeason;
            SeasonTextBlock.Text =  stage.ToString() + " " + season.ToString();
            DateTextBlock.Text = systemClass.Day.ToString() + "/" + systemClass.SeasonDays.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }

        private void MoneyButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = moneyPage;
        }

        private void MachinesButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = machinesMainPage;
            machinesMainPage.profileNumber = profileNumber;
            machinesMainPage.farmProfileNumber = farmProfileNumber;
            machinesMainPage.LoadData();
        }

        private void FieldsButton_Click(object sender, RoutedEventArgs e)
        {
            fieldsMainPage.profileNumber = profileNumber;
            fieldsMainPage.farmProfileNumber = farmProfileNumber;
            fieldsMainPage.LoadData();
            PageFrame.Content= fieldsMainPage;
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            animalsMainPage.profileNumber = profileNumber;
            animalsMainPage.farmProfileNumber = farmProfileNumber;
            animalsMainPage.LoadData();
            PageFrame.Content = animalsMainPage;
        }

        private void TransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            transactionsPage.profileNumber=profileNumber;
            transactionsPage.farmProfileNumber=farmProfileNumber;
            transactionsPage.descriptionTBExp.Text = string.Empty;
            transactionsPage.descriptionTBInc.Text = string.Empty;
            transactionsPage.amountTBExp.Text = string.Empty;
            transactionsPage.amountTBInc.Text = string.Empty;
            transactionsPage.categoryExpanderExp.Header = "CATEGORY";
            transactionsPage.categoryExpanderInc.Header = "CATEGORY";
            PageFrame.Content=transactionsPage;
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            historyPage.LoadData(profileNumber,farmProfileNumber);
            PageFrame.Content=historyPage;
        }

        private void MarketButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content=marketPage;
        }

        private void NextDay_Click(object sender, RoutedEventArgs e)
        {
            systemClass.NextDayClick(profileNumber);
            SetSeasonsData();
        }
    }
}
