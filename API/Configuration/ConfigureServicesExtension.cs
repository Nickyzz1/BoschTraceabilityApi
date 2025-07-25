namespace BoschTraceabilityAPI.API.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BoschTraceabilityAPI.Infrastructure;
using BoschTraceabilityAPI.Core.Interfaces;
using BoschTraceabilityAPI.Core.Services;

public static class ConfigureServicesExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPartService, PartService>();
        // services.AddScoped<IStationService, StationService>();
        // services.AddScoped<IMovimentService, MovimentService>();
        return services;
    }
}

