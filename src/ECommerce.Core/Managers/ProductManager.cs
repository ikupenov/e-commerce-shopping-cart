using System.Collections.Generic;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;

namespace ECommerce.Core.Managers
{
    public sealed class ProductManager : Manager, IProductManager
    {
        private readonly IProvider<Product> productProvider;

        public ProductManager(IProviderManager providerManager) 
            : base(providerManager)
        {
            this.productProvider = this.ProviderManager.GetProvider<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.productProvider.GetAll();
        }
    }
}
