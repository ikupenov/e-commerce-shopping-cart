using System;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;

namespace ECommerce.Infrastructure.Data
{
    public class DataSeeder
    {
        private readonly IProviderManager providerManager;

        public DataSeeder(IProviderManager providerManager)
        {
            this.providerManager = providerManager;
        }

        public DataSeeder SeedProducts()
        {
            var productProvider = this.providerManager.GetProvider<Product>();

            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Samsung TV 55\"",
                Price = 800,
                Inventory = 10
            };

            productProvider.Create(product1);

            this.providerManager.SaveChanges();

            return this;
        }
    }
}
