using System;
using System.Linq;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;

namespace ECommerce.Infrastructure.Data.Prototyping
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
                .SeedCarts()
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

        public DataSeeder SeedCarts(bool shouldSeedDependencies = false)
        {
            var cartProvider = this.providerManager.GetProvider<Cart>();
            var userProvider = this.providerManager.GetProvider<User>();

            var users = userProvider.GetAll();
            if (shouldSeedDependencies && !users.Any())
            {
                this.SeedUsers();
            }

            foreach (var user in users)
            {
                var cart = new Cart
                {
                    Id = Guid.NewGuid(),
                    User = user
                };

                cartProvider.Create(cart);
            }

            this.providerManager.SaveChanges();

            return this;
        }
    }
}
