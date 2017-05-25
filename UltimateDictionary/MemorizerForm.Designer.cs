namespace UltimateDictionary
{
    partial class MemorizerForm
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
            this.grid = new System.Windows.Forms.DataGridView();
            this.word = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.show = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.tag2Button = new System.Windows.Forms.Button();
            this.tag1Button = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.tillTextBox = new System.Windows.Forms.TextBox();
            this.minFreqTextBox = new System.Windows.Forms.TextBox();
            this.rangeTextBox = new System.Windows.Forms.TextBox();
            this.wordLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maxRndTextBox = new System.Windows.Forms.TextBox();
            this.unknownRadioButton = new System.Windows.Forms.RadioButton();
            this.studiedRadioButton = new System.Windows.Forms.RadioButton();
            this.skipButton = new System.Windows.Forms.Button();
            this.fogottenRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rightLabel = new System.Windows.Forms.Label();
            this.showLabel = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.tag3Button = new System.Windows.Forms.Button();
            this.toDictionaryButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.word,
            this.right,
            this.show});
            this.grid.Location = new System.Drawing.Point(816, 12);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.Size = new System.Drawing.Size(320, 730);
            this.grid.TabIndex = 0;
            // 
            // word
            // 
            this.word.HeaderText = "Word";
            this.word.Name = "word";
            this.word.ReadOnly = true;
            this.word.Width = 200;
            // 
            // right
            // 
            this.right.HeaderText = "Right";
            this.right.Name = "right";
            this.right.ReadOnly = true;
            this.right.Width = 50;
            // 
            // show
            // 
            this.show.HeaderText = "Show";
            this.show.Name = "show";
            this.show.ReadOnly = true;
            this.show.Width = 50;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(235, 207);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 1;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // showButton
            // 
            this.showButton.Location = new System.Drawing.Point(340, 207);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(75, 23);
            this.showButton.TabIndex = 2;
            this.showButton.Text = "Show";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // tag2Button
            // 
            this.tag2Button.Location = new System.Drawing.Point(210, 141);
            this.tag2Button.Name = "tag2Button";
            this.tag2Button.Size = new System.Drawing.Size(75, 23);
            this.tag2Button.TabIndex = 3;
            this.tag2Button.Text = "tag2";
            this.tag2Button.UseVisualStyleBackColor = true;
            this.tag2Button.Click += new System.EventHandler(this.tag2Button_Click);
            // 
            // tag1Button
            // 
            this.tag1Button.Location = new System.Drawing.Point(291, 141);
            this.tag1Button.Name = "tag1Button";
            this.tag1Button.Size = new System.Drawing.Size(75, 23);
            this.tag1Button.TabIndex = 4;
            this.tag1Button.Text = "tag1";
            this.tag1Button.UseVisualStyleBackColor = true;
            this.tag1Button.Click += new System.EventHandler(this.tag1Button_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 272);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(798, 470);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(683, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Till";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(683, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Min frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Range";
            // 
            // fromTextBox
            // 
            this.fromTextBox.Location = new System.Drawing.Point(775, 11);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(35, 20);
            this.fromTextBox.TabIndex = 10;
            this.fromTextBox.Text = "2";
            // 
            // tillTextBox
            // 
            this.tillTextBox.Location = new System.Drawing.Point(775, 37);
            this.tillTextBox.Name = "tillTextBox";
            this.tillTextBox.Size = new System.Drawing.Size(35, 20);
            this.tillTextBox.TabIndex = 10;
            // 
            // minFreqTextBox
            // 
            this.minFreqTextBox.Location = new System.Drawing.Point(775, 63);
            this.minFreqTextBox.Name = "minFreqTextBox";
            this.minFreqTextBox.Size = new System.Drawing.Size(35, 20);
            this.minFreqTextBox.TabIndex = 10;
            this.minFreqTextBox.Text = "5";
            // 
            // rangeTextBox
            // 
            this.rangeTextBox.Location = new System.Drawing.Point(775, 89);
            this.rangeTextBox.Name = "rangeTextBox";
            this.rangeTextBox.Size = new System.Drawing.Size(35, 20);
            this.rangeTextBox.TabIndex = 10;
            this.rangeTextBox.Text = "5";
            // 
            // wordLabel
            // 
            this.wordLabel.AutoSize = true;
            this.wordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordLabel.Location = new System.Drawing.Point(272, 54);
            this.wordLabel.Name = "wordLabel";
            this.wordLabel.Size = new System.Drawing.Size(127, 29);
            this.wordLabel.TabIndex = 11;
            this.wordLabel.Text = "wordLabel";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(683, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "max rnd words";
            // 
            // maxRndTextBox
            // 
            this.maxRndTextBox.Location = new System.Drawing.Point(775, 115);
            this.maxRndTextBox.Name = "maxRndTextBox";
            this.maxRndTextBox.Size = new System.Drawing.Size(35, 20);
            this.maxRndTextBox.TabIndex = 13;
            this.maxRndTextBox.Text = "20";
            // 
            // unknownRadioButton
            // 
            this.unknownRadioButton.AutoSize = true;
            this.unknownRadioButton.Checked = true;
            this.unknownRadioButton.Location = new System.Drawing.Point(18, 14);
            this.unknownRadioButton.Name = "unknownRadioButton";
            this.unknownRadioButton.Size = new System.Drawing.Size(31, 17);
            this.unknownRadioButton.TabIndex = 14;
            this.unknownRadioButton.TabStop = true;
            this.unknownRadioButton.Text = "0";
            this.unknownRadioButton.UseVisualStyleBackColor = true;
            // 
            // studiedRadioButton
            // 
            this.studiedRadioButton.AutoSize = true;
            this.studiedRadioButton.Location = new System.Drawing.Point(18, 55);
            this.studiedRadioButton.Name = "studiedRadioButton";
            this.studiedRadioButton.Size = new System.Drawing.Size(31, 17);
            this.studiedRadioButton.TabIndex = 15;
            this.studiedRadioButton.Text = "2";
            this.studiedRadioButton.UseVisualStyleBackColor = true;
            // 
            // skipButton
            // 
            this.skipButton.Location = new System.Drawing.Point(290, 236);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(75, 23);
            this.skipButton.TabIndex = 16;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // fogottenRadioButton
            // 
            this.fogottenRadioButton.AutoSize = true;
            this.fogottenRadioButton.Location = new System.Drawing.Point(18, 35);
            this.fogottenRadioButton.Name = "fogottenRadioButton";
            this.fogottenRadioButton.Size = new System.Drawing.Size(31, 17);
            this.fogottenRadioButton.TabIndex = 17;
            this.fogottenRadioButton.Text = "1";
            this.fogottenRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.unknownRadioButton);
            this.panel1.Controls.Add(this.fogottenRadioButton);
            this.panel1.Controls.Add(this.studiedRadioButton);
            this.panel1.Location = new System.Drawing.Point(681, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(129, 96);
            this.panel1.TabIndex = 18;
            // 
            // rightLabel
            // 
            this.rightLabel.AutoSize = true;
            this.rightLabel.Location = new System.Drawing.Point(237, 234);
            this.rightLabel.Name = "rightLabel";
            this.rightLabel.Size = new System.Drawing.Size(27, 13);
            this.rightLabel.TabIndex = 19;
            this.rightLabel.Text = "right";
            // 
            // showLabel
            // 
            this.showLabel.AutoSize = true;
            this.showLabel.Location = new System.Drawing.Point(380, 233);
            this.showLabel.Name = "showLabel";
            this.showLabel.Size = new System.Drawing.Size(32, 13);
            this.showLabel.TabIndex = 20;
            this.showLabel.Text = "show";
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.loadButton.Location = new System.Drawing.Point(710, 243);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 21;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // tag3Button
            // 
            this.tag3Button.Location = new System.Drawing.Point(372, 141);
            this.tag3Button.Name = "tag3Button";
            this.tag3Button.Size = new System.Drawing.Size(75, 23);
            this.tag3Button.TabIndex = 22;
            this.tag3Button.Text = "tag 3";
            this.tag3Button.UseVisualStyleBackColor = true;
            this.tag3Button.Click += new System.EventHandler(this.tag3Button_Click);
            // 
            // toDictionaryButton
            // 
            this.toDictionaryButton.Location = new System.Drawing.Point(12, 1);
            this.toDictionaryButton.Name = "toDictionaryButton";
            this.toDictionaryButton.Size = new System.Drawing.Size(75, 23);
            this.toDictionaryButton.TabIndex = 23;
            this.toDictionaryButton.Text = "<=Dictionary";
            this.toDictionaryButton.UseVisualStyleBackColor = true;
            this.toDictionaryButton.Click += new System.EventHandler(this.toDictionaryButton_Click);
            // 
            // MemorizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 763);
            this.Controls.Add(this.toDictionaryButton);
            this.Controls.Add(this.tag3Button);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.showLabel);
            this.Controls.Add(this.rightLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.maxRndTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.wordLabel);
            this.Controls.Add(this.rangeTextBox);
            this.Controls.Add(this.minFreqTextBox);
            this.Controls.Add(this.tillTextBox);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tag1Button);
            this.Controls.Add(this.tag2Button);
            this.Controls.Add(this.showButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.grid);
            this.Name = "MemorizerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MemorizerForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MemorizerForm_FormClosing);
            this.Load += new System.EventHandler(this.MemorizerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn word;
        private System.Windows.Forms.DataGridViewTextBoxColumn right;
        private System.Windows.Forms.DataGridViewTextBoxColumn show;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button tag2Button;
        private System.Windows.Forms.Button tag1Button;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.TextBox tillTextBox;
        private System.Windows.Forms.TextBox minFreqTextBox;
        private System.Windows.Forms.TextBox rangeTextBox;
        private System.Windows.Forms.Label wordLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox maxRndTextBox;
        private System.Windows.Forms.RadioButton unknownRadioButton;
        private System.Windows.Forms.RadioButton studiedRadioButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.RadioButton fogottenRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label rightLabel;
        private System.Windows.Forms.Label showLabel;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button tag3Button;
        private System.Windows.Forms.Button toDictionaryButton;
    }
}