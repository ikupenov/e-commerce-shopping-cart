using System;
using ECommerce.Api.Modules.Products;

namespace ECommerce.Api.Modules.Cart
{
    public class CartItemDTO
    {
        public Guid Id { get; set; }

        public ProductDTO Product { get; set; }

        public int Quantity { get; set; }
    }
}
