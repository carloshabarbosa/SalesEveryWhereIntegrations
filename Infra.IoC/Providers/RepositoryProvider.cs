using Domain.Buildings;
using Domain.Publisher.Buildings;
using Infra.Data.Buildings;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.IoC.Providers
{
    public static class RepositoryProvider
    {
        public static IServiceCollection AddRepositoryDependencies(
           this IServiceCollection services) =>
            services
                .AddScoped(typeof(IBuildingRepository), typeof(BuildingRepository));
    }
}