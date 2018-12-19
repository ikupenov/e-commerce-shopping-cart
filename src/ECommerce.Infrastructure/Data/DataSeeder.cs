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

        public void Seed()
        {
            this.SeedUsers()
                .SeedProducts();
        }

        public DataSeeder SeedUsers()
        {
            var userProvider = this.providerManager.GetProvider<User>();

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = "john.doe",
                FirstName = "John",
                LastName = "Doe",
                Address = "NYC"
            };

            userProvider.Create(user);

            this.providerManager.SaveChanges();

            return this;
        }

        public DataSeeder SeedProducts()
        {
            var productProvider = this.providerManager.GetProvider<Product>();

            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apple",
                Price = 1,
                Inventory = 10
            };

            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Watermelon",
                Price = 2,
                Inventory = 50
            };

            var product3 = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Orange",
                Price = 0.5m,
                Inventory = 5
            };

            productProvider.Create(product1);
            productProvider.Create(product2);
            productProvider.Create(product3);

            this.providerManager.SaveChanges();

            return this;
        }
    }
}
