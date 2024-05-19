using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class SetGameTimeMenu : BaseMenu
    {
        private readonly List<int> timesList = new() { 30, 60, 90 };
        public SetGameTimeMenu(IOutput output) : base(output)
        {
            MenuTitle = "Choose game time";
        }
        protected override void InitMenuItemList()
        {
            foreach (int item in timesList)
            {
                AddMenuItem(
                        new MenuItem(
                        $"{item} seconds",
                        () => GameSettings.GetSettings().SetGameTime(item)
                        )
                    );
            }
            base.InitMenuItemList();
        }
    }
}
