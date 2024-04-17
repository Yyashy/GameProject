//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


/*
File: Player.cs
Description: Defines the Player class representing a player in a Durak card game.
*/

using System.Collections.Generic;

namespace durak
{
    // Represents a player in the Durak card game.
    public class Player
    {
        // The cards currently held by the player.
        public List<Card> Hand { get; private set; }

        // The name of the player.
        public string Name { get; private set; }

        // The role of the player in the game (Attacker or Defender).
        public string Role { get; set; }

        // Indicates whether it's the player's turn.
        public bool isTurn = false;

        // Initializes a new instance of the Player class with an empty hand.
        public Player()
        {
            Hand = new List<Card>();
        }

        // Initializes a new instance of the Player class with a specified name and an empty hand.
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        // Sets the role of the player.
        public void SetRole(string role)
        {
            Role = role;
        }

        // Adds a card to the player's hand.
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        // Adds multiple cards to the player's hand.
        public void AddCardsToHand(List<Card> cards)
        {
            Hand.AddRange(cards);
        }

        // Checks if the player has any cards in their hand.
        // Returns: True if the player has cards, otherwise false.
        public bool HasCards()
        {
            return Hand.Count > 0;
        }

        // Returns a string representation of the player's hand.
        public override string ToString()
        {
            return string.Join(", ", Hand);
        }
    }
}
