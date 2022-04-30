var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDatabase()
    .AddGraphQL();

builder
    .Build()
    .UseGraphQL()
    .Run();
