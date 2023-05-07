using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using FSIncome.Core.Files;

namespace FSIncome.Core
{
    [XmlRoot("init")]
    public class InitFile
    {
        [XmlElement("")]
        public List<DeleteFile> deleteFile { get; set; } = new List<DeleteFile>();

        public void AddDeleteItem(string name)
        {
            var delete = new DeleteFile();
            delete.name = name;
            deleteFile.Add(delete); 
        }
    }

    public class DeleteFile
    {
        public string name { get; set; }
    }
}
