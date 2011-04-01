using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class TurnAction
    {
        GameState gs;
        public TurnAction(GameState gamestate)
        {
            gs = gamestate;
        }

        public GameState doTurnStuff()
        {
            //does stuff that happens between two turns (after actions)
            Map m=gs.map;
            int numInfectionCardsToDraw=0;

            //draw x player cards
            //check epidemic cards - do epidemic
            if (false) //check if you picked up an epidemic
            {
                m = gs.epidemicCard();
                m.infectionRate++;
                gs.infectionDeck.returnShuffledDiscard();
            }

            //draw x infection cards
            if(m.infectionRate>0 && m.infectionRate<3)
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

            m = gs.drawInfectionCards(numInfectionCardsToDraw);

            return new GameState(gs, m);
        }
    }
}
