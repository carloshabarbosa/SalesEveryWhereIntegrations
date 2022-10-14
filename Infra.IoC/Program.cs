using Autofac;
using Infra.EventBus;
using Infra.EventBus.Abstractions;
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


        return services;

    }
}