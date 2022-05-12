using System;
using System.Collections.Generic;
using LeapWoF.Interfaces;
using System.Globalization;
using LeapWoF.Models;
using System.IO;
using System.Linq;
using LeapWoF.Models.Player;
using System.Security.AccessControl;

namespace LeapWoF
{

    /// <summary>
    /// The GameManager class, handles all game logic
    /// </summary>
    public class GameManager
    {

        /// <summary>
        /// The input provider
        /// </summary>
        private IInputProvider inputProvider;

        /// <summary>
        /// The output provider
        /// </summary>
        private IOutputProvider outputProvider;

        private int activePlayerIndex = 0; 
        private int totalRounds = 0;
        private int currentRound = 0;

        private string TemporaryPuzzle;
        private string[] dashes;

        public List<string> charGuessList = new List<string>();
        public List<Player> activePlayers = new List<Player>();

        public GameState GameState { get; private set; }

        public Wheel gameWheel;

        public GameManager() : this(new ConsoleInputProvider(), new ConsoleOutputProvider())
        {

        }

        public GameManager(IInputProvider inputProvider, IOutputProvider outputProvider)
        {
            if (inputProvider == null)
                throw new ArgumentNullException(nameof(inputProvider));
            if (outputProvider == null)
                throw new ArgumentNullException(nameof(outputProvider));

            this.inputProvider = inputProvider;
            this.outputProvider = outputProvider;

            GameState = GameState.WaitingToStart;

            gameWheel = new Wheel();
        }

