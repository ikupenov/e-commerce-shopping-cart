using System;
using System.Linq;
using ECommerce.Core.Gateways;

namespace ECommerce.Core.Managers.Cart
{
    public class CartManager : Manager, ICartManager
    {
        private readonly IProvider<Entities.Cart> cartProvider;

        public CartManager(IProviderManager providerManager) : base(providerManager)
        {
            this.cartProvider = this.ProviderManager.GetProvider<Entities.Cart>();
        }

        public Entities.Cart GetCartByUserId(Guid userId)
        {
            return this.cartProvider.GetBy(c => c.User.Id == userId).SingleOrDefault();
        }
    }
}
