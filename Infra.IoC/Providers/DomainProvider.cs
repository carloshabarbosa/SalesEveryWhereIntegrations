using Domain.Buildings;
using Domain.Publisher.Buildings;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Providers
{
    public static class DomainProvider
    {
        public static IServiceCollection AddDomainDepencies(
           this IServiceCollection services) =>
            services
                .AddScoped(typeof(IBuildingPublisher), typeof(BuildingPublisher))
                .AddScoped(typeof(IBuildingCreator), typeof(BuildingCreator));
    }
}