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
        public Map m;
        private Dictionary<String, List<System.Windows.Forms.PictureBox>> diseaseCubes;

        public GameBoard(bool realGame)
        {
            this.diseaseCubes = new Dictionary<String, List<PictureBox>>();
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

            //connect city to place on board and disease cubes
            List<System.Windows.Forms.PictureBox> ny = new List<PictureBox>();
            ny.Add(newYorkBlue1);
            ny.Add(newYorkBlue2);
            ny.Add(newYorkBlue3);
            ny.Add(newYorkStation);
            diseaseCubes.Add("newYork", ny);
        }

        public void update(Map map)//take in a map?
        {
            //update disease cubes and research station on cities
            foreach (City currentCity in map.allCities)
            {
                if(map.diseaseLevel(currentCity, currentCity.color)==1)
                {
                    diseaseCubes[currentCity.name][0].Visible = true;
                }
                else if (map.diseaseLevel(currentCity, currentCity.color) == 2)
                {
                    diseaseCubes[currentCity.name][1].Visible = true;
                }
                else if (map.diseaseLevel(currentCity, currentCity.color) == 3)
                {
                    diseaseCubes[currentCity.name][2].Visible = true;
                }

                if (map.hasStation(currentCity))
                {
                    diseaseCubes[currentCity.name][3].Visible = true;
                }
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
    }
}
