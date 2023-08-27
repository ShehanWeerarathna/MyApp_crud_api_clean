using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MyApp.Application.Mappings;
using MyApp.Application.Services;
using MyApp.Application.Services.Interfaces;
using MyApp.Application.QueryHandlers;
using MyApp.Application.Queries;

namespace MyApp.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // need to register all query handlers
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly));
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}