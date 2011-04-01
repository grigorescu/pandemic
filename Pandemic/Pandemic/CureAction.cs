using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

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
            Debug.Assert(debug_gs == null || debug_gs == current, "Action used on an unintended gamestate");
            Map newMap = current.map.removeDisease(position, color);
            return new GameState(current, newMap);
        }
    }
}
