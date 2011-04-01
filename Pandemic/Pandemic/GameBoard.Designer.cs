
namespace Pandemic
{
    partial class GameBoard
    {
        //objects (pictures boxes)
        private System.Windows.Forms.PictureBox board;
        public System.Windows.Forms.PictureBox newYorkBlue1;
        public System.Windows.Forms.PictureBox newYorkBlue2;
        public System.Windows.Forms.PictureBox newYorkBlue3;

       
        
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
            this.newYorkBlue1 = new System.Windows.Forms.PictureBox();
            this.newYorkBlue2 = new System.Windows.Forms.PictureBox();
            this.newYorkBlue3 = new System.Windows.Forms.PictureBox();
            this.newYorkStation = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkStation)).BeginInit();
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
            // 
            // newYorkBlue1
            // 
            this.newYorkBlue1.BackColor = System.Drawing.Color.Blue;
            this.newYorkBlue1.Location = new System.Drawing.Point(239, 227);
            this.newYorkBlue1.Name = "newYorkBlue1";
            this.newYorkBlue1.Size = new System.Drawing.Size(16, 17);
            this.newYorkBlue1.TabIndex = 1;
            this.newYorkBlue1.TabStop = false;
            this.newYorkBlue1.Visible = false;
            // 
            // newYorkBlue2
            // 
            this.newYorkBlue2.BackColor = System.Drawing.Color.Blue;
            this.newYorkBlue2.Location = new System.Drawing.Point(258, 227);
            this.newYorkBlue2.Name = "newYorkBlue2";
            this.newYorkBlue2.Size = new System.Drawing.Size(16, 17);
            this.newYorkBlue2.TabIndex = 2;
            this.newYorkBlue2.TabStop = false;
            this.newYorkBlue2.Visible = false;
            // 
            // newYorkBlue3
            // 
            this.newYorkBlue3.BackColor = System.Drawing.Color.Blue;
            this.newYorkBlue3.Location = new System.Drawing.Point(239, 248);
            this.newYorkBlue3.Name = "newYorkBlue3";
            this.newYorkBlue3.Size = new System.Drawing.Size(16, 17);
            this.newYorkBlue3.TabIndex = 3;
            this.newYorkBlue3.TabStop = false;
            this.newYorkBlue3.Visible = false;
            
            // 
            // newYorkStation
            // 
            this.newYorkStation.BackColor = System.Drawing.Color.Red;
            this.newYorkStation.Location = new System.Drawing.Point(256, 244);
            this.newYorkStation.Name = "newYorkStation";
            this.newYorkStation.Size = new System.Drawing.Size(27, 21);
            this.newYorkStation.TabIndex = 4;
            this.newYorkStation.TabStop = false;
            this.newYorkStation.Visible = false;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 660);
            this.Controls.Add(this.newYorkStation);
            this.Controls.Add(this.newYorkBlue3);
            this.Controls.Add(this.newYorkBlue2);
            this.Controls.Add(this.newYorkBlue1);
            this.Controls.Add(this.board);
            this.Name = "GameBoard";
            this.Text = "Pandemic!";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkBlue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newYorkStation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox newYorkStation;

        
        
    }
}

