using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.FileImport;
using WordGame.Game;
using WordGame.Output;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class GameMenu : BaseMenu
    {
        public GameMenu(IOutput output) : base(output)
        {
            MenuTitle = "Game menu";
        }
        protected override void PrintHeader()
        {
            base.PrintHeader();
            var settings = GameSettings.GetSettings();
            output.WriteLine("----------------------------------------");
            output.WriteLine($"| Word count | Difficulty | Game time |");
            output.WriteLine("----------------------------------------");
            output.WriteLine(
                String.Format("| {0,-10} | {1,-10} | {2,-9} |"
                , settings.GetWordCount(),
                settings.GetDifficulty(),
                settings.GetGameTime()
                )
                );
            output.WriteLine("----------------------------------------");
            
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

            var game = new Game.Game(output);
            game.Start();
            new EndGameMenu(output,game.Result).OpenMenu();
        }
        private void AbortGame() 
        {
            output.Clear();
            output.WriteLine("Game cannot be started");
            output.WriteLine("Chosen difficulty doesn't contains any word dictionary.");
            output.WriteLine("Change difficulty or import file");
            output.WriteLine("Press Enter key to continue");
            output.ReadLine();
        }
    }
}
