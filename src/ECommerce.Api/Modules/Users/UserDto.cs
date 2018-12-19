using System;

namespace ECommerce.Api.Modules.Users
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
