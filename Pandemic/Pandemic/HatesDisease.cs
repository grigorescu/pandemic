using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class HatesDisease : SearchEvaluate
    {
        int diseaseMax;

        public override GameState adjustGameState(GameState gs)
        {
            return gs.setTurnAction(new DoNothingTurnAction());
        }

        public HatesDisease(int diseaseMax)
        {
            this.diseaseMax = diseaseMax;
        }

        public static int getTotalDisease(GameState gs)
        {
            int totalDisease = 0;
            foreach (City c in gs.map.allCities)
            {
                totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLACK);
                totalDisease += gs.map.diseaseLevel(c, DiseaseColor.BLUE);
                totalDisease += gs.map.diseaseLevel(c, DiseaseColor.YELLOW);
                totalDisease += gs.map.diseaseLevel(c, DiseaseColor.ORANGE);
            }
            return totalDisease;
        }

        public override float evaluate(GameState gs)
        {
            return 1 - (float)getTotalDisease(gs) / diseaseMax;

        }
    }
}
