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

        public GameBoard(bool realGame)
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
            //update disease cubes and research station on cities
            foreach (City currentCity in map.allCities)
            {
                Label label = new Label();
                label.Text = "TEST";
                label.AutoSize = true;
                label.Location = new System.Drawing.Point((int) (currentCity.relativeX*Width), (int) (currentCity.relativeY*Height));
                label.Name = "labelq";
                label.Size = new System.Drawing.Size(35, 13);
                label.Text = currentCity.name;
                //label.Location = new Point((int)currentCity.relativeX, (int)currentCity.relativeY);
                this.Controls.Add(label);
                this.Controls.SetChildIndex(label, 1);

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

        private void board_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MouseEventArgs me = (System.Windows.Forms.MouseEventArgs) e;

            Console.WriteLine("RX " + (float) me.X/Width + " RH " + (float) me.Y/Height);
        }
    }
}
