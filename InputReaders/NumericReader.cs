using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.InputReaders
{
    internal static class NumericReader
    {
        public static int GetNumberFromConsole()
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Wrong input. Try again.");
            }
            
            return result;
        }
    }
}
