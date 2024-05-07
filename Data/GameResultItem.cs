using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Data
{
    internal class GameResultItem
    {
        public int Score { get; set; }
        public string PlayerName { get; set; }

        public GameResultItem()
        {
            Score = 0;
            PlayerName = String.Empty;
        }
    }
}
