using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pandemic
{
    public abstract class SearchEvaluate
    {
        public abstract float evaluate(GameState gs);
        
        //intended to be overridden
        public virtual GameState adjustGameState(GameState gs)
        {
            return gs;
        }

        public Action bfs_findbest(GameState gs, int depth )
        {
            Debug.Assert(depth > 0);
            float bestEvaluation = -1;
            Action bestAction = null;
            //GameState adjustedGS = adjustGameState(gs);
            foreach (Action a in gs.availableActions())
            {
                GameState actionResult = adjustGameState(a.execute(gs));
                float currentEvaluation = bfs_bestConsequence(actionResult, depth - 1);
                if (bestEvaluation < currentEvaluation)
                {
                    bestEvaluation = currentEvaluation;
                    bestAction = a;
                }

            }
            return bestAction;
        }

        private float bfs_bestConsequence(GameState gs, int depth)
        {
            if (depth == 0)
                return evaluate(gs);
            else
            {
                float bestEvaluation = -1;
                foreach (Action a in gs.availableActions())
                {
                    GameState actionResult = a.execute(gs);
                    float currentEvaluation = bfs_bestConsequence(actionResult, depth - 1);
                    if (bestEvaluation < currentEvaluation)
                        bestEvaluation = currentEvaluation;
                }
                return bestEvaluation;
            }

        }

        
    }
}
