using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MyApp.Application.Mappings;
using MyApp.Application.Services;
using MyApp.Application.Services.Interfaces;

namespace MyApp.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}