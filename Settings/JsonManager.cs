using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WordGame.Settings
{
    public static class JsonManager
    {
        public static void SaveToFile<T>(string fileName, T value) where T : class
        {
            try
            {
                Debug.Write(fileName + "Saving to file");
                string jsonString = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(fileName, jsonString);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                Console.WriteLine($"Unable to save settings: {ex.Message}");
            }
        }

        public static T GetFromFile<T>(string fileName) where T : class
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in process of reading settings: {ex.Message}");
                return null;
            }
        }
    }
}
