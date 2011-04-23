using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace Pandemic
{

    public class GameState
    {
        public Map map;
        public Player[] players;
        public int currentPlayerNum = 0;
        public int numPlayers;
        public int numMoves;
        public int cpMovesUsed = 0;
        public bool[] curesFound;
        //public int diseasesEradicated = 0; //TODO
        public Deck<City> infectionDeck;
        public Deck<City> playerDeck;
        public Action turnAction;
        public int turnCounter = 0;

        public GameState setTurnAction(Action action)
        {
            GameState newGS = new GameState(this);
            newGS.turnAction = action;
            return newGS;
        }

        private GameState(GameState gs)
        {
            map = gs.map;
            players = gs.players;
            currentPlayerNum = gs.currentPlayerNum;
            numPlayers = gs.numPlayers;
            numMoves = gs.numMoves;
            cpMovesUsed = gs.cpMovesUsed;
            infectionDeck = gs.infectionDeck;
            playerDeck = gs.playerDeck;
            turnAction = gs.turnAction;
            curesFound = gs.curesFound;
        }

        public GameState adjustPlayer(Player p)
        {
            GameState result = new GameState(this);
            result.players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                result.players[i] = players[i];
            }
            Debug.Assert(p.playernum < numPlayers);
            result.players[p.playernum] = p;
            return result;
        }


        public GameState(GameState gs, Map map)
            : this(gs)
        {
            this.map = map;
            advanceMove();
        }

        public GameState(City startCity, Map map, int num_players = 1, int num_moves = 4, Deck<City> infectDeck = null, Deck<City> playerDeck = null)
        {
            players = new Player[num_players];
            for (int i = 0; i < num_players; i++)
            {
                players[i] = new Player(startCity, i);
            }
            this.map = map;
            this.numPlayers = num_players;
            this.numMoves = num_moves;
            this.infectionDeck = infectDeck;
            this.playerDeck = playerDeck;
            this.turnAction = new TurnAction();
            this.curesFound = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                this.curesFound[i] = false;
            }
        }

        public int numCures()
        {
            int result = 0;
            foreach (bool b in curesFound)
            {
                if (b) result++;
            }
            return result;
        }

        public bool hasWon()
        {
            return numCures() == 4;
        }

        public bool hasLost()
        {
            return (map.outbreakCount >= 9 || playerDeck.isOverdrawn);
        }

        public void advanceMove()
        {
            cpMovesUsed++;
            //if (cpMovesUsed == numMoves)
            //{
            //    currentPlayerNum = (currentPlayerNum + 1) % numPlayers;
            //    cpMovesUsed = 0;
            //}
        }

        public Player currentPlayer()
        {
            return players[currentPlayerNum];
        }

        public GameState cureDisease(DiseaseColor color)
        {
            GameState result = new GameState(this);
            result.curesFound = new bool[4];
            for (int i = 0; i < 4; i++)
            {
                result.curesFound[i] = curesFound[i];
            }
            result.curesFound[(int)color] = true;
            return result;
        }

        public List<Action> availableActions()
        {
            List<Action> actions = new List<Action>();
            if (cpMovesUsed < numMoves)
            {
                Player current = currentPlayer();
                actions.AddRange(map.getMoveActionsFor(current));

                actions.AddRange(map.getCureActionsFor(current));
                actions.AddRange(MoveToCardAction.actionsForPlayer(currentPlayer()));
                actions.AddRange(MakeStationAction.actionsForPlayer(currentPlayer(), this.map));
                actions.AddRange(TradeAction.getTrades(this));
                actions.AddRange(CureDiseaseAction.getCureActions(this));
                foreach (Action a in actions)
                {
                    a.debug_gs = this;
                }
            }
            else
            {
                actions.Add(turnAction);
            }

            return actions;
        }

        public void advancePlayer()
        {
            this.cpMovesUsed = 0;
            this.currentPlayerNum = (currentPlayerNum + 1) % numPlayers;
        }

        public GameState drawInfectionCards(int drawNum)
        {
            GameState newGS = new GameState(this);
            newGS.infectionDeck = infectionDeck.draw(drawNum);
            Map m = map;

            foreach (City current in newGS.infectionDeck.mostRecent(drawNum))
            {
                m = m.addDisease(current, 1);
            }
            newGS.map = m;

            return newGS;
        }

        public GameState drawPlayerCards(Player cp, int num = 2)
        {
            GameState newGS = new GameState(this);
            for (int i = 0; i < num; i++)
            {
                if (newGS.playerDeck.isNextCardEpidemic())
                {
                    
                    newGS.epidemicCard();
                    newGS.playerDeck.cardWeAreOn++;
                }
                else
                {
                    newGS.playerDeck = newGS.playerDeck.draw(1);
                    if (newGS.playerDeck.isOverdrawn)
                    {
                        //we just lost
                        return newGS;
                    }
                    newGS = newGS.adjustPlayer(cp.addCard(newGS.playerDeck.mostRecent(1)[0]));
                }
            }

            return newGS;
        }

        public void epidemicCard()
        {
            infectionDeck = infectionDeck.drawFromBottom();
            City c = infectionDeck.mostRecent(1)[0];
            Console.WriteLine("Epidemic in " + c);
            map = map.addDisease(c, 1);
            map = map.addDisease(c, 1);
            map = map.addDisease(c, 1);
            
            map.infectionRate++;
            infectionDeck = infectionDeck.returnShuffledDiscard();

        }
    }
}
