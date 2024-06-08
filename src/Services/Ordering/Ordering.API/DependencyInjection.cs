namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        //Add carter
        return services;
    }

    public static WebApplication UserApiServices(this WebApplication app) 
    { 
        //map carter
        return app;
    }
}
