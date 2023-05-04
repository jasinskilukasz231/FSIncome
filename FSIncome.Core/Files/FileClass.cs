using System.IO;
using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    public static class FileClass
    {
        //files paths
        public static string projectPath { get; } = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static string settingsFilePath { get; } = projectPath + "\\FSIncome.Core\\Files\\settings.xml";
        public static string profilesDataFilePath { get; } = projectPath + "\\FSIncome.Core\\Files\\profilesData.xml";
        public static string initFilePath { get; } = projectPath + "\\FSIncome.Core\\init.xml";
        public static string systemFilePath { get; } = projectPath + "\\FSIncome.Core\\Files\\system.xml";

        //files methods
        //INIT FILE
        public static InitFile ReadInitFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InitFile));
            using (StreamReader reader = new StreamReader(initFilePath))
            {
                var obj = (InitFile)xmlSerializer.Deserialize(reader);
                return obj;
            }
        }
        public static void SaveInitFile(InitFile initFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(InitFile));
            using (StreamWriter sw = new StreamWriter(initFilePath))
            {
                xmlSerializer.Serialize(sw, initFile);
            }
        }
        //profilesData file
        public static ProfilesDataFile ReadProfilesDataFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProfilesDataFile));
            using (StreamReader reader = new StreamReader(profilesDataFilePath))
            {
                var obj = (ProfilesDataFile)xmlSerializer.Deserialize(reader);
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
        //system file
        public static SystemFile ReadSystemFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SystemFile));
            using (StreamReader reader = new StreamReader(systemFilePath))
            {
                var obj = (SystemFile)xmlSerializer.Deserialize(reader);
                return obj;
            }
        }
        public static void SaveSystemFile(SystemFile systemFile)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SystemFile));
            using (StreamWriter sw = new StreamWriter(systemFilePath))
            {
                xmlSerializer.Serialize(sw, systemFile);
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
                var obj = (SettingsFile)xmlSerializer.Deserialize(reader);
                return obj;
            }
        }
    }
}
