using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordGame.FileImport;
using WordGame.InputReaders;
using WordGame.Settings;

namespace WordGame.Menus
{
    internal class ImportMenu : BaseMenu
    {
        public ImportMenu()
        {
            MenuTitle = "Choose difficulty of importing file";
        }

        protected override void InitMenuItemList()
        {
            foreach (Difficulty item in Enum.GetValues(typeof(Difficulty)))
            {
                AddMenuItem(
                        new MenuItem(
                        item.ToString(),
                        () => SaveWordsDictionary(item)
                        )
                );
            }
            base.InitMenuItemList();
        }
        private static void SaveWordsDictionary(Difficulty difficulty)
        {
            string filePath = FilePathReader.GetFilePath();
            if (!string.IsNullOrEmpty(filePath))
                FileImportManager.SaveFile(filePath, difficulty);
        }
    }
}
