using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    [XmlRoot("Settings")]
    public class SettingsFile
    {
        //default values, also in OptionsPage.xaml.cs
        public string currency { get; set; } = "PLN";
        public int seasonDays { get; set; } = 12;
    }
}
