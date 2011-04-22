using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class DoNothingTurnAction : Action
    {

        public override bool isTurnAction()
        {
            return true;
        }


        public override GameState execute(GameState gs)
        {
            
            gs = new GameState(gs, gs.map);
            gs.advancePlayer();


            return gs;
        }

    }
}
