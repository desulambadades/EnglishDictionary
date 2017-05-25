using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM = UltimateDictionary.DictionaryManager;

namespace UltimateDictionary
{
    class FileSaver
    {
        static public string makeName(string name)
        {
            if (File.Exists(name + ".html"))
            {
                for (int i = 0; i < 30; i++)
                {
                    if (File.Exists(name + "(" + (i + 1).ToString() + ")" + ".html"))
                        continue;
                    else
                    {
                        name = name + "(" + (i + 1).ToString() + ")";
                        break;
                    }
                }
            }
            return name;
        }
        static public string ReadTextToAnalize()
        {
            string textToAnalyze = "";

            if (File.Exists(DM.fileToAnalizePath))
                textToAnalyze = File.ReadAllText(DM.fileToAnalizePath, Encoding.GetEncoding("windows-1251"));

            return textToAnalyze;
        }
        static public string OpenExcelFile()
        {
            string PathToExcel = "";

            if (File.Exists(DM.PathToExcel))
                PathToExcel = File.ReadAllText(DM.PathToExcel, Encoding.GetEncoding("windows-1251"));

            return PathToExcel;
        }

        static public void TagLog(string word, string tag)
        {
            string path = DM.workingDir + "log\\tagging.txt";
            File.AppendAllText(path, word + "\t" + tag + "\t" + DateTime.Now.ToShortDateString() + "\r", Encoding.UTF8);
        }
        static public void Log(string log)
        {
            string path = DM.workingDir + "log\\" + DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString().Replace(":", "-") + ".txt";
            File.WriteAllText(path, log);
        }
        static public void WriteFiles(string name, string miniDict, string text)
        {
            name = makeName(DM.workingDir + name);
            File.WriteAllText(name + "_miniDict.txt", miniDict, Encoding.UTF8);
            File.WriteAllText(name + ".html", text, Encoding.UTF8);
        }
        static public void Duplicate(string sourceText)
        {
            if (!File.Exists(DM.workingDir + sourceText + ".txt"))
                File.Copy(DM.workingDir + "1.txt", DM.workingDir + sourceText + ".txt");
        }
        static public void SaveSourseList(IEnumerable<string> sourceList)
        {
            File.WriteAllLines(DM.workingDir + "SourseList.ini", sourceList, Encoding.UTF8);
        }
        static public IEnumerable<string> GetSourseList()
        {
            return File.ReadAllLines(DM.workingDir + "SourseList.ini", Encoding.UTF8);
        }
    }
}
