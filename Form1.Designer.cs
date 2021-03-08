
namespace LearnThePrimesWinForm
{
    partial class Form1
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
            this.guessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.enterBtn = new System.Windows.Forms.Button();
            this.primeNrLbl = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.remainingGuessesBar1 = new System.Windows.Forms.ProgressBar();
            this.remainingGuessesBar2 = new System.Windows.Forms.ProgressBar();
            this.remainingGuessesBar3 = new System.Windows.Forms.ProgressBar();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.helpBtn = new System.Windows.Forms.Button();
            this.primeWikiLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.guessNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // guessNumericUpDown
            // 
            this.guessNumericUpDown.Location = new System.Drawing.Point(186, 51);
            this.guessNumericUpDown.Name = "guessNumericUpDown";
            this.guessNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.guessNumericUpDown.TabIndex = 0;
            // 
            // enterBtn
            // 
            this.enterBtn.Location = new System.Drawing.Point(206, 90);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(75, 23);
            this.enterBtn.TabIndex = 1;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.enterBtn_Click);
            // 
            // primeNrLbl
            // 
            this.primeNrLbl.AutoSize = true;
            this.primeNrLbl.Location = new System.Drawing.Point(197, 127);
            this.primeNrLbl.Name = "primeNrLbl";
            this.primeNrLbl.Size = new System.Drawing.Size(57, 13);
            this.primeNrLbl.TabIndex = 2;
            this.primeNrLbl.Text = "Prime nr: 0";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(30, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 199);
            this.listBox1.TabIndex = 3;
            // 
            // remainingGuessesBar1
            // 
            this.remainingGuessesBar1.Location = new System.Drawing.Point(203, 170);
            this.remainingGuessesBar1.Name = "remainingGuessesBar1";
            this.remainingGuessesBar1.Size = new System.Drawing.Size(22, 62);
            this.remainingGuessesBar1.TabIndex = 4;
            // 
            // remainingGuessesBar2
            // 
            this.remainingGuessesBar2.Location = new System.Drawing.Point(232, 170);
            this.remainingGuessesBar2.Name = "remainingGuessesBar2";
            this.remainingGuessesBar2.Size = new System.Drawing.Size(22, 62);
            this.remainingGuessesBar2.TabIndex = 5;
            // 
            // remainingGuessesBar3
            // 
            this.remainingGuessesBar3.Location = new System.Drawing.Point(259, 170);
            this.remainingGuessesBar3.Name = "remainingGuessesBar3";
            this.remainingGuessesBar3.Size = new System.Drawing.Size(22, 62);
            this.remainingGuessesBar3.TabIndex = 6;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.AutoSize = true;
            this.highScoreLabel.Location = new System.Drawing.Point(197, 144);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(67, 13);
            this.highScoreLabel.TabIndex = 7;
            this.highScoreLabel.Text = "Highscore: 0";
            // 
            // helpBtn
            // 
            this.helpBtn.Location = new System.Drawing.Point(30, 241);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(75, 23);
            this.helpBtn.TabIndex = 8;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = true;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // primeWikiLinkLabel
            // 
            this.primeWikiLinkLabel.AutoSize = true;
            this.primeWikiLinkLabel.Location = new System.Drawing.Point(111, 246);
            this.primeWikiLinkLabel.Name = "primeWikiLinkLabel";
            this.primeWikiLinkLabel.Size = new System.Drawing.Size(128, 13);
            this.primeWikiLinkLabel.TabIndex = 9;
            this.primeWikiLinkLabel.TabStop = true;
            this.primeWikiLinkLabel.Text = "Prime Numbers Wikipedia";
            this.primeWikiLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.primeWikiLinkLabel_LinkClicked);
            // 
            // Form1
            // 
            this.AcceptButton = this.enterBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 276);
            this.Controls.Add(this.primeWikiLinkLabel);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.remainingGuessesBar3);
            this.Controls.Add(this.remainingGuessesBar2);
            this.Controls.Add(this.remainingGuessesBar1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.primeNrLbl);
            this.Controls.Add(this.enterBtn);
            this.Controls.Add(this.guessNumericUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Learn the Primes";
            ((System.ComponentModel.ISupportInitialize)(this.guessNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown guessNumericUpDown;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Label primeNrLbl;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ProgressBar remainingGuessesBar1;
        private System.Windows.Forms.ProgressBar remainingGuessesBar2;
        private System.Windows.Forms.ProgressBar remainingGuessesBar3;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.LinkLabel primeWikiLinkLabel;
    }
}

