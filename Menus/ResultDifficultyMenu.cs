using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Data.EF;
using WordGame.Output;
using WordGame.Results;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class ResultDifficultyMenu : BaseMenu
    {
        private Difficulty difficulty = Difficulty.Easy;

        public ResultDifficultyMenu(IOutput output) : base(output)
        {
            MenuTitle = "Results for";
        }

        public void OpenMenu(Difficulty difficulty)
        {
            this.difficulty = difficulty;
            base.OpenMenu();
        }

        protected override void InitMenuItemList()
        {
            var context = new WordGameContext();
            AddMenuItem(new MenuItem(
                "Last games",
                () => {
                    DisplayResults.DisplayResult(
                        context.GameResults
                        .Where(x => x.Difficulty == difficulty)
                        .OrderByDescending(x => x.DateTime)
                        .Take(20)
                        .ToList(),
                        "Last 20 Games Results"
                       );
                }
                ));
            AddMenuItem(new MenuItem(
                "High score",
                () => {
                    DisplayResults.DisplayResult(
                        context.GameResults
                        .Where(x => x.Difficulty == difficulty)
                        .OrderByDescending(x => x.Score)
                        .Take(20)
                        .ToList(),
                        "Top 20 Players"
                       );
                }
            ));
            base.InitMenuItemList();
        }
        protected override void PrintHeader()
        {
            output.Clear();
            output.WriteLine($"{MenuTitle} {difficulty} difficulty");
        }
    }
}
