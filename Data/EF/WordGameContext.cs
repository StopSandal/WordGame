using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame.Data.EF
{
    internal class WordGameContext : DbContext
    {
        //private const string ConnectionString = "Server=DESKTOP-UAUG3OJ;Database=WordGame;Trusted_Connection=True;TrustServerCertificate=True;";
        public DbSet<GameResultItem> GameResults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseInMemoryDatabase("WordGame");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
