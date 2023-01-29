using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTT.Core.Numerics;

namespace TTT
{
    public interface IGame
    {
        public string CurrentPlayer { get; }
        /// <summary>
        /// Makes the turn for the current player.
        /// </summary>
        /// <returns>True if the turn was accepted, false if it was not (out of bounds etc)</returns>
        public bool TryMakeTurn(int index, out string reason);

        /// <summary>
        /// Moves the current player to the next player and checks to see if the game is over
        /// </summary>
        /// <returns>True if the game can continue and the next player has been selected, false if the game cannot.</returns>
        public bool NextTurn();

        /// <summary>
        /// Outputs the winners name.
        /// </summary>
        /// <returns>True if there is a winner, false if stalemate.</returns>
        public bool TryGetWinner(out string winnerName);
        /// <summary>
        /// Returns the print rules for players to read.
        /// </summary>
        public string GetRules();

    }
}
