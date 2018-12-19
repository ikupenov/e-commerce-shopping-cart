using ECommerce.Api.Middlewares;
using ECommerce.Core.Gateways;
using ECommerce.Infrastructure.Data.Prototyping;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Api.Configuration
{
    internal static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedFakeData(this IApplicationBuilder @this)
        {
            using (var scope = @this.ApplicationServices.CreateScope())
            {
                var providerManager = scope.ServiceProvider.GetService<IProviderManager>();
                var dataSeeder = new DataSeeder(providerManager);

                dataSeeder.Seed();
            }

            return @this;
        }

        public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder @this)
        {
            @this.UseMiddleware<ExceptionMiddleware>();

            return @this;
        }
    }
}
