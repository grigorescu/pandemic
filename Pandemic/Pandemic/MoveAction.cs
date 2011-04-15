using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pandemic
{
    public class MoveAction : Action
    {

        Player player;
        City dest;

        public MoveAction(Player player, City dest)
        {
            this.player = player;
            this.dest = dest;
        }

        public override GameState execute(GameState gs)
        {
            Debug.Assert(debug_gs == null || debug_gs == gs, "Action used on an unintended gamestate");
            Player movedPlayer = new Player(dest, player);
            GameState result = gs.adjustPlayer(movedPlayer);
            result.advanceMove();
            return result;
        }

        public override string ToString()
        {
            return "Move to " + dest.name;
        }
    }
}
