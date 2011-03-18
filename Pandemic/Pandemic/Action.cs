using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    abstract public class Action
    {
        public abstract GameState execute(GameState current);
    }
}
