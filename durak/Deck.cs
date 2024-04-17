//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


/*
File: Deck.cs
Description: Defines the Deck class representing a deck of cards.
*/

using System;
using System.Collections.Generic;

namespace durak
{
    // Represents a deck of playing cards.
    public class Deck
    {
        // List of cards in the deck.
        public List<Card> cards;

        // Initializes a new instance of the Deck class and populates it with 52 standard playing cards.
        public Deck()
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

        // Shuffles the cards in the deck.
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }

        // Deals a single card from the deck.
        // Returns: The card dealt from the top of the deck.
        public Card Deal()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }
            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }

        // Deals a specified number of cards from the deck.
        // numberOfCards: The number of cards to deal.
        // Returns: A list of cards dealt from the top of the deck.
        public List<Card> Deal(int numberOfCards)
        {
            List<Card> dealtCards = new List<Card>();
            for (int i = 0; i < numberOfCards; i++)
            {
                dealtCards.Add(Deal());
            }
            return dealtCards;
        }
    }
}
