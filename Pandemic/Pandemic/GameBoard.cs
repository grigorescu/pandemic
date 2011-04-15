using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace Pandemic
{
    public partial class GameBoard : Form
    {

        GameEngine ge;
        ArrayList toRemove = new ArrayList();

        public GameBoard(bool realGame, GameEngine ge)
        {
            InitializeComponent();
            if (realGame)
            {
                initializeRealGame();
            }
            else
            {
                initializeTestGame();
            }
            this.ge = ge;
        }

        private void initializeRealGame()
        {

        }

        private void initializeTestGame()
        {         

        }

        public void update(GameState gs)
        {
            Map map = gs.map;

            //remove labels on map (old)
            for(int i=0; i<toRemove.Count;i++)
            {
                this.Controls.Remove((Control)toRemove[i]);
            }
            toRemove.Clear();

            //update disease cubes and research station on cities and player postion
            int curOffsetY;
            foreach (City currentCity in map.allCities)
            {
                curOffsetY = 1;
                createDiseaseLabels(currentCity, gs);               
                if(map.hasStation(currentCity)) {
                    makeLabel("STATION", currentCity, 0, curOffsetY, Color.Black, Color.PaleVioletRed);
                    curOffsetY++;
                }
                createPlayersLabels(currentCity, gs, curOffsetY);
            }
            
            //current player + last action HUD info
            makePlayer(gs.currentPlayer().ToString(), .800f, .540f, 0, 0, 2);
            if (ge.lastAction != null)
            {
                //String lastAct = gs.currentPlayer().ToString() + ge.lastAction.ToString();
                makeLabel(("Player " + gs.currentPlayer().ToString() + ": " + ge.lastAction.ToString()), .800f, .650f, Color.Green, Color.DarkGray, 14);
            }

            this.currPlayerInfo.Text = gs.currentPlayer().ToLongDescr();

            //outbreak counter

            //infection counter

            //infection discard deck

            //num cubes left (per disease color)

            //cards left (per deck type)

            //disease cured

            //disease irradicated

        }

        private void createPlayersLabels(City currentCity, GameState gs, int yOffset)
        {
            int currentOffset = 0;
            foreach (Player p in gs.players)
            {
                if (p.position == currentCity)
                {
                    makePlayer(p.ToString(), currentCity.relativeX, currentCity.relativeY, currentOffset, yOffset);
                    currentOffset++;
                }
            }
        }

        private void createPlayersHandLabels(Player curr)
        {
            float currentOffset = .010f;
            float x = .016f;
            foreach (City c in curr.cards)
            {
               // x += currentOffset;
                makeLabel(c.name, x, .019f, Color.HotPink, Color.Gray);
               currentOffset+= .010f;
            }
        }

        private void createDiseaseLabels(City currentCity, GameState gs)
        {
            int currentOffset = 1;
            foreach (DiseaseColor color in Enum.GetValues(typeof(DiseaseColor)).Cast<DiseaseColor>())
            {
                Color f = City.toForeColor(color);
                Color b = City.toBackColor(color);
                if (color == currentCity.color)
                {
                    makeLabel(gs.map.diseaseLevel(currentCity, color).ToString(), currentCity, 0, 0, f, b);
                }
                else
                {
                    int level = gs.map.diseaseLevel(currentCity, color);
                    if(level > 0) {
                        makeLabel(level.ToString(), currentCity, currentOffset, 0, f, b);
                        currentOffset++;
                    }
                }
            }

            
                    
        }

        private void makeLabel(String label, City city, int offsetX, int offsetY, Color f, Color b)
        {
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point((int)(city.relativeX * Width) + offsetX*15, (int)(city.relativeY * Height) + offsetY*15);
            label2.Size = new System.Drawing.Size(35, 13);
            label2.Text = label;
            label2.ForeColor = f;
            label2.BackColor = b;
            this.Controls.Add(label2);
            this.Controls.SetChildIndex(label2, 1);
            toRemove.Add(label2);
        }

        private void makeLabel(String label, float x, float y, Color f, Color b, float fontSize = 8.25f)
        {
            Label alabel = new Label();
            if (fontSize != alabel.Font.Size)
            {
                Font font = new Font(alabel.Font.FontFamily.Name, fontSize);
                alabel.Font = font;
            }

            alabel.Size = new System.Drawing.Size(35, 13);
            alabel.AutoSize = true;
            alabel.Location = new Point((int)(x * Width), (int)(y * Height));
            alabel.Text = label;
            alabel.ForeColor = f;
            alabel.BackColor = b;
            this.Controls.Add(alabel);
            this.Controls.SetChildIndex(alabel, 1);
            toRemove.Add(alabel);
        }

        private void makePlayer(String pName, float x, float y, int offsetX, int offsetY, int sizeMulti = 1)
        {
            PictureBox p1 = new PictureBox();
            Console.WriteLine(pName);
            if (pName == "1")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Hayley\\Documents\\Visual Studio 2010\\Projects\\Pandemic\\Pandemic\\pics\\bplayer.png")));
            }else if(pName == "2")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Hayley\\Documents\\Visual Studio 2010\\Projects\\Pandemic\\Pandemic\\pics\\gplayer.png")));
            }else if(pName == "3")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Hayley\\Documents\\Visual Studio 2010\\Projects\\Pandemic\\Pandemic\\pics\\yplayer.png")));

            }else if(pName == "4")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Hayley\\Documents\\Visual Studio 2010\\Projects\\Pandemic\\Pandemic\\pics\\wplayer.png")));
            }
            else if (pName == "0")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("C:\\Users\\Hayley\\Documents\\Visual Studio 2010\\Projects\\Pandemic\\Pandemic\\pics\\blplayer.png")));
            }

            p1.Location = new System.Drawing.Point((int)(x * Width) + offsetX * 15, (int)(y * Height) + offsetY * 15);
            p1.Name = pName;
            p1.Size = new Size(18, 21);
            if (sizeMulti != 1)
            {
                p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                p1.Size = new Size(18 * sizeMulti, 21 * sizeMulti);
            }
            else
            {
                p1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            }
             
            p1.TabIndex = 7;
            p1.TabStop = false;
            this.Controls.Add(p1);
            this.Controls.SetChildIndex(p1, 1);
            toRemove.Add(p1);
        }


        //Clicks:
        private void board_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs) e;

            Console.WriteLine("RX " + (float) me.X/Width + " RH " + (float) me.Y/Height);
        }

        private void nextActButton_Click(object sender, EventArgs e)
        {
            ge.runAction();
            this.update(ge.gs);
        }

        private void rectangleShape1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs)e;

            Console.WriteLine("RX " + (float)me.X / Width + " RH " + (float)me.Y / Height);
        }

        private void rectangleShape2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs)e;

            Console.WriteLine("RX " + (float)me.X / Width + " RH " + (float)me.Y / Height);
        }

       
        
    }
}
