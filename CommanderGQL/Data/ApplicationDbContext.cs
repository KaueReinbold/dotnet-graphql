using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class ApplicationDbContext
        : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;

            DbPath = System.IO.Path.Join(path, "CommanderGQL.db");

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}