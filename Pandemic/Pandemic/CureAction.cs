using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class CureAction : Action
    {

        City position;
        DiseaseColor color;

        public CureAction(City position, DiseaseColor color)
        {
            this.position = position;
            this.color = color;
        }

        public override GameState execute(GameState current)
        {
            Map newMap = current.map.removeDisease(position, color);
            return new GameState(current, newMap);
        }
    }
}
