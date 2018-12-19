using AutoMapper;

namespace ECommerce.Api.Modules.Cart
{
    public class CartMappings : Profile
    {
        public CartMappings()
        {
            base.CreateMap<CartItemDTO, Core.Entities.Cart>();
        }
    }
}
