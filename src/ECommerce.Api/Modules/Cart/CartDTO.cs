using System.Collections.Generic;

namespace ECommerce.Api.Modules.Cart
{
    public class CartDTO
    {
        public IEnumerable<CartItemDTO> CartItems { get; set; }
    }
}
