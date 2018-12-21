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

            var cherries = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Cherries",
                Price = 1,
                ImageUrl = @"https://ssl.c.photoshelter.com/img-get/I0000IahmNPYV5G8/t/200/I0000IahmNPYV5G8.jpg"
            };

            var raspberries = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Raspberries",
                Price = 2,
                ImageUrl = @"https://ssl.c.photoshelter.com/img-get/I0000Diz_HuaOFcw/t/200/I0000Diz_HuaOFcw.jpg"
            };

            var apricots = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Apricots",
                Price = 0.5m,
                ImageUrl = @"https://ssl.c.photoshelter.com/img-get/I0000nY.nQorVMEE/t/200/I0000nY.nQorVMEE.jpg"
            };

            productProvider.Create(cherries);
            productProvider.Create(raspberries);
            productProvider.Create(apricots);

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
