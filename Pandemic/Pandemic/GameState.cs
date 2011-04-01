using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Pandemic
{
    public enum DiseaseColor { BLUE, YELLOW, BLACK, ORANGE }
    
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

        private GameState(GameState gs)
        {
            map = gs.map;
            players = gs.players;
            currentPlayerNum = gs.currentPlayerNum;
            numPlayers = gs.numPlayers;
            numMoves = gs.numMoves;
            cpMovesUsed = gs.cpMovesUsed;
            
        }

        public GameState(GameState gs, Player player)
            : this(gs)
        {
            map = gs.map;
            players = new Player[numPlayers];
            for (int i = 0; i < numPlayers; i++)
            {
                players[i] = gs.players[i];
            }
            Debug.Assert(player.playernum < numPlayers);
            players[player.playernum] = player;
            advanceMove();
        }

        public GameState(GameState gs, Map map)
            : this(gs)
        {
            this.map = map;
            advanceMove();
        }

        public GameState(City startCity, Map map, Deck<City> infectDeck, int num_players = 1, int num_moves = 4)
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
        }

        private void advanceMove()
        {
            cpMovesUsed++;
            if (cpMovesUsed == numMoves)
            {
                currentPlayerNum = (currentPlayerNum + 1) % numPlayers;
                cpMovesUsed = 0;
            }
        }

        public Player currentPlayer()
        {
            return players[currentPlayerNum];
        }

        public List<Action> availableActions()
        {
            List<Action> actions = new List<Action>();
            Player current = currentPlayer();
            actions.AddRange(map.getMoveActionsFor(current));
            actions.AddRange(map.getCureActionsFor(current));
            foreach (Action a in actions)
            {
                a.debug_gs = this;
            }
            return actions;
        }

        public Map drawInfectionCards(int drawNum)
        {
            Map m = map;
            List<City> drawnCard;
            drawnCard = infectionDeck.draw(drawNum);

            foreach (City current in drawnCard)
            {
                m = m.addDisease(current, 1);
            }

            return m;
        }

        public Map epidemicCard()
        {
            Map m = map;
            m.infectionRate++;

            List<City> drawnCard;
            drawnCard = infectionDeck.draw(3);
            m = m.addDisease(drawnCard[0], 3);
            m = m.addDisease(drawnCard[1], 3);
            m = m.addDisease(drawnCard[2], 3);

            return m;
        }
    }
}
