using System.Collections.Generic;

namespace ECommerce.Core.Entities
{
    public class Order : Entity
    {
        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
