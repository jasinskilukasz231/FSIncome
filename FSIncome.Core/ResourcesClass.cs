using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FSIncome.Core
{
    public static class ResourcesClass
    {
        public static string projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
        public static string configFilePath = projectPath + "/FSIncome.Core/config.txt";


        public static void EditFile(string projectPath, Dictionary<string, string> settings)
        {
            projectPath += "/FSIncome.Core/";
            // Create a template file

            //read line -> change -> save to new file
            //change template to normal, delete template


            FileStream fileTemplate = File.Create(projectPath + "configTemplate.txt");

            using (StreamReader reader = new StreamReader(projectPath + "config.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(settings[]))

                    bool read = false;
                    string str2 = "";
                    string code = "";
                    string val = "";

                    for (int i = 0; i < line.Length; i++)
                    {
                        if (read) str2 += line[i];

                        if (line[i] == '<') read = true;
                        else if (line[i] == '=')
                        {
                            code = str2.Remove(str2.Length - 1);
                            str2 = string.Empty;
                        }
                        else if (line[i] == '>')
                        {
                            
                        }
                    }

                }
            }

        }

        public static string ReadData(string filePath, string codeValue)
        {
            string file = File.ReadAllText(filePath);

            bool read = false;
            string str2 = "";
            string code = "";
            string val = "";
            bool returnValue = false;

            for (int i = 0; i < file.Length; i++)
            {
                if (read) str2 += file[i];

                if (file[i] == '<') read = true;
                else if (file[i] == '=')
                {
                    code = str2.Remove(str2.Length - 1);
                    str2 = string.Empty;
                }
                else if (file[i] == '>')
                {
                    read = false;
                    val = str2.Remove(str2.Length - 1);
                    str2 = string.Empty;
                    if (code == codeValue)
                    {
                        returnValue = true;
                        break;
                    }
                }
            }

            if (returnValue) return val;
            else return "noValue";
        }

    }
}
