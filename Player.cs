using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanVs
{
    internal class Player
    {
        private void playerThread()
        {
            manager.updateText();
            while (this.isActive)
            {
                string guess;

                do
                {
                    guess = Console.ReadLine().ToLower();
                } while (!manager.checkValidGuess(guess, this.lettersguessed));

                this.lettersguessed += guess;

                bool wasRight = manager.checkPlrAnswer(guess, this.lettersguessed);

                manager.updateText();

                if (!wasRight)
                {
                    Thread.Sleep(500);//Wait 0.5 second before allowing answers again.
                }

                //Console.WriteLine(this.lettersguessed);
            }
        }

        public string getGuessed()
        {
            return this.lettersguessed;
        }

        public HangmanManager manager;
        private bool isActive;
        private string lettersguessed;

        public void kill()
        {
            //This method halts the player thread from running anymore.
            //Or in other words, "kills" the thread.
            this.isActive = false;
        }

        public void start()
        {
            //This starts up the thread.
            Thread t = new Thread(playerThread);
            t.Start();
        }

        public Player(HangmanManager manager)
        {
            this.manager = manager;
            this.lettersguessed = "";
            isActive = true;
        }
    }
}
