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
        public int curesFound = 0; //TODO
        public int diseasesEradicated = 0; //TODO
        public Deck<City> infectionDeck;
        public Deck<City> playerDeck;
        public Action turnAction;
        public int turnCounter =0;

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

        public GameState drawPlayerCards(Player cp, int num=2)
        {
            //draw 2
            GameState newGS = new GameState(this);
            newGS.playerDeck = playerDeck.draw(num);
          

            //CHECK IF player deck is done

            foreach (City c in newGS.playerDeck.mostRecent(num))
            {
                cp = cp.addCard(c);
            }

            while (cp.cards.Count > 7)
            {
                if (cp.isAI)
                {
                    //may want to plug some AI in here
                    cp.removeCard(cp.cards[cp.cards.Count - 1]);
                }
                else
                {
                    //ask the player which card to remove
                }
            }

            newGS.players[cp.playernum] = cp;

            return newGS;
        }

        public Map epidemicCard()
        {
            Map m = map;
            /* m.infectionRate++;

            List<City> drawnCard;
            drawnCard = infectionDeck.draw(3);
            m = m.addDisease(drawnCard[0], 3);
            m = m.addDisease(drawnCard[1], 3);
            m = m.addDisease(drawnCard[2], 3);*/

            return m;
        }
    }
}
