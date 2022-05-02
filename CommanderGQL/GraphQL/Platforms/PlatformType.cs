namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(platform => platform.Id)
                .Description("Represents the unique ID for the platform.");

            descriptor
                .Field(platform => platform.Name)
                .Description("Represents the name for the platform.");

            descriptor
                .Field(platform => platform.LicenseKey).Ignore();

            descriptor
                .Field(platform => platform.Commands)
                .ResolveWith<Resolvers>(platform => platform.GetCommands(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the list of available commands for this platform.");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(
                [Parent] Platform platform, 
                [ScopedService] ApplicationDbContext context
            )
            {
                return context
                    .Commands
                    .Where(platform => 
                        platform.PlatformId == platform.Id
                    );
            }
        }
    }
}