using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class ResultsMenu : BaseMenu
    {
        public ResultsMenu(IOutput output) : base(output)
        {
            MenuTitle = "Results menu";
        }

        protected override void InitMenuItemList()
        {
            foreach (Difficulty item in Enum.GetValues(typeof(Difficulty)))
            {
                AddMenuItem(
                        new MenuItem(
                        item.ToString(),
                        () => MenuSingleton<ResultDifficultyMenu>.GetMenu().OpenMenu(item)
                        )
                    );
            }
            base.InitMenuItemList();
        }
    }
}
