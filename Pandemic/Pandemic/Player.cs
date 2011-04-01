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
        public City position
        {
            get
            {
                return _position;
            }
        }

        public Player(City position, Player player)
           : this(position, player.playernum)
        {
        }

        public Player(City position, int playernum)
        {
            _position = position;
            this.playernum = playernum;
        }

        public List<Action> getActions()
        {
            return new List<Action>();
        }
    }
}
