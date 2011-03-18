using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class Solver
    {
        GameState gs;
        public Solver(GameState gs)
        {
            this.gs = gs;
        }

        public void findPath(Player p, City end)
        {
            Map map = gs.map;

            List<City> path = new List<City>();
        }
    }
}
