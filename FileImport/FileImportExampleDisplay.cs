using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Menus;
using WordGame.Output;

namespace WordGame.FileImport
{
    public static class FileImportExampleDisplay
    {
        readonly static IOutput output;
        static FileImportExampleDisplay()
        {
            output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        }
        public static void StartDisplay()
        {
            DisplayHeader();
            DisplayStep(() =>
            {
                output.WriteLine("First you need to create a file with separate words in csv format by semicolon");
                output.WriteLine("Example of csv-format: any;words;should;be;separated;");
            });
            DisplayStep(() =>
            {
                output.WriteLine("Next, you should choose file difficulty");
                output.WriteLine("Example: 1. Medium");
            });
            DisplayStep(() =>
            {
                output.WriteLine("Finally, you should write full path to the importing file");
                output.WriteLine("Example: C:\\Users\\UserName\\file.csv");
            });
        }
        private static void DisplayHeader()
        {
            output.Clear();
            output.WriteLine("-------------------");
            output.WriteLine("How to import file");
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
