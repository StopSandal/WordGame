using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.InputReaders;
using WordGame.Output;

namespace WordGame.Menus
{
    internal class BaseMenuP : ConsoleMenu
    {
        public BaseMenuP(IOutput output) : base(output)
        {
            InitMenuItemList();
        }

        public BaseMenuP(IOutput output, string menuTitle) : base(output, menuTitle)
        {
        }

        // Implementation of Template method, this header can be overrided at any inherited menu. It still be called at parent Console Menu
        protected override void PrintHeader()
        {
            output.Clear();
            output.WriteLine(MenuTitle);
        }
        // same comment as previous
        protected override void PrintBody()
        {
            output.WriteLine("Menu items:");
            for (int i = 0; i < Items.Count; i++)
            {
                output.WriteLine($"{i}. {Items[i].Name}");
            }
        }
        //Invoke action as menu action as command to do
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
        // basic menu actions
        protected virtual void InitMenuItemList()
        {
            Items.Add(new MenuItem("Back", CloseMenu));
        }

    }
}
