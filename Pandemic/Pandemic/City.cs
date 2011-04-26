using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pandemic
{
    //hayley
    public enum DiseaseColor { BLUE, YELLOW, BLACK, ORANGE }


    public class City
    {

        public static Color toForeColor(DiseaseColor c)
        {
            switch (c)
            {
                case DiseaseColor.YELLOW:
                    return Color.Black;
                default:
                    return Color.White;
            }
        }

        public static Color toBackColor(DiseaseColor c)
        {
            switch (c)
            {
                case DiseaseColor.YELLOW:
                    return Color.Yellow;
                case DiseaseColor.BLUE:
                    return Color.DarkBlue;
                case DiseaseColor.ORANGE:
                    return Color.DarkOrange;
                case DiseaseColor.BLACK:
                    return Color.Black;
                default:
                    return Color.PaleGoldenrod;
            }
        }

        //hayley
        public string name;
        public DiseaseColor color;
        public List<City> adjacent;
        public float relativeX, relativeY;
        public int cityNumber;
        public City(string name, DiseaseColor color, int number, float x = 0, float y = 0)
        {
            this.name = name;
            this.color = color;
            adjacent = new List<City>();
            relativeX = x;
            relativeY = y;
            cityNumber = number;
        }

        private void addAdjacent(City adj)
        {
            adjacent.Add(adj);
        }

        public static void makeAdjacent(City one, City two)
        {
            if (one.isAdjacent(two))
            {
                throw new Exception(one.name + " and " + two.name +"Already adjacent");
            }
            
            one.addAdjacent(two);
            two.addAdjacent(one);
        }

        public Boolean isAdjacent(City adj)
        {
            if (adjacent.Contains(adj))
            {
                return true;
            } else return false;
        }

        override public string ToString()
        {
            return name;
        }
    }
}
