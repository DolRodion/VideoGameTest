using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameTest.DataAccess.Entities;

namespace VideoGameTest.DataAccess
{
    public class DbVideoGameTestContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=VideoGameTest;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public DbVideoGameTestContext()
        {
        }

        public DbVideoGameTestContext(DbContextOptions options) : base(options) { }

 
        public DbSet<GameType> GameType { get; set; }

        public DbSet<VideoGame> VideoGame { get; set; }

    }
}
