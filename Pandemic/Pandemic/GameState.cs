using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public enum DiseaseColor { BLUE, YELLOW, BLACK, ORANGE }
    
    public class GameState
    {
        public Map map;
        public Player player;

        public GameState(GameState gs)
        {
            map = gs.map;
            player = gs.player;
        }

        public GameState(City startCity, Map map)
        {
            player = new Player(startCity);
        }
    }
}
