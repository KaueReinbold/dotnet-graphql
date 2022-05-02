namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand(
            [ScopedService] ApplicationDbContext applicationDbContext
        )
        {
            return applicationDbContext.Commands;
        }
        
        [UseDbContext(typeof(ApplicationDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform(
            [ScopedService] ApplicationDbContext applicationDbContext
        )
        {
            return applicationDbContext.Platforms;
        }
    }
}