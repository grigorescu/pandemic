using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class outbreakHater : SearchEvaluate
    {

        private bool priority; //true = treat cities

        public outbreakHater(bool priority)
        {
            //treat cities
            //help cure disease
            this.priority = priority;
        }

        public static float evalGame(GameState gs)
        {
            //check the number of nearly outbroken cities
            float onverge = gs.map.aboutToOutbreak.Count();
            float cures = gs.numCures();
            int totalDisease = gs.map.numInfectionsInCities;
            float lotsOfCardsBonus = 0;

            //fix plz
            
            lotsOfCardsBonus /= gs.players.Count();


            return 0.5f - (onverge / 20) + (cures / 8) + (float)totalDisease / 100 + lotsOfCardsBonus/8;
        }

        public override float evaluate(GameState gs)
        {
            return evalGame(gs);
        }
    }
}
