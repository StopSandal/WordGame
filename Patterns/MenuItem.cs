using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Menus
{
    internal class MenuItem2
    {
        public string Name { get; }
        public Action ItemAction { get; }
        public MenuItem2()
        {
            Name = "Empty option";
            ItemAction = () => { }; // do-nothing method
        }

        public MenuItem2(string name, Action itemAction)
        {
            Name = name;
            ItemAction = itemAction;
        }
    }
}
