using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Data.EF
{
    internal class DBManager
    {
        public static void AddToDB<T>(T obj) where T : IDBItem
        {
            if (obj == null)
                return;           
            using (var context = new WordGameContext())
            {
                context.Add(obj);
                context.SaveChanges();
            }
        }
    }
}
