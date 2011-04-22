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
            float score = 0;
            float cures = gs.numCures();
            //int totalDisease = 0;

            //if (onverge == 3)
            //{
            //    foreach (City c in gs.map.allCities)
            //    {
            //        totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLACK);
            //        totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLUE);
            //        totalDisease += gs.map.diseaseLevel(c, DiseaseColor.YELLOW);
            //        totalDisease += gs.map.diseaseLevel(c, DiseaseColor.ORANGE);
            //    }
            //    score = 1 - (float)totalDisease / 100;
            //}
            //else
            //{
            //    score = 0.5f - (onverge / 20) + (cures / 8);
            //}

            score = 0.5f - (onverge / 20) + (cures / 8);

            //if (score == 0.5f)
            //{
            //    throw new Exception("Score is .5 something is amiss");
            //}

            return score;
        }

        public override float evaluate(GameState gs)
        {
            return evalGame(gs);
        }
    }
}
