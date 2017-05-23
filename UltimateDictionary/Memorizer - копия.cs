using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateDictionary
{
    public partial class Memorizer : Form
    {
        public Memorizer()
        {
            InitializeComponent();
        }

        private void Memorizer_Load(object sender, EventArgs e)
        {

        }
        private void fillGrid()
        {
            dataGridView1.RowCount = 1;
            foreach (var item in study)
            {
                dataGridView1.RowCount++;
                //dataGridView1[0, dataGridView1.RowCount - 2].Value = (dataGridView1.RowCount-2).ToString();
                dataGridView1[0, dataGridView1.RowCount - 2].Value = item.index;
                dataGridView1[1, dataGridView1.RowCount - 2].Value = item.word;
                dataGridView1[2, dataGridView1.RowCount - 2].Value = item.right;
                dataGridView1[3, dataGridView1.RowCount - 2].Value = item.show;
            }
        }
        private void updateGrid(int i)
        {
            dataGridView1[2, i].Value = study[i].right;
            dataGridView1[3, i].Value = study[i].show;
        }

        private void loadButton_Click(object sender, EventArgs e)//load
        {
            if (excelapp == null)
            {
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelapp.Workbooks.Open(PathToExcel);
                excelworksheet = excelapp.Workbooks[1].Worksheets[1];
                excelapp.Visible = false;
                excelapp.DisplayAlerts = false;
            }

            t1 = DateTime.Now;
            from = Convert.ToInt32(fromTextBox.Text);
            till = Convert.ToInt32(tillTextBox.Text);
            startLoad = Convert.ToInt32(startLoadTextBox.Text);
            int lastRow = excelworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            study = new List<StudyWords>();
            int count = 0;

            object[,] cellValues = (object[,])excelworksheet.get_Range("A2", "A" + lastRow.ToString()).Cells.Value2;
            lWords = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));

            if (startLoad < 2) startLoad = 2;
            bool condition;
            int minFrequency = Convert.ToInt16(minFrequencyTextbox.Text);

            for (int i = startLoad; count < 51 && i < lastRow; i++)
            {
                //getCell(i, 3) != "3" && getCell(i, 3) != "2" && getCell(i, 2) != "1" && getCell(i, 2) != "2"// новые, чаще чем 2 раза
                //getCell(i, 3) == "2" // уже выученные
                if (checkBox1.Checked)//looking for twos
                    condition = getCell(i, 3) == "2";
                else
                    condition = (Convert.ToInt16(getCell(i, 3)) < 2 && Convert.ToInt16(getCell(i, 2)) > minFrequency);//

                if (condition)
                {
                    study.Add(new StudyWords(getCell(i, 1), i.ToString(), getCell(i, 8) + ", " + getCell(i, 9) + ", " + getCell(i, 10)));
                    for (int j = 0; j < 20; j++)
                    {
                        if (getCell(i, j + 14) != "")
                            study[count].AddEx(getCell(i, j + 14));
                    }
                    count++;
                }
                Text = i.ToString() + " Слов " + study.Count.ToString();
            }

            if (study.Count == 0)
                return;

            fillGrid();

            if (till > study.Count) till = study.Count;
            Random rnd = new Random();
            int r = rnd.Next(from, till);
            wordToStudyLabel.Text = study[r].word;
            rightLabel.Text = study[r].right.ToString();
            showLabel.Text = study[r].show.ToString();

            Text = "Выучено слов " + LearnedWords.ToString();
            richTextBox1.Focus();
        }

        private void knowButton_Click(object sender, EventArgs e)//know
        {
            if (till == 0 || study.Count == 0) return;

            int i = study.FindIndex(x => x.word == wordToStudyLabel.Text);

            if (richTextBox1.Text == "" && i >= 0)
            {
                study[i].increaseRight();
                updateGrid(i);
            }
            richTextBox1.Text = "";
            knowButton.Text = "know";
            answerLabel.Text = "";

            if (till > study.Count) till = study.Count;

            Random rnd = new Random();
            int r = rnd.Next(from, till);
            wordToStudyLabel.Text = study[r].word;
            rightLabel.Text = study[r].right.ToString();
            showLabel.Text = study[r].show.ToString();
        }

        private void showButton_Click(object sender, EventArgs e)//show
        {
            int i = study.FindIndex(x => x.word == wordToStudyLabel.Text);
            if (richTextBox1.Text == "")
                study[i].increaseShow();

            knowButton.Text = "Next";
            showLabel.Text = study[i].show.ToString();

            answerLabel.Text = study[i].translate;
            richTextBox1.Text = "";
            foreach (var ex in study[i].examples)
            {
                richTextBox1.Text += ex + "\r\r";
            }
            updateGrid(i);
        }
        private void tagTwoButton_Click(object sender, EventArgs e)//tag
        {
            int i = study.FindIndex(x => x.word == wordToStudyLabel.Text);

            study.RemoveAt(i);

            i = lWords.IndexOf(wordToStudyLabel.Text) + 2;
            excelworksheet.get_Range("C" + i.ToString()).Value2 = "2";
            excelapp.Workbooks[1].Save();
            File.AppendAllText(@"C:\3\log\taging.txt", '\r' + wordToStudyLabel.Text + "\t" + "2" + "\t" + DateTime.Today.ToShortDateString());

            fillGrid();
            knowButton_Click(sender, null);
            richTextBox1.Focus();

            LearnedWords++;
            var g = DateTime.Now.Subtract(t1).TotalSeconds;
            var y = g / LearnedWords;
            var span = y.ToString();

            Text = "Выучено слов " + LearnedWords.ToString() + ", слово за " + span;
        }
        private void skipButton_Click(object sender, EventArgs e)//skip
        {
            int i = study.FindIndex(x => x.word == wordToStudyLabel.Text);

            study.RemoveAt(i);
            fillGrid();

            knowButton_Click(sender, null);
            richTextBox1.Focus();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                knowButton_Click(sender, null);
            if (e.KeyCode == Keys.Right)
                showButton_Click(sender, null);
            if (e.KeyCode == Keys.NumPad2)
                tagTwoButton_Click(sender, null);
            if (e.KeyCode == Keys.NumPad1)
                tagOneButton_Click(sender, null);
            if (e.KeyCode == Keys.NumPad8)
                skipButton_Click(sender, null);
        }

        private void fromTextBox_TextChanged(object sender, EventArgs e)
        {
            from = Convert.ToInt32(fromTextBox.Text);
        }

        private void tillTextBox_TextChanged(object sender, EventArgs e)
        {
            till = Convert.ToInt32(tillTextBox.Text);
            if (study != null && till > study.Count - 1)
                till = study.Count - 1;
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (excelapp != null)
            {
                excelapp.Workbooks.Close();
                excelapp.Quit();
            }
        }

        private void startLoadTextBox_TextChanged(object sender, EventArgs e)
        {
            startLoad = Convert.ToInt32(startLoadTextBox.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //endLoad = Convert.ToInt32(textBox8.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var s = File.ReadAllLines(@"C:\3\subs.srt");
            List<string> lines = new List<string>();
            foreach (var line in s)
                if (line.Length > 0 && !Char.IsDigit(line[0]) && !line.Contains("-->") && !(line.Length < 3))
                    lines.Add(line);
            File.WriteAllLines(@"C:\3\1.txt", lines);

        }
        //---------------------------------------------------------------------


       

        private void button9_Click(object sender, EventArgs e)
        {
            if (excelapp == null)
            {
                excelapp = new Excel.Application();
                excelapp.Visible = true;
                excelapp.Workbooks.Open(PathToExcel);
                excelworksheet = excelapp.Workbooks[1].Worksheets[1];
                excelapp.Visible = false;
                excelapp.DisplayAlerts = false;
            }

            int lastRow = excelworksheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row;
            var text = File.ReadAllText(@"C:\3\subs.srt", Encoding.GetEncoding("windows-1251"));
            //making text to read

            object[,] cellValues = (object[,])excelworksheet.get_Range("A2", "A" + lastRow.ToString()).Cells.Value2;
            List<string> lWords = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
            cellValues = (object[,])excelworksheet.get_Range("C2", "C" + lastRow.ToString()).Cells.Value2;
            List<string> lLvl = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
            cellValues = (object[,])excelworksheet.get_Range("K2", "K" + lastRow.ToString()).Cells.Value2;
            List<string> lSrs = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
            cellValues = (object[,])excelworksheet.get_Range("H2", "H" + lastRow.ToString()).Cells.Value2;

            for (int i = 0; i < lWords.Count; i++)
            {
                string word = lWords[i];
                if (text.IndexOf(word, StringComparison.CurrentCultureIgnoreCase) == -1)
                    continue;

                if (lSrs[i] == sourceTextBox.Text && lLvl[i] == "0")
                    for (int j = text.IndexOf(word, StringComparison.CurrentCultureIgnoreCase); j >= 0; j = text.IndexOf(word, j + (" * ").Length + 1, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (isComplete(word, text, j))
                        {
                            text = text.Insert(j, " * ");
                            text = text.Insert(j + " * ".Length + word.Length, " * ");
                        }
                    }

            }

            File.WriteAllText(@"C:\3\subs2.srt", text, Encoding.UTF8);

            excelapp.Workbooks.Close();
            excelapp.Quit();
            Application.Exit();
        }

        private void tagOneButton_Click(object sender, EventArgs e)
        {
            int i = study.FindIndex(x => x.word == wordToStudyLabel.Text);

            study.RemoveAt(i);

            i = lWords.IndexOf(wordToStudyLabel.Text) + 2;
            excelworksheet.get_Range("C" + i.ToString()).Value2 = "1";
            excelapp.Workbooks[1].Save();
            File.AppendAllText(@"C:\3\log\taging.txt", '\r' + wordToStudyLabel.Text + "\t" + "1" + "\t" + DateTime.Today.ToShortDateString());

            fillGrid();
            knowButton_Click(sender, null);
            richTextBox1.Focus();
        }

    }
}
