using System;
using System.Collections.Generic;

namespace ECommerce.Core.Entities
{
    public sealed class Order : Entity
    {
        public Guid UserId { get; set; }

        public IEnumerable<CartItem> CartItems { get; set; }

        public string Address { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
