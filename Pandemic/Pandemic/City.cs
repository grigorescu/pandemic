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
        public City(string name, DiseaseColor color)
        {
            this.name = name;
            this.color = color;
            adjacent = new List<City>();
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
            } else return false;
        }

        public List<MoveAction> getMoveActionsFor(Player player)
        {
            List<MoveAction> moves = new List<MoveAction>();
            foreach (City c in adjacent)
            {
                moves.Add(new MoveAction(player, c));
            }
            return moves;
        }

        override public string ToString()
        {
            String s = "City: " + name;
            return s;
        }
    }
}
