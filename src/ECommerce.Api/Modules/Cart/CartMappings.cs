using AutoMapper;

namespace ECommerce.Api.Modules.Cart
{
    internal class CartMappings : Profile
    {
        public CartMappings()
        {
            base.CreateMap<Core.Entities.Cart, CartDTO>();
            base.CreateMap<CartDTO, Core.Entities.Cart>();
        }
    }
}
