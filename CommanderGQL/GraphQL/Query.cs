namespace CommanderGQL.GraphQL
{
    public class Query
    {
        public IQueryable<Platform> GetPlatforms(
            [Service] ApplicationDbContext applicationDbContext
        ) => applicationDbContext.Platforms;
    }
}