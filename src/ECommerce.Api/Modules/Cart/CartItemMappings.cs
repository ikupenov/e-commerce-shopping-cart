using AutoMapper;
using ECommerce.Core.Entities;

namespace ECommerce.Api.Modules.Cart
{
    internal class CartItemMappings : Profile
    {
        public CartItemMappings()
        {
            base.CreateMap<CartItemDTO, CartItem>();
        }
    }
}
