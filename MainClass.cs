using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanVs
{
    internal class MainClass
    {

        public static void Main(string[] args)
        {
            HangmanManager hm = new HangmanManager();

            Console.WriteLine("[Hangman Vs game]");
            Console.WriteLine("Please pick a difficulty:");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Normal");
            Console.WriteLine("3. Hard");

            ConsoleKey keyinput;

            do
            {
                keyinput = Console.ReadKey(false).Key;
            } while (keyinput != ConsoleKey.D1 && keyinput != ConsoleKey.D2 && keyinput != ConsoleKey.D3);

            double diff = 0;

            if (keyinput == ConsoleKey.D1)
            {
                diff = 5;
            } else if (keyinput == ConsoleKey.D2)
            {
                diff = 2.5;
            } else if (keyinput == ConsoleKey.D3)
            {
                diff = 0.75;
            }

            Player plr = new Player(hm);
            ComputerPlayer ai = new ComputerPlayer(hm,diff);
            hm.setPlayer(plr);
            hm.setCom(ai);
            plr.start();
            ai.start();
        }
    }
}
