using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class medSmartAI: SearchEvaluate
    {

       private bool priority; //true = treat cities

        public medSmartAI(bool priority)
        {
            //treat cities
            //help cure disease
            this.priority = priority;      
        }

        public float evalGame(GameState gs)
        {
            //check the number of nearly outbroken cities
            float onverge = 0;
            float score = 0;
            float cures = gs.numCures();

            foreach (City c in gs.map.aboutToOutbreak)
            {
                onverge++;
            }

            

            score = 0.5f-(onverge/40)+(cures/8);
            
            //higher numbers = better game state
            //want num between 0-1
            return score;
        }

        public override float evaluate(GameState gs)
        {
            return evalGame(gs);
        }
    }
}
