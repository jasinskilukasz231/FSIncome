using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace FSIncome.Core
{
    public class LoadImageToProfileButtons
    {
        private string imagesPath;

        public LoadImageToProfileButtons()
        {
            var appImages = new AppImages();
            imagesPath = appImages.teksturesFolderPath + "profilesImages\\";
        }
        public BitmapImage LoadImage(int profileNumber, int farmProfileNumber)
        {
            string path = imagesPath + "profileImage_" + profileNumber.ToString() + "_" + farmProfileNumber.ToString();
            if (File.Exists(path))
            {
                return new BitmapImage(new Uri(path));
            }
            else return null;
        }
    }
}
