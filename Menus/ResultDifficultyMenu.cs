using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class ResultDifficultyMenu : BaseMenu
    {
        private Difficulty difficulty = Difficulty.Easy;

        public ResultDifficultyMenu()
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
            AddMenuItem(new MenuItem(
                "By date",
                () => { }
                ));
            AddMenuItem(new MenuItem(
                "By score",
                () => { }
                ));
            base.InitMenuItemList();
        }

        protected override void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine($"{MenuTitle} {difficulty} difficulty");
        }
    }
}
