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
            }
            else
            {
                return action.execute(gs);
            }
        }

        public Action bfs_findbest_old(GameState gs, int depth)
        {

            Debug.Assert(depth > 0);
            float bestEvaluation = -1;
            Action bestAction = null;

            foreach (Action a in gs.availableActions())
            {
                float currentEvaluation = bfs_bestConsequence(executeOrDoNothing(a, gs), depth - 1);
                if (bestEvaluation < currentEvaluation)
                {
                    bestEvaluation = currentEvaluation;
                    bestAction = a;
                }

            }

           // Console.WriteLine("My best action was: " + bestAction.ToString() + " with a score of " + bestEvaluation);
            return bestAction;
        }

        public Action bfs_findbest(GameState gs, int depth)
        {

            Debug.Assert(depth > 0);
            float bestEvaluation = -1;

            List<Pair> initialActions = new List<Pair>();
            foreach (Action a in gs.availableActions())
            {
                Pair actionPair = new Pair();
                actionPair.initialAction = a;
                actionPair.resultState = executeOrDoNothing(a,gs);
                initialActions.Add(actionPair);
            }
            Action result = bfs_bestConsequenceReduced(initialActions, depth - 1);
            //Console.WriteLine("My best action was: " + result.ToString() + " with a score of " + bestEvaluation);
            return result;
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

        private class Pair { public Action initialAction; public GameState resultState; }
        private Action bfs_bestConsequenceReduced(List<Pair> currentStates, int depth)
        {
            //Console.WriteLine("At depth " + depth + " currentStates is " + currentStates.Count);
            if (depth % 5 == 0)
            {
                currentStates = reduceStatesDuplicates(currentStates);
                //Console.WriteLine("reduced to " + currentStates.Count);
            }

            if (currentStates.Count > 10000)
            {
                currentStates = reduceStatesTo5KBest(currentStates);
            }

            if (depth == 0)
            {
                float bestEvaluation = -1;
                Pair bestPair = null;
                foreach (Pair p in currentStates)
                {
                    float eval = evaluate(p.resultState);
                    if (eval > bestEvaluation)
                    {
                        bestEvaluation = eval;
                        bestPair = p;
                    }
                }
                return bestPair.initialAction;
            }
            else
            {
                List<Pair> resultStates = new List<Pair>();
                foreach (Pair p in currentStates)
                {
                    List<Action> actions = p.resultState.availableActions();
                    foreach (Action a in actions)
                    {
                        Pair newState = new Pair();
                        newState.initialAction = p.initialAction;
                        newState.resultState = executeOrDoNothing(a,p.resultState);
                        resultStates.Add(newState);
                    }
                }
                return bfs_bestConsequenceReduced(resultStates, depth - 1); 
            }

        }



        private List<Pair> reduceStatesDuplicates(List<Pair> gameStates)
        {
            Dictionary<string,Pair> map = new Dictionary<string, Pair>();
            List<Pair> result = new List<Pair>();
            foreach (Pair s in gameStates)
            {
                string hash = hashState(s.resultState);
                if (!map.ContainsKey(hash))
                {
                    result.Add(s);
                    map[hash] = s;
                }
            }
            return result;
        }

        private List<Pair> reduceStatesTo5KBest(List<Pair> gameStates)
        {
            //should result in a reduced search
            gameStates.Sort(delegate(Pair p1, Pair p2) { return evaluate(p2.resultState).CompareTo(evaluate(p1.resultState)); });
            List<Pair> result = gameStates.GetRange(0,5000);
            //Console.WriteLine("Selecting states with eval " + evaluate(result[0].resultState) + " to " + evaluate(result[4999].resultState));
            return result;
            
        }
        public virtual string hashState(GameState gs)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Player p in gs.players)
            {
                sb.Append(p.position.name);
                sb.Append("CARDS");
                foreach (City c in p.cards)
                {
                    sb.Append(c.name);
                    sb.Append(",");
                }
                sb.Append("ENDCARDS");
            }
            sb.Append("CITIES");
            foreach (City c in gs.map.allCities)
            {
                sb.Append(gs.map.diseaseLevel(c, DiseaseColor.BLUE));
                sb.Append(gs.map.diseaseLevel(c, DiseaseColor.YELLOW));
                sb.Append(gs.map.diseaseLevel(c, DiseaseColor.ORANGE));
                sb.Append(gs.map.diseaseLevel(c, DiseaseColor.BLACK));
                sb.Append(gs.map.hasStation(c));
            }
            return sb.ToString();
        }

    }
}