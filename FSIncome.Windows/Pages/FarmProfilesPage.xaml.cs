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
        public bool goBack { get; set; }
        public int profileNumber { get; set; }
        private StackPanel[] panels;
        private Button[] buttons;
        private Label[] labels;
        private Image[] images;
        private ImageBrush[] profilesImages;

        private CreateFarmProfilePage createFarmProfilePage;
        private MainPage mainPage;

        private DispatcherTimer pageTimer;

        private Dictionary<string, string> appImages = new Dictionary<string, string>();

        public FarmProfilesPage(Dictionary<string, string> appImages)
        {
            InitializeComponent();
            DataContext = appImages;
            this.appImages = appImages;

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(PageTimer_Tick);
            pageTimer.IsEnabled = true;

            panels = new StackPanel[10];
            buttons = new Button[10];
            labels = new Label[40];
            images = new Image[30];
            profilesImages = new ImageBrush[10];

            panels[0] = panel1;
            panels[1] = panel2;
            panels[2] = panel3;
            panels[3] = panel4;
            panels[4] = panel5;
            panels[5] = panel6;
            panels[6] = panel7;
            panels[7] = panel8;
            panels[8] = panel9;
            panels[9] = panel10;

            profilesImages[0] = button1Image;
            profilesImages[1] = button2Image;
            profilesImages[2] = button3Image;
            profilesImages[3] = button4Image;
            profilesImages[4] = button5Image;
            profilesImages[5] = button6Image;
            profilesImages[6] = button7Image;
            profilesImages[7] = button8Image;
            profilesImages[8] = button9Image;
            profilesImages[9] = button10Image;

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

            labels[30] = Label1_3;
            labels[31] = Label2_3;
            labels[32] = Label3_3;
            labels[33] = Label4_3;
            labels[34] = Label5_3;
            labels[35] = Label6_3;
            labels[36] = Label7_3;
            labels[37] = Label8_3;
            labels[38] = Label9_3;
            labels[39] = Label10_3;

            images[0] = Image1_0;
            images[1] = Image2_0;
            images[2] = Image3_0;
            images[3] = Image4_0;
            images[4] = Image5_0;
            images[5] = Image6_0;
            images[6] = Image7_0;
            images[7] = Image8_0;
            images[8] = Image9_0;
            images[9] = Image10_0;

            images[10] = Image1_1;
            images[11] = Image2_1;
            images[12] = Image3_1;
            images[13] = Image4_1;
            images[14] = Image5_1;
            images[15] = Image6_1;
            images[16] = Image7_1;
            images[17] = Image8_1;
            images[18] = Image9_1;
            images[19] = Image10_1;

            images[20] = Image1_2;
            images[21] = Image2_2;
            images[22] = Image3_2;
            images[23] = Image4_2;
            images[24] = Image5_2;
            images[25] = Image6_2;
            images[26] = Image7_2;
            images[27] = Image8_2;
            images[28] = Image9_2;
            images[29] = Image10_2;
        }

        private void PageTimer_Tick(object sender, EventArgs e)
        {
            if(createFarmProfilePage!=null)
            {
                if (createFarmProfilePage.goBack)
                {
                    UpdateProfiles();
                    PageFrame.Content = null;
                    createFarmProfilePage.goBack = false;
                }
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
            var loadImage = new LoadImageToProfileButtons();


            for (int i = 0; i < buttons.Length; i++)
            {
                panels[i].Visibility = Visibility.Hidden;
                buttons[i].Visibility = Visibility.Hidden;
                labels[i].Visibility = Visibility.Hidden;
                labels[i + 10].Visibility = Visibility.Hidden;
                labels[i + 20].Visibility = Visibility.Hidden;
                labels[i + 30].Visibility = Visibility.Hidden;
                images[i].Visibility = Visibility.Hidden;
                images[i + 10].Visibility = Visibility.Hidden;
                images[i + 20].Visibility = Visibility.Hidden;
            }

            for (int i = 0; i < profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count + 1; i++)
            {
                if (i < profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles.Count)
                {
                    panels[i].Visibility = Visibility.Visible;
                    buttons[i].Content = "";
                    buttons[i].Visibility = Visibility.Visible;
                    labels[i].Visibility = Visibility.Visible;
                    labels[i + 10].Visibility = Visibility.Visible;
                    labels[i + 20].Visibility = Visibility.Visible;
                    labels[i + 30].Visibility = Visibility.Visible;
                    images[i].Visibility = Visibility.Visible;
                    images[i + 10].Visibility = Visibility.Visible;
                    images[i + 20].Visibility = Visibility.Visible;
                    labels[i].Content = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[i].name;
                    labels[i + 10].Content = profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[i].localisation;
                    labels[i + 20].Content = ResourcesClass.ChangeSeperatorToDot(profilesDataFile.profiles[profileNumber].
                        farmProfiles.farmProfiles[i].bankAccount.ToString()) + " " + settingsFile.currency.ToUpper();

                    //images
                    profilesImages[i].ImageSource = loadImage.LoadImage(profileNumber, i);
                }
                else
                {
                    panels[i].Visibility = Visibility.Visible;
                    buttons[i].Visibility = Visibility.Visible;
                    buttons[i].Content = "Create farm profile";
                }
            }
        }
        public void SetPageHeader(string name)
        {
            groupBox.Header = name;
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = "" + (sender as Button).Name[(sender as Button).Name.Length - 1];
            int buttonNumber = int.Parse((str)) - 1;

            if ((sender as Button).Content != "Create farm profile")
            {
                mainPage = new MainPage();
                PageFrame.Navigate(mainPage);
                mainPage.systemClass.LoadSettings();
                mainPage.systemClass.LoadSeasonsData(profileNumber);
                mainPage.SetSeasonsData();
                mainPage.profileNumber = this.profileNumber;
                mainPage.farmProfileNumber = buttonNumber;
                mainPage.moneyPage.UpdateBankAccountTB(profileNumber, buttonNumber, mainPage.systemClass.Currency);
            }
            else
            {
                createFarmProfilePage = new CreateFarmProfilePage(appImages);
                createFarmProfilePage.profileNumber = profileNumber;
                createFarmProfilePage.farmProfileNumber = buttonNumber;
                PageFrame.Navigate(createFarmProfilePage);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;
        }
    }
}
