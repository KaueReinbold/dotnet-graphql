namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command.");

            descriptor
                .Field(command => command.Id)
                .Description("Represents the unique ID for the command.");

            descriptor
                .Field(command => command.HowTo)
                .Description("Represents the how-to for the command.");

            descriptor
                .Field(command => command.CommandLine)
                .Description("Represents the command line.");

            descriptor
                .Field(command => command.PlatformId)
                .Description("Represents the unique ID of the platform which the command belongs.");

            descriptor
                .Field(command => command.Platform)
                .ResolveWith<Resolvers>(command => command.GetPlatform(default!, default!))
                .UseDbContext<ApplicationDbContext>()
                .Description("This is the platform to which the command belongs.");

        }

        private class Resolvers
        {
            public Platform GetPlatform(
                [Parent] Command command, 
                [ScopedService] ApplicationDbContext context
            )
            {
                return context
                    .Platforms
                    .FirstOrDefault(platform => 
                        platform.Id == command.PlatformId
                    );
            }
        }
    }
}