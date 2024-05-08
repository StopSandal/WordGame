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
            MenuSingleton<SetGameTimeMenu>.OpenMenu();
        }
        private void OpenSetDifficultyMenu()
        {
            MenuSingleton<SetDifficultyMenu>.OpenMenu();
        }
        private void OpenSetWordCountMenu()
        {
            MenuSingleton<SetWordCountMenu>.OpenMenu();
        }
    }
}
