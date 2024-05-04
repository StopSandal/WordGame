using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.InputReaders;

namespace WordGame.Menus
{
    internal class BaseMenu : ConsoleMenu
    {

        public BaseMenu(string menuTitle, IList<MenuItem> items) : base(menuTitle, items)
        {
        }

        public BaseMenu() : base()
        {
            InitMenuItemList();
        }

        protected override void PrintHeader()
        {
            Console.Clear();
            Console.WriteLine(MenuTitle);
        }
        protected override void PrintBody()
        {
            Console.WriteLine("Menu items:");
            for (int i = 0; i < Items.Count; i++)
            {
                Console.WriteLine($"{i}. {Items[i].Name}");
            }
        }
        protected override void DoMenuAction()
        {
            Console.WriteLine("Enter menu item number to choose it");

            int choice = NumericReader.GetNumberFromConsole();
            while (choice < 0 || choice > Items.Count - 1) 
            {
                Console.WriteLine("Wrong action number. Try again");
                choice = NumericReader.GetNumberFromConsole();
            }
            InvokeMenuItemAction(choice);
        }

        protected virtual void InitMenuItemList()
        {
            Items.Add(new MenuItem("Back",CloseMenu));
        }
  
    }
}
