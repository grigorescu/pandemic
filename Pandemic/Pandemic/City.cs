using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class City
    {
        //hayley
        public string name;
        public DiseaseColor color;
        public List<City> adjacent;
        public Dictionary<DiseaseColor, int> diseases;
        public City(string name, DiseaseColor color)
        {
            this.name = name;
            this.color = color;
            diseases = new Dictionary<DiseaseColor,int>();
            diseases[DiseaseColor.BLACK] = 0;
            diseases[DiseaseColor.YELLOW] = 0;
            diseases[DiseaseColor.BLUE] = 0;
            diseases[DiseaseColor.ORANGE] = 0;
            adjacent = new List<City>();
        }

        public bool addDisease()
        {
            return addDisease(color);
        }

        public Boolean addDisease(DiseaseColor newColor)
        {
            
            if (diseases[newColor] == 3)
            {
                return true;
            }
            else
            {
                diseases[newColor] = diseases[newColor] + 1;
                return false;
            }
        }

        public int getDisease()
        {
            return getDisease(color);
        }

        public int getDisease(DiseaseColor newColor)
        {
            return diseases[newColor];
        }

        private void addAdjacent(City adj)
        {
            adjacent.Add(adj);
        }

        public static void makeAdjacent(City one, City two)
        {
            if (one.isAdjacent(two))
            {
                throw new Exception("Already adjacent");
            }
            
            one.addAdjacent(two);
            two.addAdjacent(one);
        }

        public Boolean isAdjacent(City adj)
        {
            if (adjacent.Contains(adj))
            {
                return true;
            }else    return false;
        }

        public void setDiseaseLevel(DiseaseColor color, int lvl)
        {
            diseases[color] = lvl;
        }

        override public string ToString()
        {
            String s = "City: " + name;
            return s;
        }
    }
}
