using ECommerce.Api.Settings;
using ECommerce.Core.Gateways;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Gateways;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection @this, IConfiguration configuration)
        {
            var databaseName = configuration.GetSettings<DatabaseSettings>().DatabaseName;
            @this.AddDbContext<EntityFrameworkDbContext>(o => o.UseInMemoryDatabase(databaseName), ServiceLifetime.Scoped);

            @this.AddScoped<DbContext, EntityFrameworkDbContext>();

            return @this;
        }

        public static IServiceCollection AddGateways(this IServiceCollection @this)
        {
            @this.AddTransient(typeof(IProvider<>), typeof(EntityFrameworkProvider<>));
            @this.AddTransient<IManager, EntityFrameworkManager>();

            return @this;
        }
    }
}
