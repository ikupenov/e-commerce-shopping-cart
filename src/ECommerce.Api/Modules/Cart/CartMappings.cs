using AutoMapper;

namespace ECommerce.Api.Modules.Cart
{
    public class CartMappings : Profile
    {
        public CartMappings()
        {
            base.CreateMap<CartViewModel, Core.Entities.Cart>();
        }
    }
}
