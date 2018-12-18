using System;
using System.Collections.Generic;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Infrastructure.Gateways
{
    public class EntityFrameworkProviderManager : IProviderManager
    {
        private readonly DbContext context;
        private readonly Dictionary<Type, object> providers;

        public EntityFrameworkProviderManager(DbContext context)
        {
            this.context = context;
            this.providers = new Dictionary<Type, object>();
        }

        public IProvider<T> GetProvider<T>() where T : Entity
        {
            var entityType = typeof(T);

            if (!this.providers.ContainsKey(entityType))
            {
                var providerType = typeof(EntityFrameworkProvider<T>);
                var providerInstance = Activator.CreateInstance(providerType, this.context);

                this.providers.Add(entityType, providerInstance);
            }

            return this.providers[entityType] as IProvider<T>;
        }

        public void SaveChanges() => this.context.SaveChanges();

        public async void SaveChangesAsync() => await this.context.SaveChangesAsync();

        public void Dispose() => this.context.Dispose();
    }
}
