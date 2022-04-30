namespace CommanderGQL.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddPooledDbContextFactory<ApplicationDbContext>(options
                 => options.UseSqlite($"Data Source={System.IO.Path.Join(AppDomain.CurrentDomain.BaseDirectory, "CommanderGQL.db")}"));

            return services;
        }
    }
}