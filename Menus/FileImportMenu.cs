using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.FileImport;

namespace WordGame.Menus
{
    internal class FileImportMenu : BaseMenu
    {
        public FileImportMenu() 
        {
            MenuTitle = "Import menu";
        }
        protected override void PrintHeader()
        {
            base.PrintHeader();
            Console.WriteLine("---------------------");
            Console.WriteLine("Rules of file import");
            Console.WriteLine("---------------------");
            Console.WriteLine(" * File should be .csv extension");
            Console.WriteLine(" * File should have more than 300 words");
            Console.WriteLine(" * Words should be more than 1 letter");
            Console.WriteLine();
        }

        protected override void InitMenuItemList()
        {
            AddMenuItem(
                new MenuItem(
                    "Import example", 
                    FileImportExampleDisplay.StartDisplay
                    ));
            AddMenuItem(
                new MenuItem(
                    "Import file",
                    MenuSingleton<ImportMenu>.OpenMenu
                    ));
            base.InitMenuItemList();
        }
    }
}
