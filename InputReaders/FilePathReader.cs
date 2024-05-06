using System;
using System.Diagnostics;
using System.Xml.Serialization;


namespace WordGame.InputReaders
{
    internal static class FilePathReader
    {
        public static string GetFilePath()
        {
            DisplayHeader();

            Console.WriteLine("Enter the path to the CSV file:");
            string csvFilePath = Console.ReadLine();
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
            Console.Clear();
            Console.WriteLine("Write full path to file");
            Console.WriteLine("Example: C:\\Users\\UserName\\file.csv");
        }
        private static void DisplayError(string message)
        {
            Console.WriteLine($"Error: {message}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
