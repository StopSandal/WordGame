using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Menus
{
    internal class MenuItem
    {
        public string Name { get; }
        public  Action ItemAction { get; }
        public MenuItem() {
            Name = "Empty option";
            ItemAction = () => { }; // do-nothing method
        }

        public MenuItem(string name, Action itemAction)
        {
            Name = name;
            ItemAction = itemAction;
        }
    }
}
