// Player.cs
// Represents a player in the Durak card game.
// Contains information about the player's name and hand of cards.

using System;
using System.Collections.Generic;

namespace Durak
{
    public class Player
    {
        public string Name { get; }
        public List<Card> Hand { get; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        // Draws a specified number of cards from the deck and adds them to the player's hand.
        public void DrawCard(Deck deck, int numCards)
        {
            for (int i = 0; i < numCards; i++)
            {
                Hand.Add(deck.DrawCard());
            }
        }

        // Displays the cards in the player's hand.
        public void ShowHand()
        {
            Console.WriteLine($"{Name}'s hand:");
            foreach (Card card in Hand)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
        }
    }

}
