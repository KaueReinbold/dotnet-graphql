namespace CommanderGQL.GraphQL.Extensions
{
    public static class GraphQLExtensions
    {
        public static IServiceCollection AddGraphQL(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<PlatformType>()
                .AddType<CommandType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();

            return services;
        }

        public static WebApplication UseGraphQL(this WebApplication app)
        {
            app.UseWebSockets();
            app.MapGraphQL();
            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
            }, "/graphql-voyager");

            return app;
        }
    }
}