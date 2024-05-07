using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Game
{
    public static class GameRulesExampleDisplay
    {
        public static void StartDisplay()
        {
            DisplayHeader();
            DisplayStep(() =>
            {
                Console.WriteLine("After starting the game, on the screen will appear words from a random dictionary.");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("Then, you need to type these words as fast​ as you can.");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("Next, when you finally write all words, you should press Enter to check it.");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("Then, new words will appear. If you write previous words correctly, you will get the same score");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("When the timer is gone, you will see the final result.");
            });
        }
        private static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            Console.WriteLine("    How to play    ");
            Console.WriteLine("-------------------");
        }
        private static void NextStep()
        {
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        private static void DisplayStep(Action stepInto)
        {
            stepInto();
            NextStep();
        }
    }
}
