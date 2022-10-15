using Autofac;
using Domain.Listener.Buildings;
using Domain.Publisher.Buildings;
using Infra.Data.Context;
using Infra.EventBus;
using Infra.EventBus.Abstractions;
using Infra.IoC.Providers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infra.IoC;

public static class DependecyInjectionExtension
{
    public static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IServiceBusPersisterConnection>(sp =>
       {
           var serviceBusConnectionString = config["EventBusConnection"];

           return new DefaultServiceBusPersisterConnection(serviceBusConnectionString);
       });

        services.AddSingleton<IEventBus, EventBusServiceBus>(sp =>
        {
            var serviceBusPersisterConnection = sp.GetRequiredService<IServiceBusPersisterConnection>();
            var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
            var logger = sp.GetRequiredService<ILogger<EventBusServiceBus>>();
            var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
            string subscriptionName = config["SubscriptionName"];

            return new EventBusServiceBus(serviceBusPersisterConnection, logger,
                eventBusSubscriptionsManager, iLifetimeScope, subscriptionName);
        });

        services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

        services.AddTransient<BuildingListener>();


        return services;
    }

    public static void ConfigureServiceBus(this IServiceProvider services)
    {
        var eventBus = services.GetRequiredService<IEventBus>();

        eventBus.Subscribe<BuildingEvent, BuildingListener>();
    }

    public static IServiceCollection AddDatabaseConfig(
             this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("Database");
        services.AddDbContext<DataBaseContext>(options =>
            options.UseNpgsql(connectionString));
        return services;
    }

    public static IServiceCollection AddConfigurations(this IServiceCollection services) =>
    services
        .AddDomainDepencies()
        .AddRepositoryDependencies();
}