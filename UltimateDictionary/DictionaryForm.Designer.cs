namespace UltimateDictionary
{
    partial class DictionaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.commonSourceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileToAnalizePathTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.excelPathTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.workingDirTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.sourseListBox = new System.Windows.Forms.ListBox();
            this.SubTo1Button = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.memorizerButton = new System.Windows.Forms.Button();
            this.addSourseTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(41, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(210, 79);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add words from txt";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.addWordsFromTextButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Откуда (область)";
            // 
            // commonSourceTextBox
            // 
            this.commonSourceTextBox.Location = new System.Drawing.Point(289, 64);
            this.commonSourceTextBox.Name = "commonSourceTextBox";
            this.commonSourceTextBox.Size = new System.Drawing.Size(130, 20);
            this.commonSourceTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(451, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Источник";
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(454, 64);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(130, 20);
            this.sourceTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Путь к разбираемому файлу";
            // 
            // fileToAnalizePathTextBox
            // 
            this.fileToAnalizePathTextBox.Location = new System.Drawing.Point(454, 121);
            this.fileToAnalizePathTextBox.Name = "fileToAnalizePathTextBox";
            this.fileToAnalizePathTextBox.Size = new System.Drawing.Size(242, 20);
            this.fileToAnalizePathTextBox.TabIndex = 6;
            this.fileToAnalizePathTextBox.Text = "C:\\3\\1.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Путь к Excel файлу";
            // 
            // excelPathTextBox
            // 
            this.excelPathTextBox.Location = new System.Drawing.Point(454, 158);
            this.excelPathTextBox.Name = "excelPathTextBox";
            this.excelPathTextBox.Size = new System.Drawing.Size(242, 20);
            this.excelPathTextBox.TabIndex = 6;
            this.excelPathTextBox.Text = "C:\\3\\UltimateDictionary.xlsx";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(451, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Рабочая директория";
            // 
            // workingDirTextBox
            // 
            this.workingDirTextBox.Location = new System.Drawing.Point(454, 198);
            this.workingDirTextBox.Name = "workingDirTextBox";
            this.workingDirTextBox.Size = new System.Drawing.Size(242, 20);
            this.workingDirTextBox.TabIndex = 6;
            this.workingDirTextBox.Text = "C:\\3\\";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Bisque;
            this.button2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(43, 125);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 58);
            this.button2.TabIndex = 7;
            this.button2.Text = "Beautify text";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.beautifyButton_Click);
            // 
            // sourseListBox
            // 
            this.sourseListBox.FormattingEnabled = true;
            this.sourseListBox.Items.AddRange(new object[] {
            "Unity",
            "Catcher",
            "Spectre",
            "Movie"});
            this.sourseListBox.Location = new System.Drawing.Point(289, 125);
            this.sourseListBox.Name = "sourseListBox";
            this.sourseListBox.Size = new System.Drawing.Size(120, 95);
            this.sourseListBox.TabIndex = 8;
            this.sourseListBox.SelectedIndexChanged += new System.EventHandler(this.sourseListBox_SelectedIndexChanged);
            this.sourseListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sourseListBox_KeyDown);
            // 
            // SubTo1Button
            // 
            this.SubTo1Button.Location = new System.Drawing.Point(537, 244);
            this.SubTo1Button.Name = "SubTo1Button";
            this.SubTo1Button.Size = new System.Drawing.Size(75, 23);
            this.SubTo1Button.TabIndex = 21;
            this.SubTo1Button.Text = "subs to 1.txt";
            this.SubTo1Button.UseVisualStyleBackColor = true;
            this.SubTo1Button.Click += new System.EventHandler(this.subsTo1_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(618, 244);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(78, 23);
            this.button9.TabIndex = 22;
            this.button9.Text = "beautify subs";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // memorizerButton
            // 
            this.memorizerButton.Location = new System.Drawing.Point(618, 12);
            this.memorizerButton.Name = "memorizerButton";
            this.memorizerButton.Size = new System.Drawing.Size(84, 23);
            this.memorizerButton.TabIndex = 26;
            this.memorizerButton.Text = "Memorizer=>";
            this.memorizerButton.UseVisualStyleBackColor = true;
            this.memorizerButton.Click += new System.EventHandler(this.StudyButton_Click);
            // 
            // addSourseTextBox
            // 
            this.addSourseTextBox.Location = new System.Drawing.Point(289, 226);
            this.addSourseTextBox.Name = "addSourseTextBox";
            this.addSourseTextBox.Size = new System.Drawing.Size(120, 20);
            this.addSourseTextBox.TabIndex = 27;
            this.addSourseTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.addSourseTextBox_KeyDown);
            // 
            // DictionaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(714, 274);
            this.Controls.Add(this.addSourseTextBox);
            this.Controls.Add(this.memorizerButton);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.SubTo1Button);
            this.Controls.Add(this.sourseListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.workingDirTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.excelPathTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileToAnalizePathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourceTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commonSourceTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "DictionaryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UltimateDictionary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DictionaryForm_FormClosing);
            this.Load += new System.EventHandler(this.DictionaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox commonSourceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox fileToAnalizePathTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox excelPathTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox workingDirTextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox sourseListBox;
        private System.Windows.Forms.Button SubTo1Button;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button memorizerButton;
        private System.Windows.Forms.TextBox addSourseTextBox;
    }
}

