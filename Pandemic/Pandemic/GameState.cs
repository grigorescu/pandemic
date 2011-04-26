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
        public KeyValuePair<int, int>[] bestCardHolder;

        //public int diseasesEradicated = 0; //TODO
        public Deck<City> infectionDeck;
        public Deck<City> playerDeck;
        public Action turnAction;
        public int turnCounter = 0;
        public Boolean hasEpidemic = false;


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
            bestCardHolder  = gs.bestCardHolder;
            hasEpidemic = gs.hasEpidemic;
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
            bestCardHolder = new KeyValuePair<int,int>[4];
            bestCardHolder[(int)DiseaseColor.BLACK] = new KeyValuePair<int, int>(0, 0);
            bestCardHolder[(int)DiseaseColor.BLUE] = new KeyValuePair<int, int>(0, 0);
            bestCardHolder[(int)DiseaseColor.YELLOW] = new KeyValuePair<int, int>(0, 0);
            bestCardHolder[(int)DiseaseColor.ORANGE] = new KeyValuePair<int, int>(0, 0);
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
        }

        public Player currentPlayer()
        {
            return players[currentPlayerNum];
        }

        public GameState recalcForAddCard(Player playerWithCard, City card)
        {
            GameState gs = new GameState(this);

            if (playerWithCard.playernum != gs.bestCardHolder[(int)card.color].Key)
            {
                int numCol = 0;
                foreach (City c in playerWithCard.cards)
                {
                    if (c.color == card.color)
                    {
                        numCol++;
                    }
                }
                if (numCol > gs.bestCardHolder[(int)card.color].Value)
                {
                    KeyValuePair<int, int>[] newbestCardHolder = new KeyValuePair<int, int>[4];
                    for (int i = 0; i < 4; i++)
                    {
                        newbestCardHolder[i] = gs.bestCardHolder[i];
                    }
                    newbestCardHolder[(int)card.color] = new KeyValuePair<int, int>(playerWithCard.playernum, numCol);
                    gs.bestCardHolder = newbestCardHolder;
                }
            }
            else
            {
                KeyValuePair<int, int>[] newbestCardHolder = new KeyValuePair<int, int>[4];
                for (int i = 0; i < 4; i++)
                {
                    newbestCardHolder[i] = gs.bestCardHolder[i];
                }
                newbestCardHolder[(int)card.color] = new KeyValuePair<int, int>(playerWithCard.playernum, gs.bestCardHolder[(int)card.color].Value + 1);
                gs.bestCardHolder = newbestCardHolder;
            }

            return gs;
        }

        public GameState recalcBestCardHolder(GameState newGs, Player playerObj, DiseaseColor card)
        {
            int player = playerObj.playernum;
            if (bestCardHolder[(int)card].Key != player)
            {
                return newGs;
            }
            

            int bestColor = -1;
            int bestPlayer = -1;
            foreach (Player p in newGs.players)
            {
                int totalColor = 0;
                
                foreach (City c in p.cards)
                {
                    if(c.color == card) {
                        totalColor++;
                    }
                    if (totalColor > bestColor)
                    {
                        bestColor = totalColor;
                        bestPlayer = p.playernum;
                    }
                }
            }

            KeyValuePair<int, int>[] newbestCardHolder = new KeyValuePair<int, int>[4];
            for (int i = 0; i < 4; i++)
            {
                newbestCardHolder[i] = newGs.bestCardHolder[i]; 
            }
            newbestCardHolder[(int)card] = new KeyValuePair<int, int>(bestPlayer, bestColor);
            newGs.bestCardHolder = newbestCardHolder;
            return newGs;
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
                    newGS.recalcForAddCard(cp, newGS.playerDeck.mostRecent(1)[0]);
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

            hasEpidemic = true;
        }
    }
}
