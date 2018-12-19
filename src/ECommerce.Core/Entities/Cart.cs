using System;
using System.Collections.Generic;

namespace ECommerce.Core.Entities
{
    public sealed class Cart : Entity
    {
        public Guid UserId { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }
    }
}
