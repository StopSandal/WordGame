using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Xml.Serialization;
using WordGame.Output;


namespace WordGame.InputReaders
{
    internal static class FilePathReader
    {
        readonly static IOutput output;
        static FilePathReader()
        {
           output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        }

        public static string GetFilePath()
        {
            DisplayHeader();

            output.WriteLine("Enter the path to the CSV file:");
            string csvFilePath = output.ReadLine();
            try
            {
                if (string.IsNullOrEmpty(csvFilePath))
                {
                    throw new ArgumentException("File path cannot be empty.");
                }
                if (!File.Exists(csvFilePath))
                {
                    throw new FileNotFoundException($"File not found: {csvFilePath}");
                }
                string extension = Path.GetExtension(csvFilePath);
                if (extension.ToLower() != ".csv")
                {
                    throw new ArgumentException("Invalid file type. Please select a CSV file.");
                }
            }
            catch (ArgumentException ex) 
            {
                DisplayError(ex.Message);
                return String.Empty;
            }
            catch (FileNotFoundException ex) 
            {
                DisplayError(ex.Message);
                return String.Empty;
            }
            return csvFilePath;
        }

        private static void DisplayHeader()
        {
            output.Clear();
            output.WriteLine("Write full path to file");
            output.WriteLine("Example: C:\\Users\\UserName\\file.csv");
        }
        private static void DisplayError(string message)
        {
            output.WriteLine($"Error: {message}");
            output.WriteLine("Press Enter to continue...");
            output.ReadLine();
        }
    }
}
