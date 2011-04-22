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
        public virtual Action turnAction()
        {
            return new DoNothingTurnAction();
        }

        public GameState executeOrDoNothing(Action action, GameState gs)
        {
            if (action.isTurnAction())
            {
                return turnAction().execute(gs);
            } else {
                return action.execute(gs);
            }
        }

        public Action bfs_findbest(GameState gs, int depth )
        {
            Debug.Assert(depth > 0);
            float bestEvaluation = -1;
            Action bestAction = null;

            foreach (Action a in gs.availableActions())
            {
                float currentEvaluation = bfs_bestConsequence(executeOrDoNothing(a,gs), depth - 1);
                if (bestEvaluation < currentEvaluation)
                {
                    bestEvaluation = currentEvaluation;
                    bestAction = a;
                }

            }

            Console.WriteLine("My best action was: " + bestAction.ToString() + " with a score of " + bestEvaluation);
            return bestAction;
        }
        
        private float bfs_bestConsequence(GameState gs, int depth)
        {
            if (depth == 0)
                return evaluate(gs);
            else
            {
                float bestEvaluation = -1;
                List<Action> actions = gs.availableActions();
                foreach (Action a in actions)
                {
                    float currentEvaluation = bfs_bestConsequence(executeOrDoNothing(a, gs), depth - 1);
                    if (bestEvaluation < currentEvaluation)
                        bestEvaluation = currentEvaluation;
                }
                return bestEvaluation;
            }

        }
        
    }
}
