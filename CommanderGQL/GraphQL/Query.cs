namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Platform> GetPlatforms(
            [ScopedService] ApplicationDbContext applicationDbContext
        ) => applicationDbContext.Platforms;
    }
}