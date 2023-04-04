using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    public static class FileClass
    {
        //files paths
        public static string projectPath { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static string settingsFilePath { get; } = projectPath + "\\FSIncome.Core\\Files\\settings.xml";
        public static string profilesDataFilePath { get; } = projectPath + "\\FSIncome.Core\\Files\\profilesData.xml";

        //files methods
        //profilesData file
        public static ProfilesDataFile ReadProfilesDataFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProfilesDataFile));
            using (StreamReader reader = new StreamReader(profilesDataFilePath))
            {
                ProfilesDataFile obj = (ProfilesDataFile)xmlSerializer.Deserialize(reader);
                return obj;
            }
        }
        public static void SaveProfilesDataFile(ProfilesDataFile profilesDataFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProfilesDataFile));
            using (StreamWriter sw = new StreamWriter(profilesDataFilePath))
            {
                xmlSerializer.Serialize(sw, profilesDataFile);
            }
        }


        //settings file
        public static void SaveSettingsFile(SettingsFile settingsFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsFile));
            using (StreamWriter sw = new StreamWriter(settingsFilePath))
            {
                xmlSerializer.Serialize(sw, settingsFile);
            }
        }
        public static SettingsFile ReadSettingsFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SettingsFile));

            using (StreamReader reader = new StreamReader(settingsFilePath))
            {
                SettingsFile obj = (SettingsFile)xmlSerializer.Deserialize(reader);
                return obj;
            }
        }
    }
}
