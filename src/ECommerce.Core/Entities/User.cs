﻿namespace ECommerce.Core.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }
    }
}
