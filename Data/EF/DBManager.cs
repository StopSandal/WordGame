using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static async Task<bool> IsDBAvailable()
        {
            using (var context = new WordGameContext())
            {
                try
                {
                    return await context.Database.CanConnectAsync(new CancellationTokenSource(1000).Token);
                }
                catch (SqlException ex)
                {
                    Debug.WriteLine(ex);
                    return false;
                }
            }
        }
    }
}
