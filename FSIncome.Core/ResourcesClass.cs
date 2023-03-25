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


        public static void EditConfigFile(string projectPath, Dictionary<string, string> settings)
        {
            // Creates a template file

            //read line -> change -> save to new file
            //change template to normal, delete template

            projectPath += "/FSIncome.Core/";
            string endString = "";
            
            using (StreamReader reader = new StreamReader(projectPath + "config.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    bool read = false;
                    bool containsCode = false;
                    string str2 = "";
                    string code = "";

                    //if there is no code to change just rewrite the line
                    for (int i = 0; i < settings.Count; i++)
                    {
                        if (line.Contains(settings.Keys.ToList()[i]))
                        {
                            containsCode = true;    
                        }
                    }

                    if (containsCode==false)
                    {
                        endString += line + "\n";
                    }
                    else
                    {
                        //read code name in the line, then swap value
                        for (int i = 0; i < line.Length; i++)
                        {
                            if (read) str2 += line[i];

                            if (line[i] == '<') read = true;
                            else if (line[i] == '=')
                            {
                                code = str2.Remove(str2.Length - 1);
                                for (int s = 0; s < settings.Count; s++)
                                {
                                    if (code == settings.Keys.ToList()[s])
                                    {
                                        endString += "<" + code + "=" + settings[code] + ">" + "\n";
                                        break;
                                    }
                                }
                                str2 = string.Empty;
                            }
                        }
                    }
                }
            }

            //write data to new file
            using (StreamWriter writer = new StreamWriter(projectPath + "configTemplate.txt"))
            {
                writer.Write(endString);
            }

            //delete old file and rename the new file
            File.Delete(projectPath + "config.txt");
            File.Move(projectPath + "configTemplate.txt", projectPath + "config.txt");

        }

        public static void SaveToConfigFile(string projectPath, string header, string dataLine)
        {
            // Creates a template file

            projectPath += "/FSIncome.Core/";
            string endString = "";

            using (StreamReader reader = new StreamReader(projectPath + "config.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if(!line.Contains(header))
                    {
                        endString += line + "\n";
                    }
                    else
                    {
                        endString += line + "\n";
                        endString += dataLine + "\n";
                    }
                }
            }

            //write data to new file
            using (StreamWriter writer = new StreamWriter(projectPath + "configTemplate.txt"))
            {
                writer.Write(endString);
            }

            //delete old file and rename the new file
            File.Delete(projectPath + "config.txt");
            File.Move(projectPath + "configTemplate.txt", projectPath + "config.txt");
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
