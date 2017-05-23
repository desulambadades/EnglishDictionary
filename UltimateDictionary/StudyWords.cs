using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateDictionary
{
    class StudyWords
    {
        public string word;
        public string translate;
        public int index;
        public int right;
        public int show;
        public List<string> examples;
        public StudyWords(string word,int index, string tr)
        {
            this.word = word; translate = tr; right = 0; show = 0;this.index = index;
            examples = new List<string>();
        }
        public void increaseRight() { right++; }
        public void increaseShow() { show++; }
        public void AddEx(string text) { examples.Add(text); }

    }
}
