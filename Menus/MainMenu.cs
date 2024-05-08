using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Menus
{
    internal class MainMenu : BaseMenu
    {
        public MainMenu() : base()
        {
            MenuTitle = "Main menu";
        }

        protected override void InitMenuItemList()
        {
            AddMenuItem(new MenuItem("Start game", StartGame));
            AddMenuItem(new MenuItem("Settings", OpenSettingsMenu));
            AddMenuItem(new MenuItem("Import dictionary", OpenImportMenu));
            AddMenuItem(new MenuItem("Results", OpenResultsMenu));
            AddMenuItem(new MenuItem("Exit", OpenExitMenu));
        }
        private void OpenExitMenu()
        {
            var exitMenu = new BaseMenu("Do you want to close the app?");
            exitMenu.AddMenuItem(new MenuItem("Yes", () => Environment.Exit(0)));
            exitMenu.AddMenuItem(new MenuItem("No", exitMenu.CloseMenu));
            exitMenu.OpenMenu();
        }
        private void StartGame()
        {
            new GameMenu().OpenMenu();
        }
        private void OpenSettingsMenu()
        {
            new SettingsMenu().OpenMenu();
        }
        private void OpenImportMenu()
        {
            new FileImportMenu().OpenMenu();
        }
        private void OpenResultsMenu() 
        { 
            throw new NotImplementedException(); 
        }
    }
}
