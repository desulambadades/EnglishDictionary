using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using DM = UltimateDictionary.DictionaryManager;

namespace UltimateDictionary
{
    public partial class DictionaryForm : Form
    {
        ExcelManager excelApp;

        public DictionaryForm()
        {
            InitializeComponent();
            DM.fileToAnalizePath = fileToAnalizePathTextBox.Text;
            DM.PathToExcel = dictionaryPathTextBox.Text;
            DM.Init();
            InitSourseListBox();
        }
        void InitSourseListBox()
        {
            sourseListBox.Items.Clear();
            foreach (var item in FileSaver.GetSourseList())
            {
                sourseListBox.Items.Add(item);
            }
        }
        private void addWordsFromTextButton_Click(object sender, EventArgs e)
        {
            if (commonSourceTextBox.Text == "" || sourceTextBox.Text == "")
                return;
            
            int news = 0;
            int olds = 0;
            string log = "";

            WordsFormer allWords = new WordsFormer();            
            string textToAnalyze  = File.ReadAllText(DM.fileToAnalizePath, Encoding.GetEncoding("windows-1251"));
            allWords.analyzeAll(textToAnalyze);
            
            excelApp = new ExcelManager();
            excelApp.Open(DM.PathToExcel);
            List<string> existedWords = excelApp.GetColumn(DM.Columns.word);
            
            for (int j = 0; j < allWords.dict.Count; j++)
            {
                string word = allWords.dict[j].word;
                int indexOfWordInDictionary = existedWords.IndexOf(word);

                Text = j.ToString() + "/" + allWords.dict.Count.ToString();

                if (indexOfWordInDictionary < 0)//add new
                {
                    Translator tranlate = new Translator();
                    Translator.WordTranslation translatedWord;
                    translatedWord = tranlate.makeTranslations(word);

                    int lastRow = excelApp.lastRow;

                    excelApp.SetValue(DM.Columns.word, lastRow, translatedWord.word);
                    excelApp.SetValue(DM.Columns.freq, lastRow, allWords.dict[j].freq.ToString());
                    excelApp.SetValue(DM.Columns.level, lastRow, "0");
                    excelApp.SetValue(DM.Columns.date, lastRow, DateTime.Today.ToShortDateString());
                    excelApp.SetValue(DM.Columns.init, lastRow, translatedWord.initial);
                    excelApp.SetValue(DM.Columns.trans1, lastRow, translatedWord.translation.Split('\t')[0]);
                    excelApp.SetValue(DM.Columns.trans2, lastRow, translatedWord.translation.Split('\t')[1]);
                    excelApp.SetValue(DM.Columns.trans3, lastRow, translatedWord.translation.Split('\t')[2]);
                    excelApp.SetValue(DM.Columns.src, lastRow, sourceTextBox.Text);
                    excelApp.SetValue(DM.Columns.comSrc, lastRow, commonSourceTextBox.Text);

                    DM.AddExamples(excelApp, allWords.dict[j].examples, lastRow);
                    news++;
                }
                else
                {
                    indexOfWordInDictionary = indexOfWordInDictionary + 2;//first two rows isnot count. can refacotr
                    
                    DM.IncreaseFrequency(excelApp, indexOfWordInDictionary, allWords.dict[j].freq);
                    DM.AddExamples(excelApp, allWords.dict[j].examples, indexOfWordInDictionary);
                    olds++;

                    log = log + word + "\taddFreq " + allWords.dict[j].freq.ToString() + "\tfrom " + allWords.dict[j].word + "\r";
                }
            }
            
            Text = "Новые " + news.ToString() + ", знаю " + olds.ToString() + ", всего " + allWords.dict.Count.ToString() + ". Сложность " + (news * 100 / allWords.dict.Count).ToString() + "%";

            FileSaver.Log(log);
            FileSaver.Duplicate(sourceTextBox.Text);

            excelApp.makeVisible();
        }

