using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;

namespace WordGame.InputReaders
{
    internal static class NumericReader
    {
        readonly static IOutput output;
        static NumericReader()
        {
            output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        }
        public static int GetNumberFromConsole()
        {
            int result;
            while (!int.TryParse(output.ReadLine(), out result))
            {
                output.WriteLine("Wrong input. Try again.");
            }
            
            return result;
        }
    }
}
