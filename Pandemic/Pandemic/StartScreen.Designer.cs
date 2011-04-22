namespace Pandemic
{
    partial class StartScreen
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
            this.easyButton = new System.Windows.Forms.RadioButton();
            this.mediumButton = new System.Windows.Forms.RadioButton();
            this.hardButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.playerType = new System.Windows.Forms.PictureBox();
            this.startGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.playerType)).BeginInit();
            this.SuspendLayout();
            // 
            // easyButton
            // 
            this.easyButton.AutoSize = true;
            this.easyButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.easyButton.Location = new System.Drawing.Point(31, 131);
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(79, 17);
            this.easyButton.TabIndex = 0;
            this.easyButton.TabStop = true;
            this.easyButton.Text = "Easy Game";
            this.easyButton.UseVisualStyleBackColor = true;
            // 
            // mediumButton
            // 
            this.mediumButton.AutoSize = true;
            this.mediumButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.mediumButton.Location = new System.Drawing.Point(31, 154);
            this.mediumButton.Name = "mediumButton";
            this.mediumButton.Size = new System.Drawing.Size(93, 17);
            this.mediumButton.TabIndex = 1;
            this.mediumButton.TabStop = true;
            this.mediumButton.Text = "Medium Game";
            this.mediumButton.UseVisualStyleBackColor = true;
            // 
            // hardButton
            // 
            this.hardButton.AutoSize = true;
            this.hardButton.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.hardButton.Location = new System.Drawing.Point(31, 177);
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(79, 17);
            this.hardButton.TabIndex = 2;
            this.hardButton.TabStop = true;
            this.hardButton.Text = "Hard Game";
            this.hardButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Location = new System.Drawing.Point(28, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Please choose a difficulty level:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(57, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(392, 37);
            this.label2.TabIndex = 4;
            this.label2.Text = "Welcome to PANDEMIC!";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(28, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "You will play as the...";
            // 
            // playerType
            // 
            this.playerType.Location = new System.Drawing.Point(31, 275);
            this.playerType.Name = "playerType";
            this.playerType.Size = new System.Drawing.Size(163, 171);
            this.playerType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.playerType.TabIndex = 6;
            this.playerType.TabStop = false;
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(389, 275);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(116, 51);
            this.startGame.TabIndex = 7;
            this.startGame.Text = "Start Game";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // StartScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(529, 703);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.playerType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hardButton);
            this.Controls.Add(this.mediumButton);
            this.Controls.Add(this.easyButton);
            this.Name = "StartScreen";
            this.Text = "Pandemic!";
            ((System.ComponentModel.ISupportInitialize)(this.playerType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton easyButton;
        private System.Windows.Forms.RadioButton mediumButton;
        private System.Windows.Forms.RadioButton hardButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox playerType;
        private System.Windows.Forms.Button startGame;
    }
}