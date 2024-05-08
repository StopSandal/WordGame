using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.FileImport;
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
            var settings = GameSettings.GetSettings();
            if (!FileImportManager.HasGameDictionary(settings.GetDifficulty()))
            {
                AbortGame();
                return;
            }
            var game = new Game.Game();
            game.Start();
            new EndGameMenu(game.Result).OpenMenu();
        }
        private void AbortGame() 
        {
            Console.Clear();
            Console.WriteLine("Game cannot be started");
            Console.WriteLine("Chosen difficulty doesn't contains any word dictionary.");
            Console.WriteLine("Change difficulty or import file");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
