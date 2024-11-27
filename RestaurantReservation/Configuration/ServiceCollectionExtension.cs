using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.Configuration.Options;

namespace RestaurantReservation.Configuration;

public static class ServiceCollectionExtension
{
    public static IServiceCollection LodConfiguration(this IServiceCollection services, HostApplicationBuilder builder)
    {
        services
            .Configure<DatabaseOptions>(
                builder.Configuration.GetSection(DatabaseOptions.Database)
            );

        return services;
    }
}