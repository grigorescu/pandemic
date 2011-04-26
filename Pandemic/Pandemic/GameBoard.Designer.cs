
namespace Pandemic
{
    partial class GameBoard
    {
        //objects (pictures boxes)
        private System.Windows.Forms.PictureBox board;
        public System.ComponentModel.ComponentResourceManager resources;
       
        
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoard));
            this.board = new System.Windows.Forms.PictureBox();
            this.nextActButton = new System.Windows.Forms.Button();
            this.lastAction = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.currPlayerInfo = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.otherHands = new System.Windows.Forms.RichTextBox();
            this.playerdeck1 = new System.Windows.Forms.PictureBox();
            this.playerdeck2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.discardInfection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerdeck1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerdeck2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.LightGray;
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Image = ((System.Drawing.Image)(resources.GetObject("board.Image")));
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Padding = new System.Windows.Forms.Padding(0, 0, 210, 0);
            this.board.Size = new System.Drawing.Size(1284, 784);
            this.board.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.board.TabIndex = 0;
            this.board.TabStop = false;
            this.board.Click += new System.EventHandler(this.board_Click);
            // 
            // nextActButton
            // 
            this.nextActButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextActButton.BackColor = System.Drawing.Color.CadetBlue;
            this.nextActButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nextActButton.ForeColor = System.Drawing.SystemColors.Control;
            this.nextActButton.Location = new System.Drawing.Point(1075, 719);
            this.nextActButton.Name = "nextActButton";
            this.nextActButton.Size = new System.Drawing.Size(206, 62);
            this.nextActButton.TabIndex = 6;
            this.nextActButton.Text = "NEXT ACTION";
            this.nextActButton.UseVisualStyleBackColor = false;
            this.nextActButton.Click += new System.EventHandler(this.nextActButton_Click);
            // 
            // lastAction
            // 
            this.lastAction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lastAction.BackColor = System.Drawing.SystemColors.Control;
            this.lastAction.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lastAction.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastAction.Location = new System.Drawing.Point(1079, 307);
            this.lastAction.Name = "lastAction";
            this.lastAction.Size = new System.Drawing.Size(123, 27);
            this.lastAction.TabIndex = 2;
            this.lastAction.Text = "Last Action:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1078, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Current Player:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1076, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player Details";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1082, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Other Players Hands:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1284, 784);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape2.Location = new System.Drawing.Point(1079, 395);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(359, 389);
            this.rectangleShape2.Click += new System.EventHandler(this.rectangleShape2_Click);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.rectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque;
            this.rectangleShape1.Location = new System.Drawing.Point(1043, 6);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(240, 387);
            this.rectangleShape1.Click += new System.EventHandler(this.rectangleShape1_Click);
            // 
            // currPlayerInfo
            // 
            this.currPlayerInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currPlayerInfo.Location = new System.Drawing.Point(1079, 149);
            this.currPlayerInfo.Name = "currPlayerInfo";
            this.currPlayerInfo.Size = new System.Drawing.Size(193, 129);
            this.currPlayerInfo.TabIndex = 8;
            this.currPlayerInfo.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1085, 690);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(87, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Keep playing";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // otherHands
            // 
            this.otherHands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.otherHands.Location = new System.Drawing.Point(1082, 429);
            this.otherHands.Name = "otherHands";
            this.otherHands.Size = new System.Drawing.Size(193, 255);
            this.otherHands.TabIndex = 10;
            this.otherHands.Text = "";
            // 
            // playerdeck1
            // 
            this.playerdeck1.Image = ((System.Drawing.Image)(resources.GetObject("playerdeck1.Image")));
            this.playerdeck1.Location = new System.Drawing.Point(650, 596);
            this.playerdeck1.Name = "playerdeck1";
            this.playerdeck1.Size = new System.Drawing.Size(134, 178);
            this.playerdeck1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerdeck1.TabIndex = 11;
            this.playerdeck1.TabStop = false;
            // 
            // playerdeck2
            // 
            this.playerdeck2.Image = ((System.Drawing.Image)(resources.GetObject("playerdeck2.Image")));
            this.playerdeck2.Location = new System.Drawing.Point(808, 596);
            this.playerdeck2.Name = "playerdeck2";
            this.playerdeck2.Size = new System.Drawing.Size(134, 178);
            this.playerdeck2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.playerdeck2.TabIndex = 12;
            this.playerdeck2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(621, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // discardInfection
            // 
            this.discardInfection.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.discardInfection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardInfection.Location = new System.Drawing.Point(817, 15);
            this.discardInfection.Name = "discardInfection";
            this.discardInfection.Size = new System.Drawing.Size(178, 119);
            this.discardInfection.TabIndex = 14;
            this.discardInfection.Text = "label4";
            this.discardInfection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 784);
            this.Controls.Add(this.discardInfection);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.playerdeck2);
            this.Controls.Add(this.playerdeck1);
            this.Controls.Add(this.otherHands);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.currPlayerInfo);
            this.Controls.Add(this.nextActButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lastAction);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.board);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "GameBoard";
            this.Text = "Pandemic!";
            this.Resize += new System.EventHandler(this.GameBoard_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerdeck1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playerdeck2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button nextActButton;
        private System.Windows.Forms.Label lastAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
        private System.Windows.Forms.RichTextBox currPlayerInfo;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RichTextBox otherHands;
        private System.Windows.Forms.PictureBox playerdeck1;
        private System.Windows.Forms.PictureBox playerdeck2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label discardInfection;

        
        
    }
}

