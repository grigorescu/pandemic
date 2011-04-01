using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    class MoveToCardAction : Action
    {

        Player player;
        City card;

        public MoveToCardAction(Player player, City card)
        {
            this.player = player;
            this.card = card;
        }

        public override GameState execute(GameState current)
        {
            Player newPlayer = new Player(card, player);
            newPlayer = newPlayer.removeCard(card);
            return new GameState(current, newPlayer);
        }

        public static List<MoveToCardAction> actionsForPlayer(Player p)
        {
            List<MoveToCardAction> results = new List<MoveToCardAction>();
            foreach (City c in p.cards)
            {
                results.Add(new MoveToCardAction(p, c));
            }
            return results;
        }
    }
}
