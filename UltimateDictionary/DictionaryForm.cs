using System;
using System.Collections.Generic;
using System.Data;
using HtmlAgilityPack;
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
        List<char> kana;
        List<char> used;
        public DictionaryForm()
        {
            InitializeComponent();
            kana = new List<char>();
            kana.Add('あ');
            kana.Add('い');
            kana.Add('う');
            kana.Add('え');
            kana.Add('お');
            kana.Add('か');
            kana.Add('き');
            kana.Add('く');
            kana.Add('け');
            kana.Add('こ');
            kana.Add('が');
            kana.Add('ぎ');
            kana.Add('ぐ');
            kana.Add('げ');
            kana.Add('ご');
            kana.Add('さ');
            kana.Add('し');
            kana.Add('す');
            kana.Add('せ');
            kana.Add('そ');
            kana.Add('ざ');
            kana.Add('じ');
            kana.Add('ず');
            kana.Add('ぜ');
            kana.Add('ぞ');
            kana.Add('た');
            kana.Add('ち');
            kana.Add('つ');
            kana.Add('て');
            kana.Add('と');
            kana.Add('だ');
            kana.Add('ぢ');
            kana.Add('づ');
            kana.Add('で');
            kana.Add('ど');
            kana.Add('な');
            kana.Add('に');
            kana.Add('ぬ');
            kana.Add('ね');
            kana.Add('の');
            kana.Add('は');
            kana.Add('ひ');
            kana.Add('ふ');
            kana.Add('へ');
            kana.Add('ほ');
            kana.Add('ば');
            kana.Add('び');
            kana.Add('ぶ');
            kana.Add('べ');
            kana.Add('ぼ');
            kana.Add('ぱ');
            kana.Add('ぴ');
            kana.Add('ぷ');
            kana.Add('ぺ');
            kana.Add('ぽ');
            kana.Add('や');
            kana.Add('ゆ');
            kana.Add('よ');
            kana.Add('わ');
            kana.Add('を');
            kana.Add('ま');
            kana.Add('み');
            kana.Add('む');
            kana.Add('め');
            kana.Add('も');
            kana.Add('ら');
            kana.Add('り');
            kana.Add('る');
            kana.Add('れ');
            kana.Add('ろ');
            kana.Add('ん');
            kana.Add('ろ');
            kana.Add('ん');
            kana.Add('な');
            kana.Add('に');
            kana.Add('た');
            kana.Add('き');
            kana.Add('ぬ');
            kana.Add('め');
            kana.Add('け');
            kana.Add('り');
            kana.Add('は');
            kana.Add('ほ');
            kana.Add('せ');
            kana.Add('さ');
            kana.Add('ち');
            kana.Add('れ');
            kana.Add('ね');
            kana.Add('わ');
            kana.Add('ら');
            kana.Add('る');
            kana.Add('ろ');

            used = new List<char>();
            used.Add('っ');
            used.Add('人');
            used.Add('ー');
            used.Add('ト');
            used.Add('死');
            used.Add('間');
            used.Add('事');
            used.Add('前');
            used.Add('ノ');
            used.Add('僕');
            used.Add('殺');
            used.Add('何');
            used.Add('日');
            used.Add('ラ');
            used.Add('本');
            used.Add('界');
            used.Add('ゃ');
            used.Add('者');
            used.Add('世');
            used.Add('中');
            used.Add('分');
            used.Add('犯');
            used.Add('リ');
            used.Add('悪');
            used.Add('一');
            used.Add('神');
            used.Add('ク');
            used.Add('キ');
            used.Add('今');
            used.Add('書');
            used.Add('言');
            used.Add('ス');
            used.Add('見');
            used.Add('イ');
            used.Add('ュ');
            used.Add('出');
            used.Add('時');
            used.Add('デ');
            used.Add('全');
            used.Add('ン');
            used.Add('手');
            used.Add('思');
            used.Add('罪');
            used.Add('名');
            used.Add('ぁ');
            used.Add('誰');
            used.Add('物');
            used.Add('ぇ');
            used.Add('大');


        }
        private void DictionaryForm_Load(object sender, EventArgs e)
        {
            InitDictionaryManagerPaths();
            DM.Init();
            InitPathsTextBox();
            InitSourseListBox();

            this.Height = 305;
        }
        void InitPathsTextBox()
        {
            if (!File.Exists(workingDirTextBox.Text + "paths.ini"))
                return;

            var paths = File.ReadAllLines(workingDirTextBox.Text + "Paths.ini").ToDictionary(k=>k=k.Split('|')[0],v=>v=v.Split('|')[1]);
            
            fileToAnalizePathTextBox.Text = paths["file"];
            excelPathTextBox.Text = paths["excel"];
            workingDirTextBox.Text= paths["workingDir"];
        }
        void InitDictionaryManagerPaths()
        {
            DM.fileToAnalizePath = fileToAnalizePathTextBox.Text;
            DM.PathToExcel = excelPathTextBox.Text;
            DM.workingDir = workingDirTextBox.Text;
        }
        void InitSourseListBox()
        {
            if (!File.Exists(DM.workingDir + "SourseList.ini"))
                return;

            sourseListBox.Items.Clear();
            foreach (var item in FileSaver.GetSourseList())
            {
                sourseListBox.Items.Add(item);
            }
        }
        private void addWordsFromTextButton_Click(object sender, EventArgs e)
        {
            InitDictionaryManagerPaths();
            if (commonSourceTextBox.Text == "" || sourceTextBox.Text == "")
            {
                MessageBox.Show("Не заполнены поля источники");
                return;
            }
            string textToAnalyze = FileSaver.ReadTextToAnalize();
            if (textToAnalyze == "")
            {
                MessageBox.Show("Файл " + DM.fileToAnalizePath + " не найден");
                return;
            }
            string pathToExcel = FileSaver.OpenExcelFile();
            if (DM.PathToExcel == "")
            {
                MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                return;
            }

            int news = 0;
            int olds = 0;
            string log = "";

            WordsFormer allWords = new WordsFormer();
            allWords.analyzeAll(textToAnalyze);
            if (excelApp == null)
            {
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }
            List<string> existedWords = excelApp.GetColumn(DM.Columns.word);
            
            List<string> lfreq = excelApp.GetColumn(DM.Columns.freq);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);
            int oldUnder = 0;
            List<string> oldUnderList = new List<string>();
            List<int> oldUnderCntList = new List<int>();
            List<int> newsCnt = new List<int>();
            
            for (int i = 0; i < existedWords.Count; i++)
            {
                var f = Convert.ToInt32(lfreq[i]);
                if (lLvl[i] == "0" && Convert.ToInt32(lfreq[i]) <= DictionaryManager.NumberOfRare)
                    oldUnderList.Add(existedWords[i]);
            }

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
                    excelApp.SetValue(DM.Columns.definition, lastRow, translatedWord.definition);
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

                    if (oldUnderList.IndexOf(word) > -1)
                    {
                        oldUnder++;
                    }

                    log = log + word + "\taddFreq " + allWords.dict[j].freq.ToString() + "\tfrom " + allWords.dict[j].word + "\r";
                }
            }
            
            Text = $"Новые {news}, знаю {olds}, всего {allWords.dict.Count}. Сложность {(news * 100 / allWords.dict.Count)}%. Редкие {oldUnder}";

            FileSaver.Log(log);
            FileSaver.Duplicate(sourceTextBox.Text);

            excelApp.makeVisible();
        }

        private void beautifyButton_Click(object sender, EventArgs e)
        {
            InitDictionaryManagerPaths();
            if (excelApp == null)
            {
                string pathToExcel = FileSaver.OpenExcelFile();
                if (pathToExcel == "")
                {
                    MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                    return;
                }
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }

            string textToAnalyze = FileSaver.ReadTextToAnalize();
            if (textToAnalyze == "")
            {
                MessageBox.Show("Файл " + DM.fileToAnalizePath + " не найден");
                return;
            }

            WordsFormer allWords = new WordsFormer();
            allWords.analyzeAll(textToAnalyze);

            List<string> lWords = excelApp.GetColumn(DM.Columns.word);
            List<string> lfreq = excelApp.GetColumn(DM.Columns.freq);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);
            List<string> lSrs = excelApp.GetColumn(DM.Columns.src);
            List<string> ltrans1 = excelApp.GetColumn(DM.Columns.trans1);
            List<string> ltrans2 = excelApp.GetColumn(DM.Columns.trans2);
            List<string> ltrans3 = excelApp.GetColumn(DM.Columns.trans3);
            List<string> ldefinition = excelApp.GetColumn(DM.Columns.definition);


            string addFreq;
            string miniDict = "";

            for (int i = 0; i < allWords.dict.Count; i++)
            {
                string word = allWords.dict[i].word;
                
                this.Text = i.ToString();

                int ind = lWords.IndexOf(word);
                if (ind < 0) continue;

                addFreq = lfreq[ind];

                Stylizer styleze = new Stylizer();

                //string translation = ltrans1[ind] + ',' + ltrans2[ind] + ',' + ltrans3[ind];
                string translation = ltrans1[ind] + ',' + ltrans2[ind] + ',' + ltrans3[ind] + "\n------\n";
                translation += ldefinition[ind].Replace("\"","").Replace("'", "");


                if (lSrs[ind] == sourceTextBox.Text)//that source 
                {
                    if (lLvl[ind] == "0")//dont know, new   
                        styleze.StylizeWord(word, ref textToAnalyze, addFreq, DM.Styles.bold, translation);

                    if (lLvl[ind] == "1")//maybe know, new
                        styleze.StylizeWord(word, ref textToAnalyze, addFreq, DM.Styles.brown, translation);

                    bool writeFullMiniDIct = true;
                    if(writeFullMiniDIct && (lLvl[ind] == "0" || lLvl[ind] == "1"))
                        miniDict = miniDict + word + '\t' + ltrans1[ind] + '\t' + ltrans2[ind] + '\t' + ltrans3[ind] + '\r';
                }
                else
                {
                    if (lLvl[ind] == "0" || lLvl[ind] == "1")//maybe know and don't know, another source                    
                    {
                        styleze.StylizeWord(word, ref textToAnalyze, addFreq, DM.Styles.italic, translation);
                        miniDict = miniDict + word + '\t' + ltrans1[ind] + '\t' + ltrans2[ind] + '\t' + ltrans3[ind] + '\r';
                    }
                    if (lLvl[ind] == "2")//maybe know and don't know, another source                    
                    {
                        styleze.StylizeWord(word, ref textToAnalyze, addFreq, DM.Styles.blue, translation);
                        miniDict = miniDict + word + '\t' + ltrans1[ind] + '\t' + ltrans2[ind] + '\t' + ltrans3[ind] + '\r';
                    }
                }
            }
            textToAnalyze = textToAnalyze.Replace("\r", "<br>");

            string name = commonSourceTextBox.Text + " " + sourceTextBox.Text;
            FileSaver.WriteFiles(name, miniDict, textToAnalyze);

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
            InitDictionaryManagerPaths();

            string paths = "";
            paths += "file|" + DM.fileToAnalizePath + "\r";
            paths += "excel|" + DM.PathToExcel + "\r";
            paths += "workingDir|" + DM.workingDir + "\r";

            if (!Directory.Exists(DM.workingDir))
            {
                Directory.CreateDirectory(DM.workingDir);
            }

            File.WriteAllText(DM.workingDir + "Paths.ini", paths, Encoding.UTF8);

            var sourseList = sourseListBox.Items.Cast<string>();
            FileSaver.SaveSourseList(sourseList);
            Application.Exit();
        }


        private void sourseListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                sourseListBox.Items.RemoveAt(sourseListBox.SelectedIndex);
        }

        private void countWordsButton_Click(object sender, EventArgs e)
        {
            StringBuilder st = new StringBuilder();
            var dir = new DirectoryInfo(@"C:\3\many\").GetFiles();
            foreach (var file in dir)
            {
                st.AppendLine(File.ReadAllText(file.FullName,Encoding.UTF8));
            }

            string pathToExcel = FileSaver.OpenExcelFile();
            if (DM.PathToExcel == "")
            {
                MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                return;
            }

            int news = 0;
            int olds = 0;
            int oldUnder = 0;
            int oldUnderFreqSum = 0;

            WordsFormer.Counting = true;

            WordsFormer allWords = new WordsFormer();
            allWords.analyzeAll(st.ToString());

            WordsFormer.Counting = false;

            excelApp = new ExcelManager();
            excelApp.Open(DM.PathToExcel);
            List<string> existedWords = excelApp.GetColumn(DM.Columns.word);
            List<string> lfreq = excelApp.GetColumn(DM.Columns.freq);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);

            List<string> oldUnderList = new List<string>();
            List<int> oldUnderCntList = new List<int>();
            List<int> newsCnt = new List<int>();


            for (int i = 0; i < existedWords.Count; i++)
            {
                var f = Convert.ToInt32(lfreq[i]);
                if (lLvl[i] == "0" && Convert.ToInt32(lfreq[i]) <= DictionaryManager.NumberOfRare)
                    oldUnderList.Add(existedWords[i]);
            }

            for (int j = 0; j < allWords.dict.Count; j++)
            {
                string word = allWords.dict[j].word;
                int indexOfWordInDictionary = existedWords.IndexOf(word);

                Text = j.ToString() + "/" + allWords.dict.Count.ToString();

                if (indexOfWordInDictionary < 0)//add new                                  
                {
                    news++;
                    newsCnt.Add(allWords.dict[j].freq);
                }
                else
                {
                    olds++;
                    if (oldUnderList.IndexOf(word) > -1)
                    {
                        oldUnder++;
                        oldUnderFreqSum += allWords.dict[j].freq;
                        oldUnderCntList.Add(allWords.dict[j].freq);
                    }
                }
            }
            
            Text = $"Новые {news}, среднее кол-во {newsCnt.FindAll(x => x < 15).Average()}, знаю {olds}, всего {allWords.dict.Count}. Сложность {(news * 100 / allWords.dict.Count)}%";
            Text += $". Редкие старые {oldUnder}, в среднем {oldUnderCntList.Average()}";
            excelApp.makeVisible();
            excelApp.Quit();
        }

        private void showTextBoxButton_Click(object sender, EventArgs e)
        {
            showTextBoxButton.Text = "";

            if (this.Height > textToReadRichBox.Height)
                this.Height = 305;
            else
                this.Height = this.Height + textToReadRichBox.Height;
        }

        private void analizeTextBoxButton_Click(object sender, EventArgs e)
        {
            if (commonSourceTextBox.Text == "" || sourceTextBox.Text == "")
            {
                commonSourceTextBox.Text = "dif";
                sourceTextBox.Text = "dif " + DateTime.Now.Month.ToString();
            }

                File.WriteAllText(DM.fileToAnalizePath, textToReadRichBox.Text, Encoding.UTF8);
            addWordsFromTextButton_Click(null, null);
            beautifyButton_Click(null, null);
        }

        private void button3Kana_Click(object sender, EventArgs e)
        {
            string textToAnalyze = FileSaver.ReadTextToAnalize();
            if (textToAnalyze == "")
            {
                MessageBox.Show("Файл " + DM.fileToAnalizePath + " не найден");
                return;
            }

            List<Word> dict1 = new List<Word>();
            List<Word> ready = new List<Word>();
            foreach (var item in textToAnalyze)
            {
                if (item != ' ' && item != '.' && !kana.Contains(item) && item != '\r' && item != '\n' && item != '!' && item != '?')
                    dict1.Add(new Word(item.ToString()));
            }

            foreach (var word in dict1)
            {
                if(cont(word.word,ready))
                {
                    int i = ind(word.word,ready);
                    if(i>-1)
                    {
                        ready[i].freq += 1;
                    }
                }
                else
                    ready.Add(word);
            }
            
            string str = "";
            foreach (var item in ready)
            {
                str+= item.word  + "\t" + item.freq + "\r";
            }
            File.WriteAllText(@"C:\3\jpn.txt", str);

            string text = File.ReadAllText(@"C:\3\1.txt");
            text = text.Replace("\r", "<br>");

            foreach (var item in used)
            {
                text = text.Replace(item.ToString(), "<strong style='color:red;'>" + item.ToString() + "</strong>");
            }
            File.WriteAllText(@"C:\3\ready.html", text);
        }

        private bool cont(string w,List<Word> wl)
        {
            foreach (var item in wl)
            {
                if (item.word ==w)
                    return true;
            }
            return false;
        }
        private int ind(string w, List<Word> wl)
        {
            int cnt = 0;
            foreach (var item in wl)
            {
                if (item.word == w)
                    return cnt;
                cnt++;
            }
            return -1;
        }
        string get_ascii_code(string convertme)
        {
            Encoding ascii = Encoding.Unicode;
            Byte[] encodedBytes = ascii.GetBytes(convertme);
            string temp = "";
            char[] c = Encoding.GetEncoding(1251).GetChars(encodedBytes);
            foreach (var item in c)
            {
                temp = String.Concat(temp, "[" + item + "]");
            }
           
            
            return temp;
        }

        private void translateText_ButtonClick(object sender, EventArgs e)
        {
            /*Translator trans = new Translator();
            string tr = trans.GetOxfordDefinition("dangle");
            File.WriteAllText(@"C:\gg.txt", tr);*/
            
            InitDictionaryManagerPaths();
            if (commonSourceTextBox.Text == "" || sourceTextBox.Text == "")
            {
                MessageBox.Show("Не заполнены поля источники");
                return;
            }
            string textToAnalyze = FileSaver.ReadTextToAnalize();
            if (textToAnalyze == "")
            {
                MessageBox.Show("Файл " + DM.fileToAnalizePath + " не найден");
                return;
            }
            string pathToExcel = FileSaver.OpenExcelFile();
            if (DM.PathToExcel == "")
            {
                MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                return;
            }

            if (excelApp == null)
            {
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }
            Translator trans = new Translator();

            List<string> existedWords = excelApp.GetColumn(DM.Columns.word);                    

            for (int j = 23000; j < 23890; j++)//existedWords.Count
            {
                //1000000000
                for (double i = 0; i < 1000000000; i++)
                {
                    var x = 0;
                    var y = 2;
                    var h = x * y / 2;
                }

                Text = j.ToString();
                try
                {
                    string word = existedWords[j];
                    string tr = trans.GetOxfordDefinition(word);
                    excelApp.SetValue(DM.Columns.definition, j + 2, tr);
                }
                catch (Exception ee)
                {
                    File.AppendAllText(@"C:\111.txt", j.ToString() + "  " + ee.Message + "\n");
                }
                
            }
            excelApp.makeVisible();
        }

        private void beautifySubs_Click(object sender, EventArgs e)
        {
            InitDictionaryManagerPaths();
            if (excelApp == null)
            {
                string pathToExcel = FileSaver.OpenExcelFile();
                if (pathToExcel == "")
                {
                    MessageBox.Show("Файл " + DM.PathToExcel + " не найден");
                    return;
                }
                excelApp = new ExcelManager();
                excelApp.Open(DM.PathToExcel);
            }
            var pathSubs = @"C:\3\subs.srt";
            string text = File.ReadAllText(pathSubs, Encoding.UTF8);

            if (text == "")
            {
                MessageBox.Show("Файл " + DM.fileToAnalizePath + " не найден");
                return;
            }

            WordsFormer allWords = new WordsFormer();
            allWords.analyzeAll(text);

            List<string> lWords = excelApp.GetColumn(DM.Columns.word);
            List<string> lLvl = excelApp.GetColumn(DM.Columns.level);
            List<string> lSrs = excelApp.GetColumn(DM.Columns.src);

           




            for (int i = 0; i < allWords.dict.Count; i++)
            {
                string word = allWords.dict[i].word;
                Stylizer st = new Stylizer();
                this.Text = i.ToString();

                int ind = lWords.IndexOf(word);
                if (ind < 0) continue;
                string sign;


                if (lLvl[ind] == "0")
                {
                    if (lSrs[ind] == sourceTextBox.Text)
                        sign = " * ";
                    else
                        sign = " + ";

                    int tIndex = text.IndexOf(word, StringComparison.CurrentCultureIgnoreCase);
                    if (tIndex < 0)
                        continue;
                    do
                    {
                        if (st.IsComplete(word, text, tIndex))
                        {
                            text = text.Insert(tIndex, sign);
                            text = text.Insert(tIndex + sign.Length + word.Length, sign);
                        }
                        tIndex = text.IndexOf(word, tIndex + sign.Length + word.Length + 2, StringComparison.CurrentCultureIgnoreCase);

                    } while (tIndex > 0);
                }
            }

            File.WriteAllText(@"C:\3\subs2.srt", text);

            
            bool isOnlyNewWords = true;

            if (isOnlyNewWords)
            {
                var lines = File.ReadAllLines(@"C:\3\subs2.srt", Encoding.UTF8).ToList();
                List<string> resLines = new List<string>();
                

                for (int i = 0; i < lines.Count; i++)
                {
                    bool containsNewWords = lines[i].Contains("*") || lines[i].Contains("+");

                    if (containsNewWords)
                    {
                        int st = findStart(lines, i);
                        int end = findEnd(lines, i);
                        for (int k = st; k <= end; k++)
                        {
                            resLines.Add(lines[k]);
                        }
                        i = end;
                    }
                }
                File.WriteAllLines(@"C:\3\subs23.srt", resLines);
            }

            beautifyButton_Click(null, null);
            /*
            excelApp.Quit();
            Application.Exit();*/
        }

        
        private int findStart(List<string> lines, int i)
        {
            for (int j = i - 1; j >= 0; j--)
            {
                if (lines[j].Contains("-->"))
                    return j - 1;
            }
            return 0;
        }
        private int findEnd(List<string> lines, int i)
        {
            for (int j = i + 1; j < lines.Count; j++)
            {
                if (lines[j].Contains("-->"))
                    return j - 2;
            }
            return lines.Count - 1;
        }

    }
}


