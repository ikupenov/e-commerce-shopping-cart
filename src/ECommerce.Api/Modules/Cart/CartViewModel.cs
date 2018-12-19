using System.Collections.Generic;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Cart
{
    public class CartViewModel
    {
        IEnumerable<CartItemViewModel> CartItems { get; set; }
    }
}
