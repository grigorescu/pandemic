using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    abstract public class Action
    {
        //used by debugging
        public GameState debug_gs;

        public abstract GameState execute(GameState current);
    }
}
