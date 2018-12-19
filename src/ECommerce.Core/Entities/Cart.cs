using System.Collections.Generic;

namespace ECommerce.Core.Entities
{
    public class Cart : Entity
    {
        public virtual User User { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
