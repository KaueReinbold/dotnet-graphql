namespace CommanderGQL.GraphQL.Models.Commands
{
    public record AddCommandInput(
        string howTo,
        string commandLine,
        int platformId
    );

    public record AddCommandPayload(
        Command Command
    );
}