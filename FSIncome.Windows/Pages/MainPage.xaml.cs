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
using FSIncome.Core.Loans;
using FSIncome.Core.Season;
using System.Windows.Media.Effects;

namespace FSIncome.Windows.Pages
{
    public partial class MainPage : Page
    {
        public bool goBack { get; set; }

        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }

        private Dictionary<string, string> appImages;

        private DispatcherTimer pageTimer;

        //PAGES
        private HistoryPage historyPage;
        private MarketPage marketPage;
        private TransactionsPage transactionsPage;
        private EditProfile editProfile;

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
        private SetHypotheticalLoanPage setHypotheticalLoanPage;
        private FertilizerLoanPage fertilizerLoanPage;
        private FieldLoanPage fieldLoanPage;

        //MACHINES
        private MachinesMainPage machinesMainPage;
        private AddMachinesPage addMachinesPage;
        //ANIMALS
        private AnimalsMainPage animalsMainPage;
        private AddAnimalsPage addAnimalsPage;
        //FIELDS
        private FieldsMainPage fieldsMainPage;
        private AddFieldsPage addFieldsPage;

        //seasons
        private Seasons seasons;

        public MainPage(Dictionary <string, string> appImages, int profileNumber, int farmProfileNumber)
        {
            InitializeComponent();
            DataContext = appImages;
            this.appImages = appImages;
            this.profileNumber = profileNumber;
            this.farmProfileNumber= farmProfileNumber;  

            InitObjects();
            
            //starting page
            PageFrame.Navigate(moneyPage);
            moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);

            seasons = new Seasons(profileNumber);

