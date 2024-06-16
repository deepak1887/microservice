using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);
//Add services to the container
//register Yarp

builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});

var app = builder.Build();

//configure http request pipeline
app.MapReverseProxy();

app.Run();
