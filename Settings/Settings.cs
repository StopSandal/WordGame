using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WordGame.Settings
{
    [Serializable]
    internal class Settings
    {
        [JsonProperty]
        private Difficulty difficulty;
        [JsonProperty]
        private int gameTime;
        [JsonProperty]
        private int wordCount;
        public Settings()
        {
            difficulty = Difficulty.Medium;
            gameTime = 30;
            wordCount = 1;
        }

        public Difficulty GetDifficulty() 
        { 
            return difficulty; 
        }
        public int GetGameTime() 
        { 
            return gameTime;
        }
        public int GetWordCount()
        {
            return wordCount;
        }
        public void SetDifficulty(Difficulty difficulty)
        {
            this.difficulty = difficulty;
            SetSettingInFile();
        }
        public void SetGameTime(int gameTime)
        {
            this.gameTime = gameTime;
            SetSettingInFile();
        }
        public void SetWordCount(int wordCount)
        {
            this.wordCount = wordCount;
            SetSettingInFile();
        }
        private void SetSettingInFile()
        {
            JsonManager.SaveToFile<Settings>("GameSettings.ini", this);
        }

    }
}
