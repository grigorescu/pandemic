using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pandemic
{
    public class Deck<Card>
    {
        public List<Card> drawDeck;
        public List<Card> discardDeck;
        public List<int> epidemicCards;
        public int cardWeAreOn = 0;
        public Boolean  isRandom;
        private static Random random = new Random();
        Boolean isPlayerDeck;
        public Boolean isOverdrawn;

        public Deck(IEnumerable<Card> cards, Boolean isRandom = true, Boolean isPlayerDeck = false)
        {
            drawDeck = new List<Card>();
            drawDeck.AddRange(cards);
            discardDeck = new List<Card>();
            this.isRandom = isRandom;

            this.isPlayerDeck = isPlayerDeck;

            if (isPlayerDeck)
            {
                epidemicCards = new List<int>();
            }
            shuffle(drawDeck);
            isOverdrawn = false;
        }

        private Deck(Deck<Card> old)
        {
            drawDeck = new List<Card>();
            drawDeck.AddRange(old.drawDeck);
            discardDeck = new List<Card>();
            discardDeck.AddRange(old.discardDeck);
            isPlayerDeck = old.isPlayerDeck;
            epidemicCards = old.epidemicCards;
            cardWeAreOn = old.cardWeAreOn;
            isOverdrawn = old.isOverdrawn;
        }

        public Boolean isNextCardEpidemic()
        {
            if (isPlayerDeck)
            {
                foreach (int i in epidemicCards)
                {
                    if (i == cardWeAreOn + 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public Deck<Card> draw(int drawnum = 1)
        {
            Deck<Card> result = new Deck<Card>(this);
            result.draw_m(drawnum);
            return result;
        }

        private void draw_m(int drawNum)
        {
            List<Card> justDrew = new List<Card>();
            if (drawNum > drawDeck.Count)
            {
                isOverdrawn = true;
                discardDeck = null;
                return;
            }
            justDrew.AddRange(drawDeck.GetRange(0, drawNum));
            discardDeck.AddRange(drawDeck.GetRange(0, drawNum));
            drawDeck.RemoveRange(0, drawNum);
            cardWeAreOn += drawNum;
        }

        public Deck<Card> drawFromBottom()
        {
            Deck<Card> result = new Deck<Card>(this);
            result.drawFromBottom_m();
            return result;
        }

        private void drawFromBottom_m()
        {
            List<Card> justDrew = new List<Card>();
            if (drawDeck.Count == 0)
            {
                isOverdrawn = true;
                discardDeck = null;
                return;
            }
            justDrew.AddRange(drawDeck.GetRange(drawDeck.Count - 1, 1));
            discardDeck.AddRange(drawDeck.GetRange(drawDeck.Count - 1, 1));
            drawDeck.RemoveRange(drawDeck.Count - 1, 1);
        }

        public List<Card> mostRecent(int n)
        {
            return discardDeck.GetRange(discardDeck.Count - n, n);
        }

        public void shuffle(List<Card> deck)
        {
            if (!isRandom)
                return;

            Card temp1;
            Card temp2;
            int index;

            for (int i = 0; i < deck.Count - 1; i++)
            {
                temp1 = deck[i];
                index = random.Next(deck.Count - i) + i;
                temp2 = deck[index];
                deck[i] = temp2;
                deck[index] = temp1;
            }
        }

        public Deck<Card> returnShuffledDiscard()
        {
            Deck<Card> result = new Deck<Card>(this);
            result.returnShuffledDiscard_m();
            return result;
        }

        private void returnShuffledDiscard_m()
        {
            shuffle(discardDeck);
            drawDeck.InsertRange(0, discardDeck);
            discardDeck.RemoveRange(0, discardDeck.Count);
        }

        public void printDeck()
        {
            Console.WriteLine("Draw Deck");

            foreach (Card c in drawDeck)
            {
                Console.WriteLine(c.ToString());
            }

            Console.WriteLine("Discard Deck");

            foreach (Card c in discardDeck)
            {
                Console.WriteLine(c.ToString());
            }
        }

    }
}
