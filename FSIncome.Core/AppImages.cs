using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSIncome.Core
{
    public class AppImages
    {
        public string teksturesFolderPath { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName + 
            "\\FSIncome.Core\\Files\\tekstures\\";
        public Dictionary<string, string> teksturesNames { get; set; } = new Dictionary<string, string>();

        public AppImages()
        {
            InitComponents();   
        }

        public void InitComponents()
        {
            teksturesNames["background0"] = teksturesFolderPath + "background0.bmp";
            teksturesNames["background1"] = teksturesFolderPath + "background1.bmp";
            teksturesNames["background2"] = teksturesFolderPath + "background2.bmp";
            teksturesNames["background3"] = teksturesFolderPath + "background3.bmp";
            teksturesNames["background4"] = teksturesFolderPath + "background4.bmp";
            teksturesNames["settingsButtonImage"] = teksturesFolderPath + "settings.bmp";
            teksturesNames["moneyIcon"] = teksturesFolderPath + "money.bmp";
            teksturesNames["localisationIcon"] = teksturesFolderPath + "pin.bmp";
            teksturesNames["notificationIconNo"] = teksturesFolderPath + "notificationNo.bmp";
            teksturesNames["notificationIconYes"] = teksturesFolderPath + "notificationYes.bmp";
            teksturesNames["addImageIcon"] = teksturesFolderPath + "addImageIcon.bmp";
            teksturesNames["removeIcon"] = teksturesFolderPath + "removeIcon.bmp";
            teksturesNames["warningIconRed"] = teksturesFolderPath + "warning.bmp";
        }
    }
}
