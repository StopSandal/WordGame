using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Menus
{
    internal abstract class ConsoleMenu : IMenu
    {
        protected string MenuTitle;
        public bool IsClosed { get; protected set; }
        protected IList<MenuItem> Items;

        protected ConsoleMenu()
        {
            IsClosed = false;
            MenuTitle = "Anonymous menu";
            Items = new List<MenuItem>();
        }

        protected ConsoleMenu(string menuTitle, IList<MenuItem> items) : base()
        {
            MenuTitle = menuTitle;
            Items = items;
        }

        protected abstract void PrintHeader();
        protected abstract void PrintBody();
        protected abstract void DoMenuAction();
        public virtual void OpenMenu()
        {
            while (!IsClosed)
            {
                PrintHeader();
                PrintBody();
                DoMenuAction();
            }
        }
        public void CloseMenu() {
            IsClosed = true;
        }

        public void AddMenuItem(MenuItem item)
        {
            Items.Add(item);
        }
        public void InvokeMenuItemAction(int menuItemIndex) {
            Items[menuItemIndex].ItemAction();
        }

    }
}
