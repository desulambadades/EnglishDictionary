using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateDictionary
{
    class DictionaryManager
    {
        public static ColumnsOfDictionary Columns;
        public static string PathToExcel = @"C:\3\UltimateDictionary.xlsx";
        public static string workingDir = @"C:\3\";
        public static string fileToAnalizePath = @"C:\3\1.txt";

        public static void Init()
        {
            Columns = new ColumnsOfDictionary();
        }
        public enum Styles
        {
            bold, brown, blue, italic
        };
        public class ColumnsOfDictionary
        {
            public int word = 1;
            public int freq = 2;
            public int level = 3;
            public int date = 4;
            public int init = 7;
            public int trans1 = 8;
            public int trans2 = 9;
            public int trans3 = 10;
            public int src = 11;
            public int comSrc = 12;
        }
        
        public static void AddExamples(ExcelManager excelApp,List<string> examples,int indexOfWordInDictionary)
        {
            foreach (var example in examples)
            {
                for (int col = 0; col < WordsFormer.maxExamples; col++)
                {
                    string celVal = excelApp.GetValue(col + WordsFormer.whereExamplesStart, indexOfWordInDictionary);

                    if (celVal == example)
                        break ;
                    if (celVal == null || celVal == "")
                    {
                        excelApp.SetValue(col + WordsFormer.whereExamplesStart, indexOfWordInDictionary, example);
                        break;
                    }
                }
            }
        }
        public static void IncreaseFrequency(ExcelManager excelApp,int indexOfWordInDictionary,int freq)
        {
            string oldFrequnecy = excelApp.GetValue(Columns.freq, indexOfWordInDictionary);
            int newFrequency = Convert.ToInt32(excelApp.GetValue(Columns.freq, indexOfWordInDictionary)) + freq;
            excelApp.SetValue(Columns.freq, indexOfWordInDictionary, newFrequency.ToString());
        }
    }
}
