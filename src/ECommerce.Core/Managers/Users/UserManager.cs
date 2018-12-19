using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Core.Entities;
using ECommerce.Core.Gateways;

namespace ECommerce.Core.Managers.Users
{
    public class UserManager : Manager, IUserManager
    {
        private readonly IProvider<User> userProvider;

        public UserManager(IProviderManager providerManager) : base(providerManager)
        {
            this.userProvider = this.ProviderManager.GetProvider<User>();
        }

        public User GetUserById(Guid userId)
        {
            return this.userProvider.GetBy(u => u.Id == userId).SingleOrDefault();
        }

        public IEnumerable<User> GetUsers()
        {
            return this.userProvider.GetAll();
        }
    }
}
