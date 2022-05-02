namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput addPlatformInput,
            [ScopedService] ApplicationDbContext applicationDbContext
        )
        {
            var platform = new Platform
            {
                Name = addPlatformInput.name
            };

            applicationDbContext.Platforms.Add(platform);

            await applicationDbContext.SaveChangesAsync();

            return new AddPlatformPayload(platform);
        }
    }
}