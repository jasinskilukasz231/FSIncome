using System.Xml.Serialization;

namespace FSIncome.Core.Files
{
    [XmlRoot("Profiles")]
    public class ProfilesDataFile
    {
        [XmlElement("Profile")]
        public List<ProfileTag> profiles { get; set; } = new List<ProfileTag>();

        public void AddProfile(string name)
        {
            ProfileTag profile = new ProfileTag();
            profile.name = name;
            profiles.Add(profile);
        }
        public void AddFarmProfile(string name, string localisation, double bankAccount, int profileNumber)
        {
            FarmProfileTag farmProfileTag = new FarmProfileTag();
            farmProfileTag.name = name;
            farmProfileTag.localisation = localisation;
            farmProfileTag.bankAccount = bankAccount;
            profiles[profileNumber].farmProfiles.farmProfiles.Add(farmProfileTag);
        }
        public void AddMachine(int profileNr, int farmProfileNr, string name, double price, string brand, string category)
        {
            MachinesItem machinesItem = new MachinesItem();
            machinesItem.id = profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].machinesTag.machines.Count;
            machinesItem.name = name;
            machinesItem.price = price;
            machinesItem.brand = brand;
            machinesItem.category = category;
            profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].machinesTag.machines.Add(machinesItem);
        }
        public void AddAnimals(int profileNr, int farmProfileNr, string animalType, int amount)
        {
            AnimalsItem animalsItem = new AnimalsItem();
            animalsItem.id = profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].animalsTag.animals.Count;
            animalsItem.animalType = animalType;
            animalsItem.amount = amount;
            profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].animalsTag.animals.Add(animalsItem);
        }
        public void AddField(int profileNr, int farmProfileNr, int number, double size, string cropType, string groundType, double price)
        {
            FieldsItem fieldsItem = new FieldsItem();
            fieldsItem.id = profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].fieldsTag.fields.Count;
            fieldsItem.number = number;
            fieldsItem.size = size;
            fieldsItem.cropType = cropType;
            fieldsItem.groundType = groundType;
            fieldsItem.price = price;
            profiles[profileNr].farmProfiles.farmProfiles[farmProfileNr].fieldsTag.fields.Add(fieldsItem);
        }
    }

    [XmlRoot("Profile")]
    public class ProfileTag
    {
        [XmlAttribute("Name")]
        public string name { get; set; }
        [XmlElement("FarmProfiles")]
        public FarmProfilesTag farmProfiles { get; set; } = new FarmProfilesTag();
    }

    [XmlRoot("FarmProfiles")]
    public class FarmProfilesTag
    {
        [XmlElement("FarmProfile")]
        public List<FarmProfileTag> farmProfiles { get; set; } = new List<FarmProfileTag>();
    }

    [XmlRoot("FarmProfile")]
    public class FarmProfileTag
    {
        [XmlAttribute("Name")]
        public string name { get; set; }
        [XmlAttribute("Localisation")]
        public string localisation { get; set; }
        [XmlAttribute("Money")]
        public double bankAccount { get; set; }
        [XmlElement("Machines")]
        public MachinesTag machinesTag { get; set; } = new MachinesTag();
        [XmlElement("Animals")]
        public AnimalsTag animalsTag { get; set; } = new AnimalsTag();
        [XmlElement("Fields")]
        public FieldsTag fieldsTag { get; set; } = new FieldsTag();
    }

    [XmlRoot("Machines")]
    public class MachinesTag
    {
        [XmlElement("Item")]
        public List<MachinesItem> machines { get; set; } = new List<MachinesItem>();
    }
    [XmlRoot("")]
    public class MachinesItem
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string name { get; set; }
        [XmlAttribute]
        public double price { get; set; }
        [XmlAttribute]
        public string brand { get; set; }
        [XmlAttribute]
        public string category { get; set; }
    }

    [XmlRoot("Animals")]
    public class AnimalsTag
    {
        [XmlElement("Item")]
        public List<AnimalsItem> animals { get; set; } = new List<AnimalsItem>();
    }
    [XmlRoot("")]
    public class AnimalsItem
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public string animalType { get; set; }
        [XmlAttribute]
        public int amount { get; set; }

    }
    [XmlRoot("Fields")]
    public class FieldsTag
    {
        [XmlElement("Item")]
        public List<FieldsItem> fields { get; set; } = new List<FieldsItem>();
    }
    [XmlRoot("")]
    public class FieldsItem
    {
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public int number { get; set; }
        [XmlAttribute]
        public double size { get; set; }
        [XmlAttribute]
        public string cropType { get; set; }
        [XmlAttribute]
        public string groundType { get; set; }
        [XmlAttribute]
        public double price { get; set; }
    }
}

