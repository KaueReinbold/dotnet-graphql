var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGraphQL();
app.UseGraphQLVoyager(new VoyagerOptions
{
    GraphQLEndPoint = "/graphql",
}, "/graphql-voyager");

app.Run();
