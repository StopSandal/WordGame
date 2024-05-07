using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Game;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class GameMenu : BaseMenu
    {
        public GameMenu()
        {
            MenuTitle = "Game menu";
        }
        protected override void PrintHeader()
        {
            base.PrintHeader();
            var settings = GameSettings.GetSettings();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"| Word count | Difficulty | Game time |");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine(
                String.Format("| {0,-10} | {1,-10} | {2,-9} |"
                , settings.GetWordCount(),
                settings.GetDifficulty(),
                settings.GetGameTime()
                )
                );
            Console.WriteLine("----------------------------------------");
            
        }
        protected override void InitMenuItemList()
        {
            AddMenuItem(new MenuItem(
                "Game rules",
                DisplayRules
                ));
            AddMenuItem(new MenuItem(
                "Start game",
                StartGame
                ));
            base.InitMenuItemList();
        }
        private void DisplayRules()
        {
            GameRulesExampleDisplay.StartDisplay();
        }
        private void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
