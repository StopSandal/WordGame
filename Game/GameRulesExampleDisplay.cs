using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;
using Microsoft.Extensions.DependencyInjection;

namespace WordGame.Game
{
    public static class GameRulesExampleDisplay
    {
        readonly static IOutput output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        public static void StartDisplay()
        {
            DisplayHeader();
            DisplayStep(() =>
            {
                output.WriteLine("After starting the game, on the screen will appear words from a random dictionary.");
            });
            DisplayStep(() =>
            {
                output.WriteLine("Then, you need to type these words as fast​ as you can.");
            });
            DisplayStep(() =>
            {
                output.WriteLine("Next, when you finally write all words, you should press Enter to check it.");
            });
            DisplayStep(() =>
            {
                output.WriteLine("Then, new words will appear. If you write previous words correctly, you will get the same score");
            });
            DisplayStep(() =>
            {
                output.WriteLine("When the timer is gone, you will see the final result.");
            });
        }
        private static void DisplayHeader()
        {
            output.Clear();
            output.WriteLine("-------------------");
            output.WriteLine("    How to play    ");
            output.WriteLine("-------------------");
        }
        private static void NextStep()
        {
            output.WriteLine("Press Enter to continue...");
            output.ReadLine();
        }
        private static void DisplayStep(Action stepInto)
        {
            stepInto();
            NextStep();
        }
    }
}
