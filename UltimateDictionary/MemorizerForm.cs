using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM = UltimateDictionary.DictionaryManager;

namespace UltimateDictionary
{
    public partial class MemorizerForm : Form
    {
        MemoManager memo;
        ExcelManager excelApp;
        FileSaver saver;
        int LearnedWords;
        DateTime t1;

        public MemorizerForm()
        {
            InitializeComponent();
        }
        private void MemorizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (excelApp != null)
                excelApp.Quit();
            Application.Exit();
        }
        private void MemorizerForm_Load(object sender, EventArgs e)
        {
            t1 = DateTime.Now;
            saver = new FileSaver();
            memo = new MemoManager(grid);
        }

        public Dictionary<string, string> countUnknownWords(List<string> lfreq, List<string> lLvl)
        {
            Dictionary<string, string> wordsAnalized = new Dictionary<string, string>();
            int freq = 1;
            int cnt = 0;
            
            do
            {
                for (int i = 0; i < lLvl.Count; i++)
                {
                    if (lLvl[i] == "0" && lfreq[i] == freq.ToString())
                        cnt++;
                }
                wordsAnalized.Add(freq.ToString(), cnt.ToString());
                freq++;
                cnt = 0;
            } while (freq < 11) ;

            return wordsAnalized;
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            if (excelApp == null)
            {
                string pathToExcel = FileSaver.OpenExcelFile();
                if (DM.PathToExcel == "")
                {
                    MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                    return;
                }
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }
            memo = new MemoManager(grid);

            List<string> lWords = excelApp.GetColumn(DM.Columns.word);
            List<string> lfreq = excelApp.GetColumn(DM.Columns.freq);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);
            List<string> ltrans1 = excelApp.GetColumn(DM.Columns.trans1);
            List<string> ltrans2 = excelApp.GetColumn(DM.Columns.trans2);
            List<string> ltrans3 = excelApp.GetColumn(DM.Columns.trans3);

            richTextBox1.Text = "";
            foreach (var item in countUnknownWords(lfreq, lLvl))
            {
                richTextBox1.Text += item.Key + " " + item.Value + "\r";
            } 

            string lvlCondition = "0";

            if (unknownRadioButton.Checked)
                lvlCondition = unknownRadioButton.Text;
            if (fogottenRadioButton.Checked)
                lvlCondition = fogottenRadioButton.Text;
            if (studiedRadioButton.Checked)
                lvlCondition = studiedRadioButton.Text;

            int minFreq = Convert.ToInt16(minFreqTextBox.Text);
            int maxWords = Convert.ToInt16(maxRndTextBox.Text);

            for (int i = 0; i < lWords.Count && memo.study.Count < maxWords; i++)
            {
                if (lLvl[i] == lvlCondition && Convert.ToInt16(lfreq[i]) >= minFreq)
                {
                    memo.AddStudy(lWords[i], i, ltrans1[i] + "," + ltrans2[i] + "," + ltrans3[i]);
                    for (int j = 0; j < WordsFormer.maxExamples; j++)
                    {
                        if (excelApp.GetValue(j + WordsFormer.whereExamplesStart, i + 2) != "")
                            memo.study[memo.study.Count - 1].AddEx(excelApp.GetValue(j + WordsFormer.whereExamplesStart, i + 2));
                    }
                    Text = i.ToString() + " Слов " + memo.study.Count.ToString();
                }
            }
            memo.FillGrid();
            memo.ApplyParams(Convert.ToInt16(rangeTextBox.Text));
            richTextBox1.Focus();
            //nextButton_Click(null, null);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (memo.study.Count == 0)
                return;
            bool notShowed = richTextBox1.Text == "";
            memo.Right(notShowed);

            richTextBox1.Text = "";
            
            memo.UpdateGrid();
            wordLabel.Text = memo.NextWord();
            showLabel.Text = memo.Show(false);
            rightLabel.Text = memo.Right(false);
        }
        private void showButton_Click(object sender, EventArgs e)
        {
            if (memo.study.Count == 0)
                return;
            bool notShowed = richTextBox1.Text == "";
            showLabel.Text = memo.Show(notShowed);

            richTextBox1.Text = memo.ShowExamples();
        }
        private void skipButton_Click(object sender, EventArgs e)
        {
            if (memo.study.Count == 0)
                return;

            memo.SkipWord();

            if (memo.study.Count == 0)
                return;

            //nextButton_Click(null, null);
            richTextBox1.Text = "";
            wordLabel.Text = memo.NextWord();
            showLabel.Text = memo.Show(false);
            rightLabel.Text = memo.Right(false);
        }
        void Tag(string tag)
        {
            if (memo.study.Count == 0)
                return;

            excelApp.SetValue(DM.Columns.level, memo.GetCurrentWord().index + 2, tag);
            excelApp.Save();
            
            FileSaver.TagLog(memo.GetCurrentWord().word, tag);

            skipButton_Click(null, null);            

            WordsCounter();
            
            richTextBox1.Focus();
        }
        void WordsCounter()
        {
            LearnedWords++;
            var Now = DateTime.Now.Subtract(t1).TotalSeconds;
            var spanVal = Now / LearnedWords;
            var span = spanVal.ToString();

            Text = "Выучено слов " + LearnedWords.ToString() + ", слово за " + span;
        }
        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                nextButton_Click(sender, null);
            if (e.KeyCode == Keys.Right)
                showButton_Click(sender, null);
            if (e.KeyCode == Keys.NumPad2)
                tag2Button_Click(sender, null);
            if (e.KeyCode == Keys.NumPad1)
                tag1Button_Click(sender, null);
            if (e.KeyCode == Keys.NumPad3)
                tag3Button_Click(sender, null);
            if (e.KeyCode == Keys.Down)
                skipButton_Click(sender, null);
        }
        private void tag2Button_Click(object sender, EventArgs e)
        {
            Tag("2");
        }
        private void tag1Button_Click(object sender, EventArgs e)
        {
            Tag("1");
        }
        private void tag3Button_Click(object sender, EventArgs e)
        {
            Tag("3");
        }

        private void toDictionaryButton_Click(object sender, EventArgs e)
        {
            DictionaryForm dictForm = new DictionaryForm();
            dictForm.Show();
            Hide();
        }
    }
}
