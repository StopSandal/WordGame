using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Data
{
    internal class GameResultItem : IDBItem
    {
        public int ID { get; set; }
        public Difficulty Difficulty {  get; set; }
        public DateTime dateTime { get; set; }
        public int Score { get; set; }
        public string PlayerName { get; set; }
        public GameResultItem(Difficulty difficulty)
        {
            this.Difficulty = difficulty;
            Score = 0;
            PlayerName = String.Empty;
        }
    }
}
