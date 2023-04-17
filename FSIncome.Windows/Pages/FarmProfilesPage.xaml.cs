using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Windows.Pages.MainPagePages.MoneyPage;
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
using System.Windows.Threading;

namespace FSIncome.Windows.Pages
{
    public partial class FarmProfilesPage : Page
    {
        public bool goBack { get; set; } = false;
        public int profileNumber { get; set; }
        private Button[] buttons {  get; set; } 
        private Label[] labels {  get; set; } 
        private Image[] images {  get; set; }

        private CreateFarmProfilePage createFarmProfilePage;
        private MainPage mainPage;

        private DispatcherTimer pageTimer;

        public FarmProfilesPage()
        {
            InitializeComponent();
            createFarmProfilePage = new CreateFarmProfilePage();
            

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true;

            buttons = new Button[10];
            labels = new Label[30];
            images = new Image[10];

            buttons[0] = Button1;
            buttons[1] = Button2;
            buttons[2] = Button3;
            buttons[3] = Button4;
            buttons[4] = Button5;
            buttons[5] = Button6;
            buttons[6] = Button7;
            buttons[7] = Button8;
            buttons[8] = Button9;
            buttons[9] = Button10;

            labels[0] = Label1_0;
            labels[1] = Label2_0;
            labels[2] = Label3_0;
            labels[3] = Label4_0;
            labels[4] = Label5_0;
            labels[5] = Label6_0;
            labels[6] = Label7_0;
            labels[7] = Label8_0;
            labels[8] = Label9_0;
            labels[9] = Label10_0;

            labels[10] = Label1_1;
            labels[11] = Label2_1;
            labels[12] = Label3_1;
            labels[13] = Label4_1;
            labels[14] = Label5_1;
            labels[15] = Label6_1;
            labels[16] = Label7_1;
            labels[17] = Label8_1;
            labels[18] = Label9_1;
            labels[19] = Label10_1;

            labels[20] = Label1_2;
            labels[21] = Label2_2;
            labels[22] = Label3_2;
            labels[23] = Label4_2;
            labels[24] = Label5_2;
            labels[25] = Label6_2;
            labels[26] = Label7_2;
            labels[27] = Label8_2;
            labels[28] = Label9_2;
            labels[29] = Label10_2;

            images[0] = Image1;
            images[1] = Image2;
            images[2] = Image3;
            images[3] = Image4;
            images[4] = Image5;
            images[5] = Image6;
            images[6] = Image7;
            images[7] = Image8;
            images[8] = Image9;
            images[9] = Image10;

        }

        private void PageTimer_Tick(object sender, EventArgs e)
        {
            if (createFarmProfilePage.goBack) 
            {
                UpdateProfiles();
                PageFrame.Content = null; 
                createFarmProfilePage.goBack = false; 
            }
            if(mainPage != null) 
            {
                if (mainPage.goBack)
                {
                    UpdateProfiles();
                    PageFrame.Content = null;
                    mainPage.goBack = false;
                }
            }
            
        }
        public void UpdateProfiles()
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            var settingsFile = FileClass.ReadSettingsFile();
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visibility = Visibility.Hidden;
                labels[i].Visibility = Visibility.Hidden;
                labels[i + 10].Visibility = Visibility.Hidden;
                labels[i + 20].Visibility = Visibility.Hidden;
                images[i].Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count + 1; i++)
            {
                if (i < profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count)
                {
                    buttons[i].Visibility = Visibility.Visible;
                    labels[i].Visibility = Visibility.Visible;
                    labels[i + 10].Visibility = Visibility.Visible;
                    labels[i + 20].Visibility = Visibility.Visible;
                    images[i].Visibility = Visibility.Visible;
                    labels[i].Content = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[i].name;
                    labels[i + 10].Content = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[i].localisation;
                    labels[i + 20].Content = ResourcesClass.ChangeSeperatorToDot(profilesDataFile.profiles[profileNumber].
                        farmProfiles.farmProfiles[i].bankAccount.ToString()) + " " + settingsFile.currency.ToUpper();
                }
                else
                {
                    buttons[i].Visibility = Visibility.Visible;
                    buttons[i].Content = "Create new farm profile";
                }
            }
        }
        public void SetPageHeader(string name)
        {
            groupBox.Header = name;
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 0)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 0;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 0, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.ClearControls();
                createFarmProfilePage.farmProfileNumber = 0;
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 1)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 1;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 1, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 1;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 2)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 2;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 2, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 2;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 3)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 3;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 3, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 3;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 4)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 4;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 4, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 4;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 5)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 5;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 5, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 5;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 6)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 6;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 6, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 6;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 7)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 7;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 7, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 7;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 8)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 8;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 8, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 8;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            var profilesDataFile = FileClass.ReadProfilesDataFile();
            if (profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count > 9)
            {
                mainPage = new MainPage();
                PageFrame.Content = mainPage;
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = 9;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, 9, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = 9;
                createFarmProfilePage.ClearControls();
                PageFrame.Content = createFarmProfilePage;
            }
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
