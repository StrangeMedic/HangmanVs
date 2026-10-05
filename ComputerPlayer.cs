using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanVs
{
    internal class ComputerPlayer
    {
        private List<char> letters = new List<char>()
        {
            'a','b','c','d','e','f','g',
            'h','i','j','k','l','m','n',
            'o','p','q','r','s','q','w',
            't','y','u','z','x','v'
        };

        public void ComThread()
        {
            Random rand = new Random();

            while (this.isActive)
            {
                Thread.Sleep((int)(this.timeDelay * 1000));
                if (!this.isActive) { 
                    break; 
                }
                char randChar = letters[rand.Next(letters.Count)];

                this.lettersguessed += randChar;

                this.letters.Remove(randChar);

                manager.checkComAnswer("" + randChar, this.lettersguessed);

                manager.updateText();

            }
        }

        public string getGuessed()
        {
            return this.lettersguessed;
        }

        public HangmanManager manager;
        private bool isActive;
        private string lettersguessed;
        private double timeDelay;

        public void kill()
        {
            //This method halts the player thread from running anymore.
            //Or in other words, "kills" the thread.
            this.isActive = false;
        }

        public void start()
        {
            //This starts up the thread.
            Thread t = new Thread(ComThread);
            t.Start();
        }

        public ComputerPlayer(HangmanManager manager, double diff)
        {
            this.manager = manager;
            this.timeDelay = diff;
            this.lettersguessed = "";
            isActive = true;
        }
    }
}
