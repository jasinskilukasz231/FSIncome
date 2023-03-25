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
    /// <summary>
    /// Interaction logic for FarmProfilesPage.xaml
    /// </summary>
    public partial class FarmProfilesPage : Page
    {
        private bool[] ProfileExist { get; set; } 
        private Button[] buttons {  get; set; } 
        private Label[] labels {  get; set; } 
        private Image[] images {  get; set; }

        CreateFarmProfilePage createFarmProfilePage { get; set; } = new CreateFarmProfilePage();

       // DispatcherTimer FarmProfilePageTimer { get; set; }

        public FarmProfilesPage()
        {
            InitializeComponent();
            ProfileExist = new bool[10];
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

            //FarmProfilePageTimer = new DispatcherTimer();
            //FarmProfilePageTimer.Tick += new EventHandler(TimerRunning);
            //FarmProfilePageTimer.IsEnabled = true;
        }

        private void TimerRunning(object sender, EventArgs e)
        {
            
        }

        public void SetPageHeader(Button button)
        {
            groupBox.Header = button.Content;

            //while enterting to the page set this params

            for (int i = 0; i < 9; i++)
            {
                if (ProfileExist[i])
                {
                    buttons[i].Visibility = Visibility.Visible;
                    buttons[i + 1].Visibility = Visibility.Visible;

                    labels[i].Visibility = Visibility.Visible;
                    labels[i + 10].Visibility = Visibility.Visible;
                    labels[i + 20].Visibility = Visibility.Visible;

                    images[i].Visibility = Visibility.Visible;
                }
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }

        private void Button10_Click(object sender, RoutedEventArgs e)
        {
            FarmProfilesPageFrame.Content = createFarmProfilePage;
        }
    }
}
