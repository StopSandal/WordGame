using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.Menus;

namespace WordGame
{
    public interface IRunnableApp
    {
        void Run();
    }
    public class WordGameApp : IRunnableApp
    {
        public void Run()
        {
            MenuSingleton<MainMenu>.OpenMenu();
        }
    }
}
