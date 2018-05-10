using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimateDictionary
{
    class WordsFormer
    {
        public List<Word> dict;
        static public int whereExamplesStart = 14;    
        static public int maxExamples = 20;   
        
        string text;
        internal static bool Counting;

        public WordsFormer()
        {
            dict = new List<Word>();
        }
        public void analyzeAll(string text)
        {
            this.text = text;
            beautify();
            dict = analyzeText();
        }
        private int findBegining(int i)
        {
            if (text[i] == '.' || text[i] == '?' || text[i] == '!') i--;
            while (text[i] != '.' && text[i] != '?' && text[i] != '!' && i > 0)
                i--;
            while (!Char.IsLetter(text[i]) && i < text.Length - 1)
                i++;
            return i;
        }
        private int findEnding(int i)
        {
            while (text[i] != '.' && text[i] != '?' && text[i] != '!' && i < text.Length - 1)
                i++;

            return i + 1;
        }
        private string getSentence(int i, string word)
        {
            int begin = findBegining(i);
            int end = findEnding(i);
            findQuots(ref begin, ref end);

            if (end - begin > 499)
                end = begin + 500;

            string example = text.Substring(begin, end - begin).Trim();
            example = example.Replace(word, "*" + word + "*");

            return example;
        }
        private void beautify()
        {
            text = text.Replace('\r', ' ');
            text = text.Replace('\n', ' ');
            text = text.Replace("   ", " ");
            text = text.Replace("  ", " ");
            text = text.Replace("--", "-");
            text = text.Replace("�", "'");
            text = text.Replace("™", "");
        }
        private void findQuots(ref int begin, ref int end)
        {
            if (begin > 1 && text[begin - 1] == '\"')
                begin = begin - 1;
            if (end < text.Length - 2 && text[end + 1] == '\"')
                end = end + 1;
        }
        private List<Word> analyzeText()
        {
            List<Word> words = new List<Word>();
            string word = "";
            bool letterBeg = false;
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) || text[i] == '\'')
                {
                    letterBeg = true;
                    word += text[i];
                }
                else
                {
                    if (letterBeg && word.Contains('\'') == false)
                    {
                        if (word.Length > 1)
                        {
                            int indexInWords = words.FindIndex(x => x.word == word.ToLower());
                            if(indexInWords>-1)
                            {
                                words[indexInWords].incFreq();
                                if(!Counting)// если идёт не просто подсчёт слов
                                    words[indexInWords].isExample(getSentence(i, word));
                            }
                            else
                            {
                                Word tmpWord = new Word(word.ToLower());
                                if(!Counting)// если  идёт не просто подсчёт слов
                                    tmpWord.addExample(getSentence(i, word));
                                words.Add(tmpWord);
                                word = "";
                            }                            
                        }
                    }
                    word = "";
                    letterBeg = false;
                }
            }
            return words;
        }

    }
}
