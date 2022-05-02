namespace CommanderGQL.GraphQL.Models.Platforms
{
     public record AddPlatformInput(string name);

     public record AddPlatformPayload(Platform platform);
}