using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class SettingsMenu : BaseMenu
    {
        //Difficulty
        protected override void InitMenuItemList()
        {
            AddMenuItem(new MenuItem("Difficulty", OpenSetDifficultyMenu));
            AddMenuItem(new MenuItem("Time", OpenSetTimeMenu));
            AddMenuItem(new MenuItem("Word's count", OpenSetWordCountMenu));
            base.InitMenuItemList();
        }
        private void OpenSetTimeMenu()
        {
            var menu = new BaseMenu("Choose game time");
            menu.AddMenuItem(
                    new MenuItem(
                    "30 seconds",
                    () => GameSettings.GetSettings().SetGameTime(30)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "60 seconds",
                    () => GameSettings.GetSettings().SetGameTime(60)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "90 seconds",
                    () => GameSettings.GetSettings().SetGameTime(90)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "Back",
                    menu.CloseMenu
                    )
                );
            menu.OpenMenu();
        }
        private void OpenSetDifficultyMenu()
        {
            var menu = new BaseMenu("Choose game time");
            foreach (Difficulty item in Enum.GetValues(typeof(Difficulty)))
            {
                menu.AddMenuItem(
                        new MenuItem(
                        item.ToString(),
                        () => GameSettings.GetSettings().SetDifficulty(item)
                        )
                    );
            }
            menu.AddMenuItem(
                        new MenuItem(
                        "Back",
                        menu.CloseMenu
                        )
                    );
            menu.OpenMenu();
        }
        private void OpenSetWordCountMenu()
        {
            var menu = new BaseMenu("Choose word count");
            menu.AddMenuItem(
                    new MenuItem(
                    "1 word",
                    () => GameSettings.GetSettings().SetWordCount(1)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "3 words",
                    () => GameSettings.GetSettings().SetWordCount(3)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "9 words",
                    () => GameSettings.GetSettings().SetWordCount(9)
                    )
                );
            menu.AddMenuItem(
                    new MenuItem(
                    "Back",
                    menu.CloseMenu
                    )
                );
            menu.OpenMenu();
        }
    }
}
