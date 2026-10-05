using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace HangmanVs
{
    internal class HangmanManager
    {
        private List<string> wordPool = new List<string>()
        {
            "Estranged",
            "Apple",
            "Horse",
            "Friendly",
            "Bothered",
            "Mindful",
            "Strange",
            "Nuanced",
            "Delta",
            "Medic",
            "Team",
            "Alpha",
            "Mystical",
            "Patient",
            "Unusual",
            "Weld",
            "Typcial",
        };

        public bool checkValidGuess(string guess, string lettersguessed)
        {
            bool isValid = true;

            if (guess.Length != 1)
            {
                Console.WriteLine("You can only guess a single character!");
                isValid = false;
            }
            else if (!Char.IsLetter(guess[0]))
            {
                Console.WriteLine("Your guess must be a alphabetic letter!");
                isValid = false;
            }
            else if (lettersguessed.Contains(guess[0]))
            {
                Console.WriteLine("You've already guessed that!");
                isValid = false;
            }

            return isValid;
        }

        public string UpdateWord(string lettersGuessed,int classId)
        {
            string result = "";


            if (classId == 1)//Fetch the player's word
            {
                for (int i = 0; i < playerWord.Length; i++)
                {
                    if (lettersGuessed.Contains(this.playerWord[i]))
                    {
                        result += this.playerWord[i];
                    }
                    else
                    {
                        result += "_";
                    }
                }
            } else//else, grab the ai's word.
            {
                for (int i = 0; i < this.aiWord.Length; i++)
                {
                    if (lettersGuessed.Contains(aiWord[i]))
                    {
                        result += this.aiWord[i];
                    }
                    else
                    {
                        result += "_";
                    }
                }
            }

            return result;
        }

        public string getWord()
        {
            string foundWord;

            Random rand = new Random();

            foundWord = wordPool[rand.Next(wordPool.Count)];

            return foundWord.ToLower();
        }

        public bool checkPlrAnswer(string guess, string allguesses)
        {
            bool wasCorrect = false;

            if (this.playerWord.Contains(guess[0]))
            {
                //Player got it right!
                wasCorrect = true;

                //Check if they won.
                bool playerWon = true;

                //Loop through every character in the answer and check if it's in the player's
                //guesses.
                for (int i = 0; i < this.playerWord.Length; i++)
                {
                    char currentChar = this.playerWord[i];

                    if (!allguesses.Contains(currentChar))
                    {
                        playerWon = false;
                    }
                }

                if (playerWon)
                {
                    plr.kill();
                    ai.kill();
                    Console.Clear();
                    Console.WriteLine("Player wins!");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
            }

            return wasCorrect;
        }

        public void checkComAnswer(string guess, string allguesses)
        {
            bool comWon = true;

            //Loop through every character in the answer and check if it's in the player's
            //guesses.
            for (int i = 0; i < this.aiWord.Length; i++)
            {
                char currentChar = this.aiWord[i];

                if (!allguesses.Contains(currentChar))
                {
                    comWon = false;
                }
            }

            if (comWon)
            {
                plr.kill();
                ai.kill();
                Console.Clear();
                Console.WriteLine("Computer wins!");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }

        public void updateText()
        {
            if ((!this.gameOver) && this.plr != null)
            {
                //Only print if game isn't over.
                Console.Clear();
                Console.WriteLine("============[Hangman VS]================");
                Console.WriteLine("Your word: " + UpdateWord(this.plr.getGuessed(),1));
                Console.WriteLine();
                Console.WriteLine("Computer's word: " + UpdateWord(this.ai.getGuessed(), 2));
                Console.WriteLine();
                Console.WriteLine("Type a letter to guess!");
            }
        }

        private Player plr;
        private ComputerPlayer ai;

        private string playerWord;
        private string aiWord;

        private bool gameOver = false;

        public void setPlayer(Player player)
        {
            this.plr = player;
        }

        public void setCom(ComputerPlayer player)
        {
            this.ai = player;
        }

        public HangmanManager()
        {
            playerWord = getWord();
            aiWord = getWord();
        }
    }
}
