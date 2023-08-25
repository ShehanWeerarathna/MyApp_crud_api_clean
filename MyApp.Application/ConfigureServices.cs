using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace MyApp.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
}