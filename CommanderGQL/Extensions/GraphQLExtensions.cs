namespace CommanderGQL.Extensions
{
    public static class GraphQLExtensions
    {
        public static IServiceCollection AddGraphQL(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddProjections();

            return services;
        }

        public static WebApplication UseGraphQL(this WebApplication app)
        {
            app.MapGraphQL();
            app.UseGraphQLVoyager(new VoyagerOptions
            {
                GraphQLEndPoint = "/graphql",
            }, "/graphql-voyager");

            return app;
        }
    }
}