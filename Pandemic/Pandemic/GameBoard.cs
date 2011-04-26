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
        Boolean debug = false; //turn to false for demo ps it doesn't work real well
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
            makePlayer(gs.currentPlayer().ToString(), .952f, .107f, 0, 0, 2);
            if (ge.lastAction != null)
            {
                //String lastAct = gs.currentPlayer().ToString() + ge.lastAction.ToString();
                makeLabel(("Player " + gs.currentPlayer().ToString() + ": " + ge.lastAction.ToString()), .848f, .450f, Color.Green, Color.LightGray, 9);
            }

            this.currPlayerInfo.Text = gs.currentPlayer().ToLongDescr();

            //other players cards
            String otherHandstxt = null;
            int n = 0;
            foreach (Player p in gs.players)
            {
                if (p.playernum != gs.currentPlayerNum)
                {
                    n = p.playernum + 1;
                    otherHandstxt += "PLAYER " + n + " hand: \n";
                    foreach (City c in p.cards)
                    {
                        otherHandstxt += c.name + "\n";
                    }
                }    
            }
            this.otherHands.Text = otherHandstxt;

            //outbreak counter
            switch (gs.map.outbreakCount)
            {
                case 0:
                    makeCounter(false, .023f, .564f);
                    break;
                case 1:
                    makeCounter(false, .048f, .619f);
                    break;
                case 2:
                    makeCounter(false, .019f, .658f);
                    break;
                case 3:
                    makeCounter(false, .048f, .711f);
                    break;
                case 4:
                    makeCounter(false, .022f, .760f);
                    break;
                case 5:
                    makeCounter(false, .047f, .790f);
                    break;
                case 6:
                    makeCounter(false, .019f, .850f);
                    break;
                case 7:
                    makeCounter(false, .049f, .890f);
                    break;
                case 8:
                    makeCounter(false, .020f, .931f);
                    break;
            }

            //infection counter
            switch (gs.map.infectionRate)
            {
                case 0:
                    makeCounter(true, .505f, .190f);
                    break;
                case 1:
                    makeCounter(true, .542f, .200f);
                    break;
                case 2:
                    makeCounter(true, .578f, .214f);
                    break;
                case 3:
                    makeCounter(true, .616f, .224f);
                    break;
                case 4:
                    makeCounter(true, .652f, .220f);
                    break;
                case 5:
                    makeCounter(true, .686f, .210f);
                    break;
                case 6:
                    makeCounter(true, .723f, .195f);
                    break;
            }

            //infection discard deck
            this.discardInfection.Text = gs.infectionDeck.mostRecent(1)[0].name;

            //cards left in the player deck
            makeLabel((gs.playerDeck.drawDeck.Count.ToString()+ " cards left"), .537f, .737f, Color.White, Color.Navy);    

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
            label2.Location = new System.Drawing.Point((int)(city.relativeX * board.Width) + offsetX*15, (int)(city.relativeY * board.Height) + offsetY*15);
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
            alabel.Location = new Point((int)(x * board.Width), (int)(y * board.Height));
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
            //Console.WriteLine(pName);
            if (pName == "1")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\bplayer.png")));
            }else if(pName == "2")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\gplayer.png")));
            }else if(pName == "3")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\yplayer.png")));

            }else if(pName == "4")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\wplayer.png")));
            }
            else if (pName == "0")
            {
                p1.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\blplayer.png")));
            }

            p1.Location = new System.Drawing.Point((int)(x * board.Width) + offsetX * 15, (int)(y * board.Height) + offsetY * 15);
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

        private void makeCounter(bool infection, float x, float y, int sizeMulti = 1)
        {
            PictureBox piece = new PictureBox();
            //Console.WriteLine(pName);
            if (infection)
            {
                piece.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\infectionRate.png")));
            }
            else
            {
                piece.Image = ((System.Drawing.Image)(Image.FromFile("..\\..\\pics\\epidemicPiece.png")));
            }

            piece.Location = new System.Drawing.Point((int)(x * board.Width), (int)(y * board.Height));
            piece.Size = new Size(32, 43);
            if (sizeMulti != 1)
            {
                piece.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                piece.Size = new Size(18 * sizeMulti, 21 * sizeMulti);
            }
            else
            {
                piece.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            }

            piece.TabIndex = 7;
            piece.TabStop = false;
            this.Controls.Add(piece);
            this.Controls.SetChildIndex(piece, 1);
            toRemove.Add(piece);
        }

        //Clicks:
        private void board_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs) e;

            Console.WriteLine("RX " + (float) me.X/board.Width + " RH " + (float) me.Y/board.Height);
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

        private void GameBoard_Resize(object sender, EventArgs e)
        {
            update(ge.gs);
        }


        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                timer1.Enabled = true;
            else
                timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            ge.runAction();
            this.update(ge.gs);
            if (checkBox1.Checked)
                timer1.Enabled = true;
        }
    
    }
}
