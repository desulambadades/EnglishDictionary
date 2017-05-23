using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateDictionary
{
    class Word
    {
        public string word;
        public int freq;
        public List<string> examples;
        public Word(string word)
        {
            this.word = word;
            freq = 1;
            examples = new List<string>();
        }
        public void incFreq()
        {
            freq++;
        }
        public void addExample(string line)
        {
            examples.Add(line);
        }
        
        public bool isExample(string text)
        {
            if (examples.Count >= WordsFormer.maxExamples) return false;

            foreach (var example in examples)
                if (String.Equals(example, text))
                    return false;

            addExample(text);
            return true;
        }
    }
}
