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
        List<Label> toRemove = new List<Label>();

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

        public void update(GameState gs)//take in a map?
        {
            Map map = gs.map;

            //remove labels on map (old)
            foreach (Label l in toRemove)
            {
                this.Controls.Remove(l);
            }
            toRemove.Clear();

            //update disease cubes and research station on cities
            foreach (City currentCity in map.allCities)
            {
                createDiseaseLabels(currentCity, gs);               
                if(map.hasStation(currentCity)) {
                    makeLabel("STATION", currentCity,0, 1, Color.Black, Color.PaleVioletRed);
                }
                createPlayersLabels(currentCity, gs);
            }
            //player postion
            
            //outbreak counter

            //infection counter

            //infection discard deck

            //num cubes left (per disease color)

            //cards left (per deck type)

            //disease cured

            //disease irradicated

        }

        private void createPlayersLabels(City currentCity, GameState gs)
        {
            int currentOffset = 0;
            foreach (Player p in gs.players)
            {
                if (p.position == currentCity)
                {
                    makeLabel(p.ToString(), currentCity, currentOffset, 2, Color.Tomato, Color.Wheat);
                    currentOffset++;
                }
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

        
    }
}
