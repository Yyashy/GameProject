//Group 2 (Yash,Sumit Jain, Syed)
//Yash(100892788)
//Sumit Jain(100890788)
//Syed (100677016)


/*
File: Card.cs
Description: Defines the Card class and related enums for a card game.
*/

using System;
using System.Diagnostics;

namespace durak
{
    // Enumeration representing the four standard suits in a deck of cards.
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    // Enumeration representing the ranks of cards, starting from Six to Ace.
    public enum Rank
    {
        Six = 6,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    // Represents a playing card with a suit and a rank.
    public class Card
    {
        // Gets the suit of the card.
        public Suit Suit { get; }

        // Gets the rank of the card.
        public Rank Rank { get; }

        // Initializes a new instance of the Card class.
        // suit: The suit of the card.
        // rank: The rank of the card.
        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        // Returns a string representation of the card.
        // A string containing the rank and suit of the card.
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        // Gets the image path of the card based on its rank and suit.
        // A string representing the image path of the card.
        public string GetImagePath()
        {
            string rankName = GetRankName(Rank);
            string suitName = GetSuitName(Suit);
            Debug.Print($"{rankName}_of_{suitName}");
            return $"{rankName}_of_{suitName}";
        }

        // Retrieves the name of the rank as a string.
        // rank: The rank of the card.
        // A string representing the name of the rank.
        private static string GetRankName(Rank rank)
        {
            switch (rank)
            {
                case Rank.Six:
                    return "_6";
                case Rank.Seven:
                    return "_7";
                case Rank.Eight:
                    return "_8";
                case Rank.Nine:
                    return "_9";
                case Rank.Ten:
                    return "_10";
                case Rank.Jack:
                    return "jack";
                case Rank.Queen:
                    return "queen";
                case Rank.King:
                    return "king";
                case Rank.Ace:
                    return "ace";
                default:
                    throw new ArgumentException($"Invalid rank: {rank}");
            }
        }

        // Retrieves the name of the suit as a string.
        // suit: The suit of the card.
        // A string representing the name of the suit.
        private static string GetSuitName(Suit suit)
        {
            switch (suit)
            {
                case Suit.Hearts:
                    return "hearts";
                case Suit.Diamonds:
                    return "diamonds";
                case Suit.Clubs:
                    return "clubs";
                case Suit.Spades:
                    return "spades";
                default:
                    throw new ArgumentException($"Invalid suit: {suit}");
            }
        }
    }
}
