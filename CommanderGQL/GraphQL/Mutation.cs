namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput addPlatformInput,
            [ScopedService] ApplicationDbContext applicationDbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
        )
        {
            var platform = new Platform
            {
                Name = addPlatformInput.name
            };

            applicationDbContext.Platforms.Add(platform);

            await applicationDbContext.SaveChangesAsync();

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(ApplicationDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(
            AddCommandInput addCommandInput,
            [ScopedService] ApplicationDbContext applicationDbContext
        )
        {
            var command = new Command
            {
                HowTo = addCommandInput.howTo,
                CommandLine = addCommandInput.commandLine,
                PlatformId = addCommandInput.platformId
            };

            applicationDbContext.Commands.Add(command);

            await applicationDbContext.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}