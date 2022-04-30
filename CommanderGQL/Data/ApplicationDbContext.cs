using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class ApplicationDbContext
        : DbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(platform => platform.Commands)
                .WithOne(command => command.Platform)
                .HasForeignKey(platform => platform.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(command => command.Platform)
                .WithMany(platform => platform.Commands)
                .HasForeignKey(platform => platform.PlatformId);

            base.OnModelCreating(modelBuilder);
        }
    }
}