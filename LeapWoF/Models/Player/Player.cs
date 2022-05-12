using System;
using System.Collections.Generic;
using LeapWoF.Interfaces.Player;

namespace LeapWoF.Models.Player
{
	/// <summary>
    /// The User class. Implements the IUser interface.
    /// </summary>
	public class Player : IPlayer
	{
		/// <summary>
		/// User's name.
		/// </summary>
		public string name { get; set; }
		public int totalPoints { get; set; }
		public int roundPoints { get; set; }

		/// <summary>
        /// A collection of guesses made by the user.
        /// </summary>
		public List<string> userGuesses { get; private set; }

		//public User() : this("User 1");

		public Player(string _name)
		{
			name = _name;
			totalPoints = 0;
			roundPoints = 0;
		}

		/// <summary>
		/// Returns the player's name.
		/// </summary>
		public string GetPlayerName()
        {
			return name;
        }

		/// <summary>
		/// Returns the total prize money awarded to the player in the current round.
		/// </summary>
		public int GetRoundPoints()
        {
			return roundPoints;
        }

		/// <summary>
		/// Returns the total prize money banked by the player in the current game.
		/// </summary>
		public int GetTotalPoints()
		{
			return totalPoints;
		}

		/// <summary>
		/// On successful guess, updates the total points for the round.
		/// </summary>
		/// <param name="prize">The prize ammount awarded for a correct guess</param>
		public void UpdateRoundPoints(int prize)
        {
			roundPoints += prize;
        }

		/// <summary>
		/// Adds the prize money of the round's winner to their total winnings
		/// </summary>
		/// <param name="rounddTotal">The round winner's round total prize winnings</param>
		public void UpdateTotalPoints(int roundTotal)
        {
			totalPoints += roundTotal;
        }

		public void ClearRoundPoints()
        {
			roundPoints = 0;
        }


		public void ClearTotalPoints()
		{
			totalPoints = 0;
		}

		/// <summary>
		/// Adds guesses to the userGuesses list.
		/// </summary>
		/// <param name="guess">The user's guess</param>
		public void UserGuess(string guess)
        {
			userGuesses.Add(guess);

			return;
        }

		/// <summary>
        /// Returns the list of user guesses
        /// </summary>
        /// <returns></returns>
		public List<string> ShowUserGuesses()
        {
			return userGuesses;
        }
	}
}
