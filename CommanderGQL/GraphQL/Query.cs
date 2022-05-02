namespace CommanderGQL.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Platform> GetPlatform([ScopedService] ApplicationDbContext applicationDbContext)
        {
            return applicationDbContext.Platforms;
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public IQueryable<Command> GetCommand([ScopedService] ApplicationDbContext applicationDbContext)
        {
            return applicationDbContext.Commands;
        }
    }
}