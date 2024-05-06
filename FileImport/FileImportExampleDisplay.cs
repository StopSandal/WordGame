using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.FileImport
{
    public static class FileImportExampleDisplay
    {
        public static void StartDisplay()
        {
            DisplayHeader();
            DisplayStep(() =>
            {
                Console.WriteLine("First you need to create a file with separate words in csv format by semicolon");
                Console.WriteLine("Example of csv-format: any;words;should;be;separated;");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("Next, you should choose file difficulty");
                Console.WriteLine("Example: 1. Medium");
            });
            DisplayStep(() =>
            {
                Console.WriteLine("Finally, you should write full path to the importing file");
                Console.WriteLine("Example: C:\\Users\\UserName\\file.csv");
            });
        }
        private static void DisplayHeader()
        {
            Console.Clear();
            Console.WriteLine("-------------------");
            Console.WriteLine("How to import file");
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
