using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class SetDifficultyMenu : BaseMenu
    {
        public SetDifficultyMenu()
        {
            MenuTitle = "Choose game difficulty";
        }
        protected override void InitMenuItemList()
        {
            foreach (Difficulty item in Enum.GetValues(typeof(Difficulty)))
            {
                AddMenuItem(
                        new MenuItem(
                        item.ToString(),
                        () => GameSettings.GetSettings().SetDifficulty(item)
                        )
                    );
            }
            base.InitMenuItemList();
        }
    }
}
