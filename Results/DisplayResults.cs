using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WordGame.Data;
using WordGame.Output;
using Microsoft.Extensions.DependencyInjection;

namespace WordGame.Results
{
    internal static class DisplayResults
    {
        readonly static IOutput output;
        static DisplayResults()
        {
            output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        }
        public static void DisplayResult(IList<GameResultItem> resultItems,string Title)
        {
            output.Clear();
            output.WriteLine($"{Title} for {resultItems.FirstOrDefault()?.Difficulty}");
            output.WriteLine("----------------------------------------------");
            output.WriteLine("|    Player    | Score |         Date        |");
            output.WriteLine("----------------------------------------------");
            foreach(var item in resultItems)
            {
                output.WriteLine(String.Format("| {0,-12} | {1,-5} | {2,-19} |", item.PlayerName, item.Score, item.DateTime));
                output.WriteLine("----------------------------------------------");
            }
            output.WriteLine();
            output.WriteLine("Press Enter key to continue...");
            output.ReadLine();
        }
    }
}
