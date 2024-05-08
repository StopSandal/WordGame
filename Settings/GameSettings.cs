using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Settings
{
    internal class GameSettings
    {
        private static Settings settings;
        private GameSettings() { 
        
        }
        public static Settings GetSettings()
        {
            if(settings == null)
            {
                settings = JsonManager.GetFromFile<Settings>("GameSettings.ini");
                settings ??= new Settings();
            }
            return settings;
        }
    }
}
