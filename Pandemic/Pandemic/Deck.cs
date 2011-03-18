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
        public Random random;

        public Deck(List<Card> cards, Boolean isRandom = true)
        {
            drawDeck = new List<Card>();
            drawDeck.AddRange(cards);
            discardDeck = new List<Card>();
            if (isRandom)
            {
                random = new Random();
            }

            shuffle(drawDeck);
        }

        public List<Card> draw(int drawNum = 1)
        {
            List<Card> justDrew = new List<Card>();
            justDrew.AddRange(drawDeck.GetRange(0, drawNum));
            discardDeck.AddRange(drawDeck.GetRange(0, drawNum));
            drawDeck.RemoveRange(0, drawNum);

            return justDrew;
        }

        public List<Card> drawFromBottom()
        {
            List<Card> justDrew = new List<Card>();
            justDrew.AddRange(drawDeck.GetRange(drawDeck.Count-1, 1));
            discardDeck.AddRange(drawDeck.GetRange(drawDeck.Count - 1, 1));
            drawDeck.RemoveRange(drawDeck.Count - 1, 1);

            return justDrew;

        }

        public void shuffle(List<Card> deck)
        {
            if (random == null)
                return;
            
            Card temp1;
            Card temp2;
            int index;

            for (int i = 0; i < deck.Count - 1; i++)
            {
                temp1 = deck[i];
                index = random.Next(deck.Count - i)+i;
                temp2 = deck[index];
                deck[i] = temp2;
                deck[index] = temp1;
            }
        }

        public void returnShuffledDiscard()
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
