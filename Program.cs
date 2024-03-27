// Program.cs
// Entry point for the Durak card game application.
// Creates an instance of the DurakGame class and starts the game.
using System;
using System.Collections.Generic;

namespace Durak
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            List<string> playerNames = new List<string> { "Player1", "Player2", "Player3" };
            DurakGame durakGame = new DurakGame(playerNames);
            durakGame.Play();
        }
    }
}
