using Castle.Core.Logging;
using ECommerce.Api.Settings;
using ECommerce.Core.Gateways;
using ECommerce.Core.Managers.Cart;
using ECommerce.Core.Managers.Products;
using ECommerce.Core.Managers.Users;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Gateways;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ECommerce.Api.Configuration
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection @this, IConfiguration configuration)
        {
            var databaseName = configuration.GetSettings<DatabaseSettings>().DatabaseName;
            @this.AddDbContext<EntityFrameworkDbContext>(o => o.UseInMemoryDatabase(databaseName), ServiceLifetime.Scoped);

            return @this;
        }

        public static IServiceCollection AddGateways(this IServiceCollection @this)
        {
            @this.AddTransient<IProviderManager, EntityFrameworkProviderManager>();
            @this.AddTransient(typeof(IProvider<>), typeof(EntityFrameworkProvider<>));

            return @this;
        }

        public static IServiceCollection AddManagers(this IServiceCollection @this)
        {
            @this.AddScoped<IProductManager, ProductManager>();
            @this.AddScoped<ICartManager, CartManager>();
            @this.AddScoped<IUserManager, UserManager>();

            return @this;
        }

        public static IServiceCollection AddLogging(this IServiceCollection @this)
        {
            @this.AddSingleton<ILogger, ConsoleLogger>();

            return @this;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection @this, IConfiguration configuration)
        {
            var swaggerSettings = configuration.GetSettings<SwaggerSettings>();

            @this.AddSwaggerGen(options =>
            {
                var info = new Info
                {
                    Title = swaggerSettings.Title,
                    Version = swaggerSettings.Version
                };

                options.SwaggerDoc(swaggerSettings.Version, info);
            });

            return @this;
        }
    }
}
