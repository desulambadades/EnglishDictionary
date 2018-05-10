using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM = UltimateDictionary.DictionaryManager;

namespace UltimateDictionary
{
    class Stylizer
    {
        List<Style> styles;
        class Style
        {
            public string name;
            public string st1;
            public string st2;
            public Style(string name, string st1, string st2)
            { this.name = name; this.st1 = st1; this.st2 = st2; }
            public int getLenght()
            {
                return st1.Length + st2.Length;
            }
        }

        public Stylizer()
        {
            styles = new List<Style>();
            styles.Add(new Style("bold", "font style=\"font-weight:bold\" color=\"red\"", "font"));
            styles.Add(new Style("brown", "font color =\"maroon\"", "font"));
            styles.Add(new Style("blue", "font color=\"blue\"", "font"));
            styles.Add(new Style("italic", "font color =\"#00a86b\"", "font"));
        }

        int LeftConstrane(int i)
        {
            int leftConstrain;

            if (i == 0)
                leftConstrain = 0;
            else
                leftConstrain = i - 1;
            return leftConstrain;
        }
        int RightConstrane(string word, string text, int i)
        {
            int rightConstrain;

            if (word.Length + i == text.Length)
                rightConstrain = text.Length;
            else
                rightConstrain = i + word.Length;

            return rightConstrain;
        }

        public bool IsComplete(string word, string text, int i)
        {
            bool isBegining = i == 0;
            bool isEnding = (i == text.Length - 1);

            int rightConstrain = RightConstrane(word, text, i);
            int leftConstrain = LeftConstrane(i);
            /*
            if (i - 1 >= 0)//выходит за границы текста такое бывает?
                leftConstrain = i - 1;
            else
                leftConstrain = 0;

            if (i + word.Length < text.Length)//выходит за границы текста такое бывает?
                rightConstrain = i + word.Length;
            else
                rightConstrain = text.Length;
                */
            if (isBegining)
                if (Char.IsLetter(text[rightConstrain]) == false)
                    return true;
            if (isEnding)
                if (Char.IsLetter(text[leftConstrain]) == false)
                    return true;

            if (Char.IsLetter(text[leftConstrain]) == false && Char.IsLetter(text[rightConstrain]) == false)
                return true;
            return false;
        }
        
        string ApplyStyle(string text, int i, DM.Styles style, string freq, string word, string translation)
        {
            addStyleToLeft(ref text, ref i, styles[(int)style].st1, translation);
            i += word.Length;
            addFrequency(ref text, ref i, freq);
            addStyleToRight(ref text, ref i, styles[(int)style].st2);
            return text;
        }
        void addStyleToLeft(ref string text, ref int i, string style, string translation)
        {
            string addings = "<" + style + " title = '" + translation + "'" + ">";
            text = text.Insert(i, addings);
            i += addings.Length;
        }
        void addStyleToRight(ref string text, ref int i, string style)
        {
            text = text.Insert(i, "</" + style + ">");
            i += ("</" + style + ">").Length;
        }
        void addFrequency(ref string text, ref int i, string freq)
        {
            text = text.Insert(i, "(" + freq + ")");
            i += ("(" + freq + ")").Length;
        }

        private bool IsInDefinition(string text, int i)
        {
            for (int j = i; j > 0; j--)
            {
                if (text[j] == '<')
                    return true;
                if (text[j] == '>')
                    return false;
            }
            return false;
        }

        public void StylizeWord(string word, ref string text, string freq, DM.Styles style, string translation)//not ignore
        {
            int i = text.IndexOf(word, StringComparison.CurrentCultureIgnoreCase);

            for (; i >= 0;)
            {
                if (IsComplete(word, text, i) && !IsInDefinition(text, i))
                {
                    int x = 0;
                    if (IsInDefinition(text, i))
                        x=0;

                    text = ApplyStyle(text, i, style, freq, word, translation);
                    int addingsLenght = ("<" + styles[(int)style].st1 + " title = '" + translation + "'" + ">").Length;
                    //i += styles[(int)style].getLenght() + freq.Length + 1;
                    i += addingsLenght + freq.Length + 1;
                }
                i = text.IndexOf(word, i + 2, StringComparison.CurrentCultureIgnoreCase);
            }
        }
    }
}
