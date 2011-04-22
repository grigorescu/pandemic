using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class TurnAction : Action
    {

        public override bool isTurnAction()
        {
            return true;
        }

        public TurnAction()
        {
        }

        public override GameState execute(GameState gs)
        {
            //does stuff that happens between two turns (after actions)
            Map m=gs.map;
            GameState newGS = gs;
            int numInfectionCardsToDraw=0;

            //draw x player cards
            newGS.drawPlayerCards(gs.currentPlayer());

            //check epidemic cards - do epidemic
            

            //draw x infection cards
            if(m.infectionRate>=0 && m.infectionRate<3)
            {
                numInfectionCardsToDraw = 2;
            }
            else if (m.infectionRate >= 3 && m.infectionRate < 5)
            {
                numInfectionCardsToDraw = 3;
            }
            else if(m.infectionRate >=5 && m.infectionRate<7)
            {
                numInfectionCardsToDraw = 4;
            }

            newGS = newGS.drawInfectionCards(numInfectionCardsToDraw);
            newGS = newGS.drawPlayerCards(gs.currentPlayer());
            newGS.advancePlayer();


            return newGS;
        }

        public override string ToString()
        {
            return "End of turn card draw";
        }
    }
}
