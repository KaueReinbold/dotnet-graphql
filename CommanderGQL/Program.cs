var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabase()
    .AddGraphQL();

var app = builder.Build();

app.UseGraphQL();

app.Run();
