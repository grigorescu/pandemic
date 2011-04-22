using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class outbreakHater: SearchEvaluate
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
            float score = 0;
            int totalDisease = gs.map.numInfectionsInCities;


            return 0.5f - (onverge / 20) + (cures / 8) + (float)totalDisease/100;
        }

        public override float evaluate(GameState gs)
        {
            return evalGame(gs);
        }
    }
}
