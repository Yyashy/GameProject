// DurakGame.cs
// Represents the Durak card game.
// Manages the game flow, player turns, and interactions between players.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Durak
{
    public class DurakGame
    {
        private Deck deck;
        private List<Player> players;
        private List<Card> tableCards;
        private Player attacker;
        private Player defender;

        // Initializes the game by creating a deck, dealing cards to players, and setting up initial players.
        public DurakGame(List<string> playerNames)
        {
            deck = new Deck();
            players = playerNames.Select(name => new Player(name)).ToList();
            tableCards = new List<Card>();

            // Deal cards to players
            foreach (Player player in players)
            {
                player.DrawCard(deck, 6);
            }

            // Set the first player as the attacker
            attacker = players[0];
            defender = GetNextPlayer(attacker);
        }

        // Gets the next player in the player rotation.
        private Player GetNextPlayer(Player currentPlayer)
        {
            int currentIndex = players.IndexOf(currentPlayer);
            int nextIndex = (currentIndex + 1) % players.Count;
            return players[nextIndex];
        }

        // Simulates the turns and interactions between players in the Durak card game.
        public void Play()
        {
            Console.WriteLine("Durak game started!\n");

            while (deck.Count > 0)
            {
                Console.WriteLine($"{attacker.Name} is attacking!");
                attacker.ShowHand();

                // Simulate attacker playing a card
                Card attackingCard = attacker.Hand.First();
                Console.WriteLine($"{attacker.Name} plays: {attackingCard}");

                // Simulate defender responding
                Card defendingCard = defender.Hand.FirstOrDefault(card => card.Rank == attackingCard.Rank);
                if (defendingCard != null)
                {
                    Console.WriteLine($"{defender.Name} defends with: {defendingCard}");
                    tableCards.Add(attackingCard);
                    tableCards.Add(defendingCard);

                    attacker.Hand.Remove(attackingCard);
                    defender.Hand.Remove(defendingCard);

                    Console.WriteLine("\nAttack successful!\n");
                }
                else
                {
                    Console.WriteLine($"{defender.Name} couldn't defend. They pick up the cards.\n");
                    defender.DrawCard(deck, tableCards.Count);
                    tableCards.Clear();
                }

                // Swap roles
                Player temp = attacker;
                attacker = defender;
                defender = temp;
            }

            Console.WriteLine("Durak game finished!");
        }
    }
}
