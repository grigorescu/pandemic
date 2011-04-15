using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class Player
    {
        private City _position;
        public readonly int playernum;
        public Boolean isAI = true;

        public List<City> cards;

        public City position
        {
            get
            {
                return _position;
            }
        }

        private Player(Player p)
        {
            _position = p._position;
            playernum = p.playernum;
            cards = p.cards;
            isAI = p.isAI;
        }

        public Player(City newPosition, Player player)
            : this(player)
        {
            _position = newPosition;
        }

        public Player(City position, int playernum, Boolean isAI = true)
        {
            _position = position;
            this.playernum = playernum;
            this.isAI = isAI;
            this.cards = new List<City>();
        }

        public List<Action> getActions()
        {
            return new List<Action>();
        }

        public Player addCard(City city)
        {
            Player newPlayer = new Player(this);
            newPlayer.cards = new List<City>();
            newPlayer.cards.AddRange(cards);
            newPlayer.cards.Add(city);
            return newPlayer;
        }

        public Player removeCard(City city)
        {
            Player newPlayer = new Player(this);
            newPlayer.cards = new List<City>();
            newPlayer.cards.AddRange(cards);
            newPlayer.cards.Remove(city);
            return newPlayer;
        }

        public String ToLongDescr()
        {
            String s;
            s = "Player " + (playernum + 1).ToString() + " ";
            if (isAI)
            {
                s += " AI player ";
            }
            else s += " Human player ";

            s += " Current pos" + position;

            s += " Cards in hand ";
            foreach (City c in cards)
            {
                s += c.ToString() + " ";
            }

            return s;
        }
        public override String ToString()
        {
            return (playernum + 1).ToString();
        }
    }
}
