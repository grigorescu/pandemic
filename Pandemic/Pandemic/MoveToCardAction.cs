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
            GameState g = current.adjustPlayer(newPlayer);
            g.advanceMove();
            g = g.recalcBestCardHolder(g, newPlayer, card.color);
            return g;
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

        public override string ToString()
        {
            return "Move to (card) " + card.name;
        }
    }
}
