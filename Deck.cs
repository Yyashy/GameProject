// Deck.cs
// Represents a deck of playing cards.
// Handles the initialization, shuffling, and drawing of cards.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Durak
{
    public class Deck
    {
        private List<Card> cards;

        // Gets the number of cards remaining in the deck.
        public int Count => cards.Count;
        public Deck()
        {
            InitializeDeck();
            Shuffle();
        }

        private void InitializeDeck()
        {
            cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        private void Shuffle()
        {
            Random random = new Random();
            cards = cards.OrderBy(card => random.Next()).ToList();
        }

        public Card DrawCard()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("No cards left in the deck.");
            }

            Card drawnCard = cards.First();
            cards.RemoveAt(0);
            return drawnCard;
        }
    }
}
