using ECommerce.Core.Gateways;

namespace ECommerce.Core.Managers
{
    public abstract class Manager
    {
        public Manager(IProviderManager providerManager)
        {
            this.ProviderManager = providerManager;
        }

        protected IProviderManager ProviderManager { get; }

        protected void SaveChanges()
        {
            this.ProviderManager.SaveChanges();
        }

        protected async void SaveChangesAsync()
        {
            await this.ProviderManager.SaveChangesAsync();
        }
    }
}
