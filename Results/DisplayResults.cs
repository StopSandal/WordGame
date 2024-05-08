using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WordGame.Data;

namespace WordGame.Results
{
    internal static class DisplayResults
    {
        public static void DisplayResult(IList<GameResultItem> resultItems,string Title)
        {
            Console.Clear();
            Console.WriteLine($"{Title} for {resultItems.FirstOrDefault()?.Difficulty}");
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|    Player    | Score |         Date        |");
            Console.WriteLine("----------------------------------------------");
            foreach(var item in resultItems)
            {
                Console.WriteLine(String.Format("| {0,-12} | {1,-5} | {2,-19} |", item.PlayerName, item.Score, item.dateTime));
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
