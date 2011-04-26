using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    class TradeAction : Action
    {

        public Player from;
        public Player to;
        public City card;

        private TradeAction(Player from, Player to, City card)
        {
            this.from = from;
            this.to = to;
            this.card = card;
        }

        public override GameState execute(GameState gs)
        {
            Player newFrom = from.removeCard(card);
            Player newTo = to.addCard(card);
            gs = gs.adjustPlayer(newFrom);
            gs = gs.recalcBestCardHolder(gs, newFrom, card.color);
            gs = gs.adjustPlayer(newTo);
            gs = gs.recalcForAddCard(newTo, card);
  
            gs.advanceMove();
            return gs;
        }

        public static List<TradeAction> getTrades(GameState gs)
        {
            List<TradeAction> result = new List<TradeAction>();
            City card = gs.currentPlayer().position;
            List<Player> partners = new List<Player>();
            Player trader = null;
            foreach(Player p in gs.players)
            {
                if (p.position == card)
                {
                    if (p.cards.Contains(card))
                    {
                        trader = p;
                    }
                    else
                    {
                        partners.Add(p);
                    }
                }
            }
            if(trader == null) return result;
            foreach(Player p in partners)
            {
                result.Add(new TradeAction(trader, p, card));
            }
            return result;
        }

        public override string ToString()
        {
            return "Trading card: " + card.name + " from player: "+ from.playernum.ToString() + " to player: " + to.playernum.ToString();
        }
    }
}
