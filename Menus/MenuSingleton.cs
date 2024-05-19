using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Output;

namespace WordGame.Menus
{
    internal static class MenuSingleton<T> where T : BaseMenu
    {
        public static void OpenMenu()
        {
            GetMenu().OpenMenu();
        }
        public static T GetMenu()
        {
            return WordAppServiceProvider.GetServiceProvider().GetService<T>();
        }
    }
}