        /// <summary>
        /// Manage game according to game state
        /// </summary>
        public void StartGame()
        {
            InitGame();

            while (true)
            {

                PerformSingleTurn();

                if (GameState == GameState.RoundOver)
                {
                    GameState = GameState.RoundStarted;
                    StartNewRound();
                    continue;
                }

                if (GameState == GameState.GameOver)
                {
                    outputProvider.Clear();
                    outputProvider.WriteLine("Game over");
                    // outputProvider.WriteLine("Need to insert total point, winner, etc.");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public void StartNewRound()
        {   
            charGuessList.Clear();

            if (GameState == GameState.RoundStarted && currentRound <= totalRounds)
            {
                currentRound += 1;
            }  
            if (GameState == GameState.GameOver && currentRound <= totalRounds)
            {
                GameState = GameState.RoundStarted;
                StartNewRound();
            }    
        }
        //public void StartNewRound()
        //{
            // update game state
            //currentRound++;
            //if (currentRound == numRounds + 1)
            //{
                //int winningPlayer = 0, max = 0;
        //public void StartNewRound()
        //{
            // update game state
            //currentRound++;
            //if (currentRound == numRounds + 1)
            //{
                //int winningPlayer = 0, max = 0;
                //for (int i = 0; i < playerList.Count; i++)
                //{
                    //if (max < playerList[i].GetTotalPoints))
                    //{
                        //winningPlayer = i;
                        //max = playerList[i].GetTotalPoints;
                    //}
                //}
                //outputProvider.WriteLine($"Congrats! {playerList[winningPlayer].Name}\n");
                //GameState = GameState.GameOver;
                //return;
            //}
            //else
                //puzzleBoard.NewRound();
            //GameState = GameState.RoundStarted;
        //}

        // display Player's Name, Current Earnings, and Total Earnings to the console
        //public void DisplayPoints()
        //{
            //outputProvider.Write (
                //$"Player {Name}: (Current Earnings) ${roundPoints}, (Total Earnings) ${totalPoints}\n"
            //);
        //}


        public void PerformSingleTurn()
        {
            DrawPuzzle();
            outputProvider.Write("Type 1 to spin, 2 to solve: ");
            GameState = GameState.WaitingForUserInput;

            var action = inputProvider.Read();

            switch (action)
            {
                case "1":
                    Spin();
                    break;
                case "2":
                    Solve();
                    break;
                default:
                    outputProvider.WriteLine();
                    outputProvider.WriteLine("Please type 1 or 2, press any key to continue...");

                    Console.ReadKey();
                    PerformSingleTurn();
                    break;
            }

            if (activePlayerIndex < activePlayers.Count - 1)
            {
                activePlayerIndex++;
            }
            else
            {
                activePlayerIndex = 0;
            }
        }

        /// <summary>
        /// Draw the puzzle
        /// </summary>
        private void DrawPuzzle(string userGuess = null, bool guess = false)
        {
            outputProvider.Clear();
            outputProvider.WriteLine("The puzzle is: ");
            outputProvider.WriteLine(TemporaryPuzzle);
            outputProvider.WriteLine();

            for (int i = 0; i < TemporaryPuzzle.Length; i++)
			{
               if (TemporaryPuzzle[i].ToString().ToLower() == userGuess || guess)
                {
                    dashes[i] = TemporaryPuzzle[i].ToString();
                } 
               else if (TemporaryPuzzle[i].ToString().ToLower() != userGuess && dashes[i] == null)
                {
                    dashes[i] = "-";
                }
			}
        
            Console.WriteLine($"Current Round: {currentRound}");
            Console.WriteLine($"Total Rounds: {totalRounds}\n");
            Console.WriteLine("{0}\n", String.Join("  ", dashes));
            charGuessList.Sort();
            Console.WriteLine("Guessed Letters: [ {0} ]\n", String.Join(", ", charGuessList));

            Console.WriteLine("Total Scores: ");
            foreach (var player in activePlayers)
	        {
                Console.WriteLine($"{player.GetPlayerName()}: {player.GetTotalPoints()}");
	        }

            Console.WriteLine("Round Scores: ");
            foreach (var player in activePlayers)
	        {
                Console.WriteLine($"{player.GetPlayerName()}: {player.GetRoundPoints()}");
	        }
           
            Console.WriteLine($"{activePlayers[activePlayerIndex].GetPlayerName()}'s turn!");
        }
        // updated to indicate current player and display current earnings for round
        //private void DrawPuzzle(bool guess = false) 
        //{
            //outputProvider.Clear();
            //for (var i = 0; i < playerList.Count; i++)
            //{
                //if (i == currentPlayer)
                    //outputProvider.Write("=>"); // indicate current player for round
                //playerList[i].DisplayPoints(); // show earnings for each player
            //}
            //outputProvider.WriteLine();
            //puzzleBoard.Draw(guess)
        //}

        /// <summary>
        /// Spin the wheel and do the appropriate action
        /// </summary>
        public void Spin()
        {
            outputProvider.WriteLine("Spinning the wheel...");
            Prize currentPrize = gameWheel.Spin();
            outputProvider.WriteLine($"Prize: {currentPrize.Name}");

            switch(currentPrize.Name)
            { 
                case "Lose A Turn":
                    break;

                case "Bankrupt":
                    activePlayers[activePlayerIndex].ClearRoundPoints();
                    break;
                
                default:
                    GuessLetter(currentPrize);
                    break;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public void Solve()
        {
            outputProvider.Write("Please enter your solution: ");
            var guess = inputProvider.Read();

            if (guess.ToLower() == TemporaryPuzzle.ToLower())
            {
                DrawPuzzle(null, true);
                outputProvider.WriteLine("Congratulations, you solved the puzzle.");
                outputProvider.WriteLine("Press any key to continue....");

                activePlayers[activePlayerIndex].UpdateTotalPoints(activePlayers[activePlayerIndex].GetRoundPoints());

                foreach (var player in activePlayers)
	            {
                    player.ClearRoundPoints();
	            }

                Console.ReadKey();

                // check to see if there are any rounds left
                if (currentRound < totalRounds)
                {
                    var word = GrabWord();
                    TemporaryPuzzle = word;
                    GameState = GameState.RoundOver;
                }
                else
                {
                    GameState = GameState.GameOver;
                }
            }
        }
        public void GuessLetter(Prize turnPrize)
        {
            outputProvider.Write("Please guess a letter: ");
            var guess = inputProvider.Read();
            int charCount = 0;
            try
            {
                char guessChar = Convert.ToChar(guess.ToLower());
                charCount = TemporaryPuzzle.Count(c => Char.ToLower(c) == guessChar);
                outputProvider.Clear();
                DrawPuzzle(guess.ToLower());
                charGuessList.Add(guess);
            }
            catch
            {
                outputProvider.WriteLine("Sorry, I couldn't convert your guess to a letter. Please guess a valid letter");
                GuessLetter(turnPrize);
            }
            if(charCount > 0)
            {
                outputProvider.WriteLine("Correct!");
                int reward = charCount * turnPrize.Value;
                outputProvider.WriteLine($"There {(charCount > 1 ? "are" : "is")} {charCount} \"{guess.ToUpper()}\"s in the puzzle.");
                // TODO: Add reward to player's moolah
                activePlayers[activePlayerIndex].UpdateRoundPoints(turnPrize.Value);
            }
            else
            {
                outputProvider.WriteLine("Incorrect!");
                outputProvider.WriteLine($"There is no {guess} in puzzle.");
            }
        }

        /// <summary>
        /// Optional logic to accept configuration options
        /// </summary>
        public void InitGame()
        {
            var word = GrabWord();
            TemporaryPuzzle = word;
            outputProvider.WriteLine("Welcome to...");
            outputProvider.WriteLine(@" _       ____              __         ____   ______           __                 
| |     / / /_  ___  ___  / /  ____  / __/  / ____/___  _____/ /___  ______  ___ 
| | /| / / __ \/ _ \/ _ \/ /  / __ \/ /_   / /_  / __ \/ ___/ __/ / / / __ \/ _ \
| |/ |/ / / / /  __/  __/ /  / /_/ / __/  / __/ / /_/ / /  / /_/ /_/ / / / /  __/
|__/|__/_/ /_/\___/\___/_/   \____/_/    /_/    \____/_/   \__/\__,_/_/ /_/\___/ 
                                                                                 ");
            outputProvider.WriteLine("Press any key to continue!");
            inputProvider.ReadKey();
            
            PlayerSelect();

            outputProvider.Write("\nPress select the number of rounds: ");
            var userInput = Console.ReadLine();
            int rounds;
            bool isTrue = Int32.TryParse(userInput, out rounds);
            if (isTrue) 
            {
                if (rounds > 0)
                {
                    totalRounds = rounds;
                    GameState = GameState.RoundStarted;
                    StartNewRound();
                }
                else
                {
                    outputProvider.WriteLine("\nPlease type in a number greater than 0.");
                    outputProvider.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    outputProvider.Clear();
                    InitGame();
                }

            } else
            {
                outputProvider.WriteLine("\nPlease type in a number.");
                outputProvider.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                outputProvider.Clear();
                InitGame();
            }
        }

        public string GrabWord()
        {
           List <string> words = new List<string>();
           string text = File.ReadAllText(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\wordList.txt"); 

            string characters = "";
            foreach (var t in text)
            {
                if (t.ToString() == " ")
                {
                    continue;
                }
                else if (t.ToString() != ",")
                {
                    characters += t;
                } 
                else if (t.ToString() == ",")
                {
                    words.Add(characters);  
                    characters = "";
                }
            }

            int idx = new Random().Next(0, words.Count);
            TemporaryPuzzle = words[idx];
            dashes = new string[words[idx].Length];
            return words[idx].Trim();
        }

        public void PlayerSelect()
        {
            outputProvider.Clear();
            int numberOfPlayers = 0;
            outputProvider.Write("Please enter the number of players: ");
            var inputPlayers = inputProvider.Read();
            bool inputPlayersCheck = (int.TryParse(inputPlayers, out numberOfPlayers));
            List<string> playerNames = new List<string>();

            if (inputPlayersCheck)
            {

                for (int i = 1; i <= numberOfPlayers; i++)
                {
                    outputProvider.Write($"Please enter Player {i}'s Name: ");
                    var inputName = inputProvider.Read();
                    var playerName = inputName.Trim();
                    playerNames.Add(playerName);
                }
            } else
            {
                outputProvider.WriteLine("Please enter a valid number");
                outputProvider.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                PlayerSelect();
            }

            foreach (string name in playerNames)
            {
                Player currPlayer = new Player(name);
                activePlayers.Add(currPlayer);
            }


        }
    }
}
