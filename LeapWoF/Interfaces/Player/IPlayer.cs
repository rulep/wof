using System;
using System.Collections.Generic;

namespace LeapWoF.Interfaces.Player
{
    /// <summary>
    ///  The IUser interface, represents game users.
    /// </summary>
    public interface IPlayer
    {

        /// <summary>
        /// Returns the player's name.
        /// </summary>
        string GetPlayerName();

        /// <summary>
        /// Returns the total prize money from the current round
        /// </summary>
        int GetRoundPoints();

        /// <summary>
        /// Returns the total prize money banked for the game
        /// </summary>
        int GetTotalPoints();

        /// <summary>
        /// Adds a guess to the userGuesses list.
        /// </summary>
        /// <param name="guess">
        /// The guess made by the user.
        /// </param>
        void UpdateRoundPoints(int prize);

        /// <summary>
        /// Adds a guess to the userGuesses list.
        /// </summary>
        /// <param name="guess">
        /// The guess made by the user.
        /// </param>
        void UpdateTotalPoints(int roundTotal);

        /// <summary>
        /// Adds a guess to the userGuesses list.
        /// </summary>
        /// <param name="guess">
        /// The guess made by the user.
        /// </param>
        void UserGuess(string guess);

        void ClearRoundPoints();
        
        void ClearTotalPoints();

        /// <summary>
        /// Shows all previous user guesses
        /// </summary>
        /// <returns>
        /// The list of guesses made by the user
        /// </returns>
        List<string> ShowUserGuesses();
    }
}