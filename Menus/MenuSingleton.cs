using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Menus
{
    internal static class MenuSingleton<T> where T : class,IMenu, new()
    {
        private static T _menu;
        public static void OpenMenu()
        {
            _menu ??= new T();
            _menu.OpenMenu();
        }
    }
}