        private void beautifyButton_Click(object sender, EventArgs e)
        {
            if (excelApp == null)
            {
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }

            var text = File.ReadAllText(DM.fileToAnalizePath, Encoding.GetEncoding("windows-1251"));

            WordsFormer allWords = new WordsFormer();
            allWords.analyzeAll(text);

            List<string> lWords = excelApp.GetColumn(DM.Columns.word);
            List<string> lfreq = excelApp.GetColumn(DM.Columns.freq);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);
            List<string> lSrs = excelApp.GetColumn(DM.Columns.src);
            List<string> ltrans1 = excelApp.GetColumn(DM.Columns.trans1);
            List<string> ltrans2 = excelApp.GetColumn(DM.Columns.trans2);
            List<string> ltrans3 = excelApp.GetColumn(DM.Columns.trans3);

            string addFreq;
            string miniDict = "";

            for (int i = 0; i < allWords.dict.Count; i++)//lWords[i].Count
            {
                string word = allWords.dict[i].word;
                
                Text = i.ToString();

                int ind = lWords.IndexOf(word);
                if (i < 0) continue;

                addFreq = lfreq[ind];

                Stylizer styleze = new Stylizer();
                if (lSrs[ind] == sourceTextBox.Text)//that source 
                {
                    if (lLvl[ind] == "0")//dont know, new   
                        styleze.StylizeWord(word, ref text, addFreq, DM.Styles.bold);

                    if (lLvl[ind] == "1")//maybe know, new
                        styleze.StylizeWord(word, ref text, addFreq, DM.Styles.brown);
                }
                else
                {
                    if (lLvl[ind] == "0" || lLvl[ind] == "1")//maybe know and don't know, another source                    
                    {
                        styleze.StylizeWord(word, ref text, addFreq, DM.Styles.italic);
                        miniDict = miniDict + word + '\t' + ltrans1[ind] + '\t' + ltrans2[ind] + '\t' + ltrans3[ind] + '\r';
                    }
                    if (lLvl[ind] == "2")//maybe know and don't know, another source                    
                    {
                        styleze.StylizeWord(word, ref text, addFreq, DM.Styles.blue);
                        miniDict = miniDict + word + '\t' + ltrans1[ind] + '\t' + ltrans2[ind] + '\t' + ltrans3[ind] + '\r';
                    }
                }
            }
            text = text.Replace("\r", "<br>");

            string name = commonSourceTextBox.Text + " " + sourceTextBox.Text;
            FileSaver.WriteFiles(name, miniDict, text);

            excelApp.Quit();
            Application.Exit();
        }        
       
        private void sourseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sourseListBox.SelectedItem == null)
                return;
            commonSourceTextBox.Text = sourseListBox.SelectedItem.ToString();
            sourceTextBox.Text = sourseListBox.SelectedItem.ToString();
        }

        private void subsTo1_Click(object sender, EventArgs e)
        {
            var textLines = File.ReadAllLines(DM.workingDir + "subs.srt", Encoding.UTF8);
            List<string> lines = new List<string>();
            foreach (var line in textLines)
                if (line.Length > 0 && !Char.IsDigit(line[0]) && !line.Contains("-->") && !(line.Length < 3))
                    lines.Add(line);
            File.WriteAllLines(DM.workingDir + "1.txt", lines, Encoding.UTF8);
        }

        private void StudyButton_Click(object sender, EventArgs e)
        {
            MemorizerForm memoForm = new MemorizerForm();
            memoForm.Show();
            Hide();
        }

        private void addSourseTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && addSourseTextBox.Text.Length > 0)
                sourseListBox.Items.Add(addSourseTextBox.Text);
        }

        private void DictionaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var sourseList = sourseListBox.Items.Cast<string>();
            FileSaver.SaveSourseList(sourseList);
        }


        private void sourseListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                sourseListBox.Items.RemoveAt(sourseListBox.SelectedIndex);
        }
    }
}


