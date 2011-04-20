
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
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
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
            this.nextActButton.BackColor = System.Drawing.Color.DarkSlateGray;
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
            this.lastAction.Location = new System.Drawing.Point(1085, 496);
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
            this.label2.Location = new System.Drawing.Point(1085, 405);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1079, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1085, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Hand:";
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
            this.currPlayerInfo.Location = new System.Drawing.Point(1082, 139);
            this.currPlayerInfo.Name = "currPlayerInfo";
            this.currPlayerInfo.Size = new System.Drawing.Size(193, 161);
            this.currPlayerInfo.TabIndex = 8;
            this.currPlayerInfo.Text = "";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 784);
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
            this.ResumeLayout(false);

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

        
        
    }
}

