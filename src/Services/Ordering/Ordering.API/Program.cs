using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration)
        .AddInfrastructureServices(builder.Configuration)
        .AddApiServices(builder.Configuration);

var app = builder.Build();

//http pipeline services

app.UserApiServices();
if (app.Environment.IsDevelopment())
{
    await app.IntializeDatabaseAsync();
}

app.Run();
