using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Data;

namespace WordGame.Menus
{
    internal class EndGameMenu : BaseMenu
    {
        private readonly GameResultItem _item;
        private EndGameMenu() 
        {
            MenuTitle = "Game end";
        }
        public EndGameMenu(GameResultItem item) : this()
        {
            _item = item;
        }

        protected override void PrintHeader()
        {
            base.PrintHeader();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"| Total score : {_item.Score:D3} | Difficulty: {_item.difficulty}");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Do you want to save results?");
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
        private void SaveTo()
        {
            AskUserName();

            CloseMenu();
        }
        private void AskUserName()
        {
            Console.WriteLine("Enter your nickname");
            _item.PlayerName = Console.ReadLine();

        }
    }
}
