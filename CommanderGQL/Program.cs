var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddDatabase()
    .AddWebApi()
    .AddGraphQL();

builder
    .Build()
    .UseWebApi()
    .UseGraphQL()
    .Run();
