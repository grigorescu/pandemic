using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pandemic
{
    public class MakeStationAction : Action
    {
        City position;
        Player player;

        public MakeStationAction(Player p, City position)
        {
            this.position = position;
            this.player = p;
        }

        public override GameState execute(GameState current)
        {
            Debug.Assert(debug_gs == null || debug_gs == current, "Action used on an unintended gamestate");

            Map newMap = current.map.addStation(position);
            GameState g = new GameState(current, newMap);
            player = player.removeCard(position);
            g.players[g.currentPlayerNum] = player;
            g.advanceMove();
            return g;
        }

        public static List<MakeStationAction> actionsForPlayer(Player p)
        {
            List<MakeStationAction> results = new List<MakeStationAction>();
            foreach (City c in p.cards)
            {
                if (p.position == c)
                {
                    results.Add(new MakeStationAction(p, c));
                }
            }
            return results;
        }

        public override string ToString()
        {
            return "Creating a station " + position.name;
        }
    }
}
