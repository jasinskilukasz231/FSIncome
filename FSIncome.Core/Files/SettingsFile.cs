using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    [XmlRoot("Settings")]
    public class SettingsFile
    {
        //default values, also in OptionsPage.xaml.cs
        public string currency { get; set; } = "PLN";
        public string landUnit { get; set; } = "Ha";
        public int seasonDays { get; set; } = 12;
        public double machinesValueLow { get; set; } = 100000;
        public double machinesValueBig { get; set; } = 250000;
        public double landSizeLow { get; set; } = 25000;
        public double landSizeBig { get; set; } = 50000;
    }
    
}
