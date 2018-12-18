using System;

namespace ECommerce.Core.Entities
{
    public sealed class CartItem : Entity
    {
        public Guid CartId { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
