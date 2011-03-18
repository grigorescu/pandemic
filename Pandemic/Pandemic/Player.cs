using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class Player
    {
        private City _position;
        public City position
        {
            get
            {
                return _position;
            }
        }

        public Player(City position)
        {
            _position = position;
        }

        public List<Action> getActions()
        {
            return new List<Action>();
        }
    }
}
