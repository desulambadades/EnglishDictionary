using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DM = UltimateDictionary.DictionaryManager;

namespace UltimateDictionary
{
    class MemoManager
    {
        public List<StudyWords> study;
        /*int from;
        int till;
        int minFreq;*/
        int maxRndWord;
        int currentWord;
        DataGridView grid;
        public MemoManager(DataGridView grid)
        {
            study = new List<StudyWords>();
            this.grid = grid;
        }
        public void Load(string path)
        {
            //File.ReadAllLines()
        }
        public void AddStudy(string word, int index, string tr)
        {
            study.Add(new StudyWords(word, index, tr));
        }
        public void ApplyParams(int maxRndWord)
        {
            /*this.from = from;
            this.till = till;
            this.minFreq = minFreq;*/
            this.maxRndWord = maxRndWord;
        }
        public void FillGrid()
        {
            grid.RowCount = 0;
            foreach (var item in study)
            {
                grid.RowCount++;
                grid[0, grid.RowCount - 1].Value = item.word;
                grid[1, grid.RowCount - 1].Value = item.right;
                grid[2, grid.RowCount - 1].Value = item.show;
            }
        }
        public void UpdateGrid()
        {
            if (currentWord >= grid.RowCount)
                return;
            grid[1, currentWord].Value = study[currentWord].right;
            grid[2, currentWord].Value = study[currentWord].show;
        }

        public void SkipWord()
        {
            study.RemoveAt(currentWord);
            grid.Rows.RemoveAt(currentWord);
        }
        public StudyWords GetCurrentWord()
        {
            return study[currentWord];
        }
        internal string NextWord()
        {
            if (study.Count < maxRndWord)
                maxRndWord = study.Count;

            Random rnd = new Random();
            int newRndVal;
            do
            {
                newRndVal = rnd.Next(0, maxRndWord);
            } while (newRndVal == currentWord && study.Count > 1);
            currentWord = newRndVal;

            return study[currentWord].word;
        }       
        public string ShowExamples()
        {
            string text = "";

            UpdateGrid();

            text += study[currentWord].translate + "\r-------\r";
            foreach (var example in study[currentWord].examples)
            {
                text += example + "\r\r";
            }

            return text;
        }
        internal string Right(bool needToIncrese)
        {            
            if(needToIncrese)
                study[currentWord].increaseRight();
            return study[currentWord].right.ToString();
        }
        internal string Show(bool needToIncrese)
        {
            if(needToIncrese)
                study[currentWord].increaseShow();
            return study[currentWord].show.ToString();
        }
        

    }
    
}
