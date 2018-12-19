using System;
using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Managers.Users
{
    public interface IUserManager
    {
        IEnumerable<User> GetUsers();

        User GetUserById(Guid id);
    }
}
