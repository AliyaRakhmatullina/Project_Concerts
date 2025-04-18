using Concerts.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Concerts
{
    public class ConcertsDbContext : DbContext
    {
        public static string DatabaseFilePath { get; set; } = "conterts_database.db";

        public DbSet<Event> Events { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DatabaseFilePath}");
        }
    }
}
