using System;
using System.Threading.Tasks;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Gateways
{
    public interface IProviderManager : IDisposable
    {
        IProvider<T> GetProvider<T>() where T : Entity;

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
