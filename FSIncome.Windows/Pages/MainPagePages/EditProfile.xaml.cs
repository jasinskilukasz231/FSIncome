using FSIncome.Core;
using FSIncome.Core.Files;
using FSIncome.Windows.Pages.CreateFarmProfile;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace FSIncome.Windows.Pages.MainPagePages
{
    public partial class EditProfile : Page
    {
        private BitmapImage bitmapImage;
        private int profileNumber;
        private int farmProfileNumber;
        private string imagePath;
        public EditProfile(Dictionary <string, string> appImages)
        {
            DataContext = appImages;
            InitializeComponent();
        }
        public void LoadData(int profileNumber, int farmProfileNumber)
        {
            this.profileNumber = profileNumber;
            this.farmProfileNumber= farmProfileNumber;

            var file = FileClass.ReadProfilesDataFile();
            var settingsFile = FileClass.ReadSettingsFile();
            NameTextBox.Text = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].name;
            LocalisationTextBox.Text = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].localisation;
            BankAccTextBox.Text = file.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount.ToString();
            CurrencyLabel.Content = settingsFile.currency.ToUpper();

            var appImages = new AppImages();
            imagePath = appImages.teksturesFolderPath + "profilesImages\\profileImage_" + profileNumber.ToString() + "_" + farmProfileNumber.ToString();

            if(File.Exists(imagePath))
            {
                chooseImageButtonImage.ImageSource = new BitmapImage(new Uri(imagePath));

                //setting image name in label
                string[] fileName = imagePath.Split('\\');
                imageNameLabel.Content = fileName[fileName.Count() - 1];
                //making delete button visible
                deleteImageButton.Visibility = Visibility.Visible;
            }
            else
            {
                chooseImageButtonImage.ImageSource = new BitmapImage(new Uri(appImages.teksturesNames["addImageIcon"])); //default image
                imageNameLabel.Content = "no image";
                deleteImageButton.Visibility = Visibility.Hidden;
            }
            
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Length != 0 && LocalisationTextBox.Text.Length != 0 && BankAccTextBox.Text.Length != 0)
            {
                if (double.TryParse(ResourcesMethods.ChangeSeperator(BankAccTextBox.Text), out double result))
                {
                    var profilesDataFile = FileClass.ReadProfilesDataFile();

                    profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].name = NameTextBox.Text;
                    profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].localisation = LocalisationTextBox.Text;
                    profilesDataFile.profiles[profileNumber].farmProfiles.farmProfiles[farmProfileNumber].bankAccount = result;

                    //creating a copy of the image in application folder
                    //changing format to .bmp
                    if (bitmapImage != null)
                    {
                        var createProfileImage = new CreateProfileImage(bitmapImage.UriSource.ToString(), profileNumber, farmProfileNumber);
                    }
                    else
                    {
                        if (File.Exists(imagePath))
                        {
                            //deleting image file by assigning to the init file, deleting with next application start
                            var initFile = FileClass.ReadInitFile();
                            initFile.AddDeleteItem(imagePath);
                            FileClass.SaveInitFile(initFile);

                            MessageBox.Show("Changing this settings requires the restart of the application");
                        }
                    }

                    FileClass.SaveProfilesDataFile(profilesDataFile);
                    MessageBox.Show("Data saved");
                }
                else MessageBox.Show("Inappropriate value");
            }
            else MessageBox.Show("Enter all required data");

        }

        private void addImageClick(object sender, RoutedEventArgs e)
        {
            //reading an image from OpenFileDialog
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = "image";
            dialog.Filter = "Image Files (JPG,PNG,BMP)|*.JPG;*.PNG;*.BMP";

            bool? result = dialog.ShowDialog();

            if (result == true)
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
            var appImages = new AppImages();
            bitmapImage = null;
            chooseImageButtonImage.ImageSource = new BitmapImage(new Uri(appImages.teksturesNames["addImageIcon"])); //default image
            imageNameLabel.Content = "no image";
            deleteImageButton.Visibility = Visibility.Hidden;
        }
    }
}
