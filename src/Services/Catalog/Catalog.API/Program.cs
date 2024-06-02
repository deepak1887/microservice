var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
// Add services to the container.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
});

builder.Services.AddCarter();
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app.Run();
