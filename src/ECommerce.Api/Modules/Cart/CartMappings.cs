using AutoMapper;

namespace ECommerce.Api.Modules.Cart
{
    public class CartMappings : Profile
    {
        public CartMappings()
        {
            CreateMap<CartViewModel, Core.Entities.Cart>();
        }
    }
}
