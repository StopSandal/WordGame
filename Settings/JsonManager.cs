using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Extensions.DependencyInjection;
using WordGame.Output;

namespace WordGame.Settings
{
    public static class JsonManager
    {
        readonly static IOutput output;
        static JsonManager()
        {
            output = WordAppServiceProvider.GetServiceProvider().GetService<IOutput>();
        }
        public static void SaveToFile<T>(string fileName, T value) where T : class
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllTextAsync(fileName, jsonString);
            }
            catch (Exception ex)
            {
                output.WriteLine($"Unable to save settings: {ex.Message}");
            }
        }

        public static T GetFromFile<T>(string fileName) where T : class
        {
            try
            {
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllTextAsync(fileName).Result;
                    return JsonConvert.DeserializeObject<T>(jsonString);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                output.WriteLine($"Error in process of reading settings: {ex.Message}");
                return null;
            }
        }
    }
}
