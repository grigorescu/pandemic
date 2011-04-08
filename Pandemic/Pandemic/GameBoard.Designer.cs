
namespace Pandemic
{
    partial class GameBoard
    {
        //objects (pictures boxes)
        private System.Windows.Forms.PictureBox board;

       
        
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.board = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nextActButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.Image = ((System.Drawing.Image)(resources.GetObject("board.Image")));
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(938, 680);
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            this.board.Click += new System.EventHandler(this.board_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(264, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // nextActButton
            // 
            this.nextActButton.Location = new System.Drawing.Point(838, 576);
            this.nextActButton.Name = "nextActButton";
            this.nextActButton.Size = new System.Drawing.Size(89, 83);
            this.nextActButton.TabIndex = 6;
            this.nextActButton.Text = "NEXT ACTION!";
            this.nextActButton.UseVisualStyleBackColor = true;
            this.nextActButton.Click += new System.EventHandler(this.nextActButton_Click);
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 660);
            this.Controls.Add(this.nextActButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.board);
            this.Name = "GameBoard";
            this.Text = "Pandemic!";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button nextActButton;

        
        
    }
}

