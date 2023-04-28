using System.IO;

namespace FSIncome.Core
{
    public class CreateProfileImage
    {
        public CreateProfileImage(string currentDir, int profileNumber, int farmProfileNumber)
        {
            CopyFile(currentDir, profileNumber, farmProfileNumber); 
        }
        private void CopyFile(string currentDir, int profileNumber, int farmProfileNumber)
        {
            AppImages appImages = new AppImages();

            string clearedDir = "";

            for (int i = 0; i < currentDir.Length; i++)
            {
                //deleting "file:\\\" bcs this causes errors
                //this beginning of the filepath is created from openfiledialog
                if (i > 7)
                {
                    clearedDir += currentDir[i];
                }
            }

            string newFileName = "pictureImage_" + profileNumber.ToString() + "_" + farmProfileNumber;
            File.Copy(clearedDir, appImages.teksturesFolderPath + "profilesImages\\" + newFileName, true);
        }

    }
}
