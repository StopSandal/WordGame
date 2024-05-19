using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.FileImport;
using WordGame.Output;

namespace WordGame.Menus
{
    internal class FileImportMenu : BaseMenu
    {
        public FileImportMenu(IOutput output) : base(output)
        {
            MenuTitle = "Import menu" + this.GetHashCode();
        }
        protected override void PrintHeader()
        {
            base.PrintHeader();
            output.WriteLine("---------------------");
            output.WriteLine("Rules of file import");
            output.WriteLine("---------------------");
            output.WriteLine(" * File should be .csv extension");
            output.WriteLine(" * File should have more than 300 words");
            output.WriteLine(" * Words should be more than 1 letter");
            output.WriteLine();
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
