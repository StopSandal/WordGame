using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Data
{
    internal class GameResultItem
    {
        public Difficulty difficulty {  get; set; }
        public int Score { get; set; }
        public string PlayerName { get; set; }

        public GameResultItem(Difficulty difficulty)
        {
            this.difficulty = difficulty;
            Score = 0;
            PlayerName = String.Empty;
        }
    }
}
