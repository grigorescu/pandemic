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
        //public ArrayList diseaseCubes = new ArrayList();
        private Dictionary<City, List<System.Windows.Forms.PictureBox>> diseaseCubes;

        public GameBoard(bool realGame)
        {
            this.diseaseCubes = new Dictionary<City, List<PictureBox>>();
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
            m = new Map();
            //north america
            City atlanta = m.addCity("Atlanta", DiseaseColor.BLUE);
            City newYork = m.addCity("NewYork", DiseaseColor.BLUE);
            City chicago = m.addCity("Chicago", DiseaseColor.BLUE);
            City washington = m.addCity("Washington", DiseaseColor.BLUE);
            City canadaCity = m.addCity("CanadaCity", DiseaseColor.YELLOW);
            City losAngeles = m.addCity("LosAngeles", DiseaseColor.YELLOW);
            City miami = m.addCity("Miami", DiseaseColor.YELLOW);
            City mexicoCity = m.addCity("MexicoCity", DiseaseColor.YELLOW);

            City.makeAdjacent(newYork, washington);
            City.makeAdjacent(newYork, canadaCity);
            City.makeAdjacent(washington, atlanta);
            City.makeAdjacent(washington, miami);
            City.makeAdjacent(canadaCity, chicago);
            City.makeAdjacent(canadaCity, atlanta);
            City.makeAdjacent(chicago, losAngeles);
            City.makeAdjacent(chicago, mexicoCity);
            City.makeAdjacent(atlanta, miami);
            City.makeAdjacent(mexicoCity, miami);

            this.m = m.addDisease(newYork);

            //connect city to place on board and disease cubes
            List<System.Windows.Forms.PictureBox> ny = new List<PictureBox>();
            ny.Add(newYorkBlue1);
            ny.Add(newYorkBlue2);
            ny.Add(newYorkBlue3);
            ny.Add(newYorkStation);
            diseaseCubes.Add(newYork, ny);
        }

        public void update(Map map)//take in a map?
        {
            //update disease cubes and research station on cities
            for (int i = 0; i < map.allCities.Count - 1; i++)
            {
                //Console.WriteLine(map.allCities.ElementAt(i).name + map.diseaseLevel(map.allCities.ElementAt(i), map.allCities.ElementAt(i).color));
                if (map.diseaseLevel(map.allCities.ElementAt(i), map.allCities.ElementAt(i).color) == 1)
                {
                    diseaseCubes[map.allCities.ElementAt(i)][0].Visible = true;
                }
                else if (map.diseaseLevel(map.allCities.ElementAt(i), map.allCities.ElementAt(i).color) == 2)
                {
                    diseaseCubes[map.allCities.ElementAt(i)][1].Visible = true;
                }
                else if (map.diseaseLevel(map.allCities.ElementAt(i), map.allCities.ElementAt(i).color) == 3)
                {
                    diseaseCubes[map.allCities.ElementAt(i)][2].Visible = true;
                }


                //research station position
                if (map.hasStation(map.allCities.ElementAt(i)))
                {
                    diseaseCubes[map.allCities.ElementAt(i)][3].Visible = true;
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
