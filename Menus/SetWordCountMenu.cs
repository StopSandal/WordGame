using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class SetWordCountMenu : BaseMenu
    {
        private readonly List<int> countList = new List<int> { 1, 3, 9 };
        public SetWordCountMenu()
        {
            MenuTitle = "Choose word count";
        }
        protected override void InitMenuItemList()
        {
            foreach (int item in countList)
            {
                AddMenuItem(
                        new MenuItem(
                        $"{item} word(s)",
                        () => GameSettings.GetSettings().SetWordCount(item)
                        )
                    );
            }
            base.InitMenuItemList();
        }
    }
}
