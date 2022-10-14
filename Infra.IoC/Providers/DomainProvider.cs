using Domain.Buildings;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Providers
{
    public static class DomainProvider
    {
        public static IServiceCollection AddDomainDepencies(
           this IServiceCollection services) =>
            services
                .AddScoped(typeof(IBuildingPublisher), typeof(BuildingPublisher));

        public static IServiceCollection AddConfigurations(this IServiceCollection services) =>
            services
                .AddDomainDepencies();
    }
}