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
using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Windows.Pages.CreateFarmProfile;

namespace FSIncome.Windows.Pages
{
    public partial class CreateFarmProfilePage : Page
    {
        //interface objects
        private IAddData addMachinesPage;
        private IAddData addAnimalsPage;
        private IAddData addFieldsPage;

        public int profileNumber { get; set; }
        public int farmProfileNumber { get; set; }
        public bool goBack { get; set; } = false;

        private DispatcherTimer pageTimer;

        //working with images
        private Dictionary<string, string> appImages;
        //profile button image
        private BitmapImage bitmapImage;

        public CreateFarmProfilePage(Dictionary <string, string> appImages)
        {
            InitializeComponent();
            DataContext = appImages;
            this.appImages = appImages;

            pageTimer = new DispatcherTimer();
            pageTimer.Tick += new EventHandler(TimerRunning);
            pageTimer.IsEnabled = true;

            var settingsFile = FileClass.ReadSettingsFile();
            CurrencyLabel.Content = settingsFile.currency.ToUpper();

            addMachinesPage = new AddMachinesPage(appImages);
            addAnimalsPage = new AddAnimalsPage(appImages);
            addFieldsPage = new AddFieldsPage(appImages);
        }
        private void TimerRunning(object sender, EventArgs e)
        {
            if (addMachinesPage.goBack)
            {
                addMachinesPage.goBack = false;
                pageFrame.Navigate(addAnimalsPage);
                addAnimalsPage.profileNumber = profileNumber;
                addAnimalsPage.farmProfileNumber = farmProfileNumber;
                addAnimalsPage.LoadData();
            }

            if (addAnimalsPage.goBack)
            {
                addAnimalsPage.goBack = false;
                pageFrame.Navigate(addFieldsPage);
                addFieldsPage.profileNumber = profileNumber;
                addFieldsPage.farmProfileNumber = farmProfileNumber;
                addFieldsPage.LoadData();
            }
            if (addFieldsPage.goBack)
            {
                addFieldsPage.goBack = false;
                pageFrame.Navigate(null);
                goBack = true;

                //counting total land and machine size, saving to file
                double totalLandSize = 0;
                double totalMachinesPrice = 0;
                var profilesDataFile1 = FileClass.ReadProfilesDataFile();
                for (int i = 0; i < profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].fieldsTag.fields.Count; i++)
                {
                    totalLandSize += profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].fieldsTag.fields[i].size;
                }
                for (int i = 0; i < profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines.Count; i++)
                {
                    totalMachinesPrice += profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTag.machines[i].price;
                }

                profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].totalLandSize = totalLandSize;
                profilesDataFile1.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].machinesTotalPrice = totalMachinesPrice;

                //creating a copy of the image in application folder
                //changing format to .bmp
                if(bitmapImage != null)
                {
                    var createProfileImage = new CreateProfileImage(bitmapImage.UriSource.ToString(), profileNumber, farmProfileNumber);
                }
                

                FileClass.SaveProfilesDataFile(profilesDataFile1);
            }

        }

        private void addImageClick(object sender, RoutedEventArgs e)
        {
            //reading an image from OpenFileDialog
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = "image";
            dialog.Filter = "Image Files (JPG,PNG,BMP)|*.JPG;*.PNG;*.BMP";

            bool? result = dialog.ShowDialog(); 

            if(result == true) 
            {
                //loading image to the button
                bitmapImage = new BitmapImage(new Uri(dialog.FileName));
                chooseImageButtonImage.ImageSource = bitmapImage;

                //setting image name in label
                string[] fileName = dialog.FileName.Split('\\');
                imageNameLabel.Content = fileName[fileName.Count() - 1];
                //making delete button visible
                deleteImageButton.Visibility = Visibility.Visible;
            }
        }
        
        private void deleteImageClick(object sender, RoutedEventArgs e)
        {
            bitmapImage = null;
            chooseImageButtonImage.ImageSource = new BitmapImage(new Uri(appImages["addImageIcon"])); //default image
            imageNameLabel.Content = "no image";
            deleteImageButton.Visibility = Visibility.Hidden;
        }
        
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            goBack = true;  
        }
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if(NameTextBox.Text.Length!=0 && LocalisationTextBox.Text.Length!=0 && BankAccTextBox.Text.Length!=0)
            {
                if (double.TryParse(ResourcesMethods.ChangeSeperator(BankAccTextBox.Text), out double result))
                {
                    var profilesDataFile = FileClass.ReadProfilesDataFile();
                    
                    profilesDataFile.AddFarmProfile(NameTextBox.Text, LocalisationTextBox.Text, 
                        double.Parse(ResourcesMethods.ChangeSeperator(BankAccTextBox.Text)), 
                        profileNumber);
                    FileClass.SaveProfilesDataFile(profilesDataFile);

                    pageFrame.Navigate(addMachinesPage);
                    addMachinesPage.profileNumber = profileNumber;
                    addMachinesPage.farmProfileNumber = farmProfileNumber;
                    addMachinesPage.LoadData();
                }
                else MessageBox.Show("Inappropriate value");
            }
            else MessageBox.Show("Enter all required data");
        }
    }
}
