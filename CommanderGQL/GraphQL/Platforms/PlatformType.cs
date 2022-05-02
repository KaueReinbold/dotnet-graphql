namespace CommanderGQL.GraphQL.Platforms
{
    public class PlatformType
        : ObjectType<Platform>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Platform> descriptor
        )
        {
            descriptor
                .Description("Represents any software or service that has a command line interface.");

            descriptor
                .Field(platform => platform.LicenseKey)
                .Ignore(true);

            descriptor
                .Field(p => p.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the list of available commands for this platform.");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(
                Platform platform, 
                [ScopedService] ApplicationDbContext applicationDbContext
            )
            {
                return applicationDbContext
                    .Commands
                    .Where(command => 
                        command.PlatformId == platform.Id
                    );
            }
        }
    }
}