using System.Collections.Generic;

namespace ECommerce.Api.Modules.Cart
{
    public class CartDTO
    {
        IEnumerable<CartItemDTO> CartItems { get; set; }
    }
}