            SetSeasonsData();

        }
        private void InitObjects()
        {
            historyPage = new HistoryPage();
            marketPage = new MarketPage();
            transactionsPage = new TransactionsPage();
            editProfile = new EditProfile(appImages);

            //MONEY
            moneyPage = new MoneyPage(appImages);
            takeLoanPage = new TakeLoanPage();
            payLoanPage = new PayLoanPage();
            takeNormalLoanPage = new TakeNormalLoanPage();
            takeHypotheticalLoanPage = new TakeHypotheticalLoanPage();
            myLoansPage = new MyLoansPage();
            resultPage = new ResultPage();
            chooseBankTypePage = new ChooseBankTypePage();
            bankInfoPage = new BankInfoPage();
            fieldLoanPage = new FieldLoanPage();
            setHypotheticalLoanPage = new SetHypotheticalLoanPage();
            fertilizerLoanPage = new FertilizerLoanPage();  

            //MACHINES
            machinesMainPage = new MachinesMainPage();
            addMachinesPage = new AddMachinesPage(appImages);
            //ANIMALS
            animalsMainPage = new AnimalsMainPage();
            addAnimalsPage = new AddAnimalsPage(appImages);
            //FIELDS
            fieldsMainPage = new FieldsMainPage();
            addFieldsPage = new AddFieldsPage(appImages);

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true;

        }
        private void PageTimer_Tick(object sender, EventArgs e)
        {
            MoneyPageEvents();
            TakeLoanPageEvents();
            TakeNormalLoanPageEvents();
            ChooseBankTypePageEvents();
            TakeHypotheticalLoanPageEvents();
            FieldLoanPageEvents();
            FertilizerLoanPageEvents();
            SetHypotheticalLoanPageEvents();
            BankInfoPageEvents();
            ResultPageEvents();
            MyLoansPageEvents();
            TransactionsEvents();
        }
        private void MoneyPageEvents()
        {
            if (moneyPage.takeLoan)
            {
                PageFrame.Navigate(takeLoanPage);
                moneyPage.takeLoan = false;
            }
            if (moneyPage.payLoan)
            {
                moneyPage.payLoan = false;
                payLoanPage.SetLoansLabel(profileNumber, farmProfileNumber);
                PageFrame.Navigate(payLoanPage);
            }
            if (payLoanPage.goBack)
            {
                payLoanPage.goBack = false;
                if(payLoanPage.doActions==true)
                {
                    payLoanPage.SubstractMoney(profileNumber, farmProfileNumber);
                    moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);
                }
                PageFrame.Navigate(moneyPage);
            }
            if (moneyPage.seeLoans)
            {
                moneyPage.seeLoans = false;
                PageFrame.Navigate(myLoansPage);
                myLoansPage.UpdateLoansData(profileNumber, farmProfileNumber);
            }
        }
        private void TakeLoanPageEvents()
        {
            if (takeLoanPage.normalLoan)
            {
                takeLoanPage.normalLoan = false;
                PageFrame.Navigate(chooseBankTypePage);
                chooseBankTypePage.SetEnabledBankButtons(profileNumber, farmProfileNumber);
            }
            if (takeLoanPage.hypothethicLoan)
            {
                takeLoanPage.hypothethicLoan = false;
                PageFrame.Navigate(chooseBankTypePage);
                chooseBankTypePage.SetEnabledBankButtons(profileNumber, farmProfileNumber);
            }
        }
        private void TakeNormalLoanPageEvents()
        {
            if (takeNormalLoanPage.takeLoanButtonPressed)
            {
                takeNormalLoanPage.takeLoanButtonPressed = false;

                var loan = new Loan(profileNumber, farmProfileNumber, chooseBankTypePage.BankType, takeLoanPage.LoanType,
                takeNormalLoanPage.LoanAmount, takeNormalLoanPage.LoanMonths);
                resultPage.SetMessage(loan.EndingMessage);
                moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);

                PageFrame.Navigate(resultPage);
            }
        }
        private void ChooseBankTypePageEvents()
        {
            if (chooseBankTypePage.bank1Click)
            {
                chooseBankTypePage.bank1Click = false;
                PageFrame.Navigate(bankInfoPage);
                bankInfoPage.loanType = takeLoanPage.LoanType;
                bankInfoPage.SetBankDescription(1);
            }
            if (chooseBankTypePage.bank2Click)
            {
                chooseBankTypePage.bank2Click = false;
                PageFrame.Navigate(bankInfoPage);
                bankInfoPage.loanType = takeLoanPage.LoanType;
                bankInfoPage.SetBankDescription(2);
            }
            if (chooseBankTypePage.bank3Click)
            {
                chooseBankTypePage.bank3Click = false;
                PageFrame.Navigate(bankInfoPage);
                bankInfoPage.loanType = takeLoanPage.LoanType;
                bankInfoPage.SetBankDescription(3);
            }
        }
        private void TakeHypotheticalLoanPageEvents()
        {
            if (takeHypotheticalLoanPage.goBack)
            {
                takeHypotheticalLoanPage.goBack = false;
                PageFrame.Navigate(bankInfoPage);
            }
            if (takeHypotheticalLoanPage.machineButtonPressed)
            {
                takeHypotheticalLoanPage.machineButtonPressed = false;
            }
            if (takeHypotheticalLoanPage.fertiButtonPressed)
            {
                takeHypotheticalLoanPage.fertiButtonPressed = false;
                PageFrame.Navigate(fertilizerLoanPage);
                fertilizerLoanPage.ClearControls();
            }
            if (takeHypotheticalLoanPage.fieldButtonPressed)
            {
                takeHypotheticalLoanPage.fieldButtonPressed = false;
                PageFrame.Navigate(fieldLoanPage);
                fieldLoanPage.ClearControls();

            }
        }
        private void FieldLoanPageEvents()
        {
            if (fieldLoanPage.takeLoanPressed)
            {
                fieldLoanPage.takeLoanPressed = false;
                setHypotheticalLoanPage.InitComponents(chooseBankTypePage.BankType, true, fieldLoanPage.FieldPrice, 
                    takeHypotheticalLoanPage.HypotheticalLoanType);
                PageFrame.Navigate(setHypotheticalLoanPage);
            }
            if (fieldLoanPage.goBack)
            {
                fieldLoanPage.goBack = false;
                PageFrame.Navigate(takeHypotheticalLoanPage);
            }
        }
        private void FertilizerLoanPageEvents()
        {
            if(fertilizerLoanPage.takeLoanPressed)
            {
                fertilizerLoanPage.takeLoanPressed = false;
                setHypotheticalLoanPage.InitComponents(chooseBankTypePage.BankType, true, fertilizerLoanPage.FertiTotalPrice,
                    takeHypotheticalLoanPage.HypotheticalLoanType, fertilizerLoanPage.FertilizerSize);
                PageFrame.Navigate(setHypotheticalLoanPage);
            }
            if(fertilizerLoanPage.goBack)
            {
                fertilizerLoanPage.goBack = false;
                PageFrame.Navigate(takeHypotheticalLoanPage);
            }
        }
        private void SetHypotheticalLoanPageEvents()
        {
            if (setHypotheticalLoanPage.takeLoanButtonPressed)
            {
                setHypotheticalLoanPage.takeLoanButtonPressed = false;

                //checking possibility
                var loan = new Loan(profileNumber, farmProfileNumber, chooseBankTypePage.BankType, takeLoanPage.LoanType,
                    loanMonths: setHypotheticalLoanPage.LoanMonths, hypoLoanType: takeHypotheticalLoanPage.HypotheticalLoanType,
                    fieldPrice: fieldLoanPage.FieldPrice, fertiSize: fertilizerLoanPage.FertilizerSize, fertiPrice: fertilizerLoanPage.FertiTotalPrice);
                resultPage.SetMessage(loan.EndingMessage);
                moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);

                //if this is field, add to fields
                if (takeHypotheticalLoanPage.HypotheticalLoanType == ResourcesClass.HypotheticalLoanTypes.field.ToString())
                {
                    //if the loan is accepted
                    if (loan.EndingMessage == ResourcesClass.LoanCheckMessageCode.AcceptedField.ToString())
                        fieldLoanPage.SaveToFile(profileNumber, farmProfileNumber);
                }

                PageFrame.Navigate(resultPage);
            }
        }
        private void BankInfoPageEvents()
        {
            if (bankInfoPage.backButtonPressed)
            {
                bankInfoPage.backButtonPressed = false;
                PageFrame.Navigate(chooseBankTypePage);
            }
            if (bankInfoPage.nextButtonPressed)
            {
                bankInfoPage.nextButtonPressed = false;
                if (takeLoanPage.LoanType == ResourcesClass.LoanType.Standard.ToString())
                {
                    PageFrame.Navigate(takeNormalLoanPage);
                    takeNormalLoanPage.pageCreated = true;
                    takeNormalLoanPage.InitComponents(bankInfoPage.BankNumber);
                }
                else PageFrame.Navigate(takeHypotheticalLoanPage);
            }
        }
        private void ResultPageEvents()
        {
            if (resultPage.finishButtonPressed)
            {
                resultPage.finishButtonPressed = false;
                PageFrame.Navigate(moneyPage);
            }
            if (resultPage.backButtonPressed)
            {
                resultPage.backButtonPressed = false;
                if (takeLoanPage.LoanType == ResourcesClass.LoanType.Standard.ToString()) PageFrame.Navigate(takeNormalLoanPage);
                else PageFrame.Navigate(setHypotheticalLoanPage);
            }
        }
        private void MyLoansPageEvents()
        {
            if (myLoansPage.goBack)
            {
                myLoansPage.goBack = false;
                PageFrame.Navigate(moneyPage);
            }
        }
        private void TransactionsEvents()
        {
            if (transactionsPage.goBack)
            {
                transactionsPage.goBack = false;
                PageFrame.Navigate(moneyPage);
                moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);
            }
        }

        public void SetSeasonsData()
        {
            ResourcesClass.SeasonStage stage = (ResourcesClass.SeasonStage)seasons.CurrentSeasonStage;
            ResourcesClass.Season season = (ResourcesClass.Season)seasons.CurrentSeason;
            SeasonTextBlock.Text =  stage.ToString() + " " + season.ToString();
            DateTextBlock.Text = seasons.Day.ToString() + "/" + seasons.SeasonDays.ToString();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }

        private void MoneyButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(moneyPage);
            moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);
        }

        private void MachinesButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(machinesMainPage);
            machinesMainPage.profileNumber = profileNumber;
            machinesMainPage.farmProfileNumber = farmProfileNumber;
            machinesMainPage.LoadData();
        }

        private void FieldsButton_Click(object sender, RoutedEventArgs e)
        {
            fieldsMainPage.profileNumber = profileNumber;
            fieldsMainPage.farmProfileNumber = farmProfileNumber;
            fieldsMainPage.LoadData();
            PageFrame.Navigate(fieldsMainPage);
        }

        private void AnimalsButton_Click(object sender, RoutedEventArgs e)
        {
            animalsMainPage.profileNumber = profileNumber;
            animalsMainPage.farmProfileNumber = farmProfileNumber;
            animalsMainPage.LoadData();
            PageFrame.Navigate(animalsMainPage);
        }

        private void TransactionsButton_Click(object sender, RoutedEventArgs e)
        {
            transactionsPage.profileNumber=profileNumber;
            transactionsPage.farmProfileNumber=farmProfileNumber;
            transactionsPage.ClearControls();
            PageFrame.Navigate(transactionsPage);
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            historyPage.LoadData(profileNumber,farmProfileNumber);
            PageFrame.Navigate(historyPage);
        }

        private void MarketButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(marketPage);
        }

        private void NextDay_Click(object sender, RoutedEventArgs e)
        {
            seasons.NextDayClick(profileNumber, farmProfileNumber);
            moneyPage.UpdateMoneyPage(profileNumber, farmProfileNumber);
            SetSeasonsData();
        }

        private void editProfileButton_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Navigate(editProfile);
            editProfile.LoadData(profileNumber, farmProfileNumber);
        }
    }
}
