using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;

namespace WordGame.Menus
{
    internal abstract class ConsoleMenu : IMenu
    {
        protected string MenuTitle;
        protected IOutput output {  get; }
        public bool IsClosed { get; protected set; }
        protected IList<MenuItem> Items;

        protected ConsoleMenu(IOutput output)
        {
            this.output = output;
            IsClosed = false;
            MenuTitle = "Anonymous menu";
            Items = new List<MenuItem>();
        }
        protected ConsoleMenu(IOutput output, string menuTitle) : this(output)
        {
            MenuTitle = menuTitle;
        }

        protected abstract void PrintHeader();
        protected abstract void PrintBody();
        protected abstract void DoMenuAction();
        public virtual void OpenMenu()
        {
            IsClosed = false;
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

        internal protected void AddMenuItem(MenuItem item)
        {
            Items.Add(item);
        }
        protected void InvokeMenuItemAction(int menuItemIndex) {
            Items[menuItemIndex].ItemAction();
        }

    }
}
