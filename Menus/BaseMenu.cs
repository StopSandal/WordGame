using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.InputReaders;
using WordGame.Output;

namespace WordGame.Menus
{
    internal class BaseMenu : ConsoleMenu
    {
        public BaseMenu(IOutput output) : base(output)
        {
            InitMenuItemList();
        }

        public BaseMenu(IOutput output,string menuTitle) : base(output,menuTitle)
        {
        }

        protected override void PrintHeader()
        {
            output.Clear();
            output.WriteLine(MenuTitle);
        }
        protected override void PrintBody()
        {
            output.WriteLine("Menu items:");
            for (int i = 0; i < Items.Count; i++)
            {
                output.WriteLine($"{i}. {Items[i].Name}");
            }
        }
        protected override void DoMenuAction()
        {
            output.WriteLine("Enter menu item number to choose it");

            int choice = NumericReader.GetNumberFromConsole();
            while (choice < 0 || choice > Items.Count - 1) 
            {
                output.WriteLine("Wrong action number. Try again");
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
