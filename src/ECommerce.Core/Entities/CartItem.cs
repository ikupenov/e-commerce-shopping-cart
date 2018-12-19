using System;

namespace ECommerce.Core.Entities
{
    public class CartItem : Entity
    {
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }

        public virtual Product Product { get; set; }
    }
}
