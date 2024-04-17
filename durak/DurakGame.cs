//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)



/*
File: DurakGame.cs
Description: Defines the DurakGame class representing the main game logic for a Durak card game.
*/

using System;
using System.Collections.Generic;

namespace durak
{
    // Represents a game of Durak with its associated game logic and state.
    public class DurakGame
    {
        // The deck of cards used in the game.
        private Deck deck;

        // List of players participating in the game.
        private List<Player> players;

        // Cards currently on the table.
        private List<Card> table;

        // The suit that is declared as the trump suit for the game.
        private Suit trumpSuit;

        // Initializes a new instance of the DurakGame class.
        // playerNames: List of names of the players participating in the game.
        public DurakGame(List<string> playerNames)
        {
            deck = new Deck();
            deck.Shuffle();
            players = new List<Player>();

            // Create players with provided names.
            foreach (string name in playerNames)
            {
                players.Add(new Player(name));
            }

            table = new List<Card>();

            // Deal cards to players and determine the trump card.
            Deal();
            DetermineTrumpCard();
        }

        // Determines the trump card for the game.
        private void DetermineTrumpCard()
        {
            Card trumpCard = deck.Deal();
            Console.WriteLine($"Trump card is: {trumpCard}");
            trumpSuit = trumpCard.Suit;
        }

        // Deals cards to players.
        private void Deal()
        {
            // Deal 6 cards to each player.
            for (int i = 0; i < 6; i++)
            {
                foreach (Player player in players)
                {
                    player.AddCardToHand(deck.Deal());
                }
            }
        }

        // Executes a single round of the game.
        public void PlayRound()
        {
            // Implement game logic for playing a round
           
        }

        // Displays the cards currently on the table.
        public void DisplayTable()
        {
            Console.WriteLine("Cards on the table:");
            foreach (Card card in table)
            {
                Console.WriteLine(card);
            }
        }

        // Displays the hands of all players.
        public void DisplayHands()
        {
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.Name}'s hand:");
                foreach (Card card in player.Hand)
                {
                    Console.WriteLine(card);
                }
                Console.WriteLine();
            }
        }
    }
}
