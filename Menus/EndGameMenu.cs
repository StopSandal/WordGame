using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Data;
using WordGame.Data.EF;
using WordGame.Output;

namespace WordGame.Menus
{
    internal class EndGameMenu : BaseMenu
    {
        private readonly GameResultItem _item;
        private EndGameMenu(IOutput output) : base(output)
        {
            MenuTitle = "Game end";
        }
        public EndGameMenu(IOutput output,GameResultItem item) : this(output)
        {
            _item = item;
        }

        protected override void PrintHeader()
        {
            base.PrintHeader();
            output.WriteLine("--------------------------------------------");
            output.WriteLine($"| Total score : {_item.Score:D3} | Difficulty: {_item.Difficulty}");
            output.WriteLine("--------------------------------------------");
            output.WriteLine("Do you want to save results?");
        }
        protected override void InitMenuItemList()
        {
            AddMenuItem(new MenuItem(
                "Yes",
                SaveTo
                ));
            AddMenuItem(new MenuItem(
                "No",
                CloseMenu
                ));
        }
        private async void SaveTo()
        {
            if (!await DBManager.IsDBAvailable())
            {
                PrintError();
                CloseMenu();
                return;
            }
            AskUserName();
            DBManager.AddToDB(_item);
            CloseMenu();
        }
        private void AskUserName()
        {
            output.WriteLine("Enter your nickname");
            _item.PlayerName = output.ReadLine();
        }
        private void PrintError()
        {
            output.WriteLine("Cannot connect to DB to save results");
            output.WriteLine("Press Enter key to continue...");
            output.ReadLine();
        }
    }
}
