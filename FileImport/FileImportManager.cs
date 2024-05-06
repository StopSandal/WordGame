using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordGame.Data;
using WordGame.Settings;

namespace WordGame.FileImport
{
    internal static class FileImportManager
    {
        static readonly string AppName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        public static async void SaveFile(string filename, Difficulty difficulty)
        {
            try
            {
                Task<IList<string>> loadFile = LoadFileAsync(filename);

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string dictionaryPath = Path.Combine(
                    appDataPath,
                    AppName,
                    "dictionary",
                    difficulty.ToString()
                    );
                Directory.CreateDirectory(dictionaryPath);

                var directoryInfo = new DirectoryInfo(dictionaryPath);
                directoryInfo.Attributes |= FileAttributes.Hidden;

                string filePath = Path.Combine(dictionaryPath, $"{Guid.NewGuid()}.json");

                var words = await loadFile;
                using ( var fileStream = new FileStream(filePath,FileMode.OpenOrCreate))
                {
                    JsonSerializer.Serialize<IList<string>>(fileStream, words);
                }
                Console.WriteLine("File was successfully imported");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing dictionary: {ex.Message}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        private static async Task<IList<string>> LoadFileAsync(string filename) {
            List<string> words = new List<string>();
            try
            {
                var lineList = File.ReadLinesAsync(filename);
                await foreach (string line in lineList)
                {
                    string[] lineWords = line.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    words.AddRange(lineWords);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
            return words;
        }
        
        public static void GetGameFile(Difficulty difficulty) 
        { 
        
        }
    }
}
