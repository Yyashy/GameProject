//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


/*
File: Game.cs
Description: Defines the Game class representing the core logic for a Durak card game session.
*/

using System;
using System.Collections.Generic;

namespace durak                                                                                                                                                                 
{
    // Represents a single session of a Durak card game with its associated game logic and state.
    internal class Game
    {
        // The deck of cards used in the game.
        public Deck deck;

        // The human player participating in the game.
        public Player player;

        // The computer opponent in the game.
        public Player computer;

        // The trump card for the current game session.
        public Card trumpCard;

        // The player who is currently attacking.
        public Player attacker;

        // The player who is currently defending.
        public Player defender;

        // Initializes a new instance of the Game class.
        public Game()
        {
            deck = new Deck();
            deck.Shuffle();

            player = new Player();
            computer = new Player();

            // Deal cards to player and computer
            player.AddCardsToHand(deck.Deal(6));
            computer.AddCardsToHand(deck.Deal(6));

            // Determine the trump card
            trumpCard = deck.cards[deck.cards.Count - 1];
        }

        // Draws cards for both the player and the computer to reach a hand size of 6.
        public void DrawCards()
        {
            int player_cards_to_add = 6 - player.Hand.Count;
            int computer_cards_to_add = 6 - computer.Hand.Count;

            while (player_cards_to_add > 0 || computer_cards_to_add > 0)
            {
                if (deck.cards.Count <= 0)
                {
                    break;
                }
                if (player_cards_to_add > 0)
                {
                    DrawCardForPlayer();
                    player_cards_to_add--;
                }
                if (computer_cards_to_add > 0)
                {
                    DrawCardForComputer();
                    computer_cards_to_add--;
                }
            }
        }

        // Draws a card for the player from the deck.
        private void DrawCardForPlayer()
        {
            if (deck.cards.Count > 0)
            {
                player.AddCardToHand(deck.Deal());
            }
        }

        // Draws a card for the computer from the deck.
        private void DrawCardForComputer()
        {
            if (deck.cards.Count > 0)
            {
                computer.AddCardToHand(deck.Deal());
            }
        }

        // Determines the attacker and defender for the current round.
        public void DetermineAttackerAndDefender(List<Card> playerHand, List<Card> computerHand)
        {
            // Sort the player's hand by rank
            playerHand.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank));

            // Sort the computer's hand by rank
            computerHand.Sort((card1, card2) => card1.Rank.CompareTo(card2.Rank));

            // Check for trump cards in the player's hand
            List<Card> playerTrumpCards = playerHand.FindAll(card => card.Suit == trumpCard.Suit);

            // Check for trump cards in the computer's hand
            List<Card> computerTrumpCards = computerHand.FindAll(card => card.Suit == trumpCard.Suit);

            if (playerTrumpCards.Count > 0 && computerTrumpCards.Count > 0)
            {
                // Attacker is the player with the lowest trump card
                if (playerTrumpCards[0].Rank < computerTrumpCards[0].Rank)
                {
                    attacker = player;
                    defender = computer;
                }
                else
                {
                    attacker = computer;
                    defender = player;
                }
            }
            else if (playerTrumpCards.Count > 0)
            {
                // Player has trump cards, so player is the attacker
                attacker = player;
                defender = computer;
            }
            else if (computerTrumpCards.Count > 0)
            {
                // Computer has trump cards, so computer is the attacker
                attacker = computer;
                defender = player;
            }
            else
            {
                // Neither has trump cards, determine based on leading suit
                attacker = player;
                defender = computer;
            }
        }

        // Displays the current game information, including the trump card and the roles of the players.
        public void DisplayGameInfo()
        {
            Console.WriteLine($"Trump card: {trumpCard}");
            Console.WriteLine($"Attacker: {(attacker == player ? "Player" : "Computer")}");
            Console.WriteLine($"Defender: {(defender == player ? "Player" : "Computer")}");
        }

        // Handles an attack action by the player.
        public void Attack(Player player, Card card)
        {
            attacker = player;
            defender = computer;
            // Implement attack logic
        }

        // Handles a defense action by the player.
        // Returns true if the defense is successful, otherwise false.
        public bool Defend(Player player, Card attackCard, Card defendCard)
        {
            if (defendCard.Suit == trumpCard.Suit && attackCard.Suit != trumpCard.Suit)
            {
                // Trump card beats non-trump card
                return true;
            }
            else if (defendCard.Suit == attackCard.Suit && defendCard.Rank > attackCard.Rank)
            {
                // Higher rank card of the same suit beats the attacking card
                return true;
            }
            return false;
        }

        // Transfers cards from the table to the player's hand.
        public void TakeCards(Player player, List<Card> cards)
        {
            foreach (Card card in cards)
            {
                player.AddCardToHand(card);
            }
        }
    }
}
